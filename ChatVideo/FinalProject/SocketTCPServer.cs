

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FinalProject
{
    public class SocketTCPServer
    {
        public string ipServer;
        public int portServer;

        public string clientName;
        public string serverName;

        IPEndPoint ipEndPointServer;

        //Dictionary<string, string> infoClient = new Dictionary<string, string>();
        public List<Socket> listSocketClientTCP;
        public string msgFromClient;
        Socket ServerListener;

        
        public string msgWait = "Waiting connect from user....";

        public string ipClientConnect; // ip client

        public event EventHandler<MessageEventArgs> MessageReceived;

        public event Action ClientConnected;

        public SocketTCPServer(IPEndPoint ipEndPoint, string serverName)
        {
            this.ipEndPointServer = ipEndPoint;
            string[] parts = serverName.Split(new string[] { "Server name: " }, StringSplitOptions.None);
            if (parts.Length > 1)
            {
                this.serverName = parts[1].Trim(); // Loại bỏ khoảng trắng đầu và cuối chuỗi
            }
            else
            {
                throw new ArgumentException("Invalid server name format. Expected format is 'Server name: <name>'.");
            }
        }

        public void StartListening()
        {
            Thread tcpThreadServer = new Thread(new ThreadStart(ListennThreadTCP));
            tcpThreadServer.Start();
        }

        public void ListennThreadTCP()
        {
            try
            {
                listSocketClientTCP = new List<Socket>();
                ServerListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerListener.Bind(ipEndPointServer);
                ServerListener.Listen(10);
                MessageBox.Show("Host Server TCP Thành công");

                while (true)
                {
                    try
                    {
                        Socket clientSocketTCP = ServerListener.Accept();

                        // Set receive and send timeouts
                        clientSocketTCP.ReceiveTimeout = 600000; // 10p
                        clientSocketTCP.SendTimeout = 600000; 

                        // Nhận một thông điệp xác nhận từ client
                        byte[] buffer = new byte[1024];
                        int bytesRead = clientSocketTCP.Receive(buffer);
                        string confirmationMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        if (confirmationMessage == "ClientConnected")
                        {


                            listSocketClientTCP.Add(clientSocketTCP);

                            string ipClient = clientSocketTCP.RemoteEndPoint.ToString();
                            string[] parts = ipClient.Split(':');
                            ipClientConnect = parts[0];

                            // Gửi thông tin IP client
                            string msg = "Your IP: " + ipClientConnect;
                            byte[] dataIP = Encoding.UTF8.GetBytes(msg);
                            clientSocketTCP.Send(dataIP);

                            Thread receiveData = new Thread(() => receiveDataFromClient(clientSocketTCP));
                            receiveData.Start();

                            // Gửi dữ liệu đến client
                            byte[] data = Encoding.UTF8.GetBytes("Server name: " + serverName);
                            clientSocketTCP.Send(data);

                            // Kích hoạt sự kiện khi có client kết nối
                            ClientConnected?.Invoke();
                        }
                    }
                    catch (SocketException ex)
                    {

                        Console.WriteLine($"Error accepting client connection: {ex.Message}");
                    }


                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error From Listen TCP: " + e.Message);
            }
        }


        public void receiveDataFromClient(Socket clientSocket)
        {
            try
            {
                byte[] receive = new byte[1024];
                while (true)
                {
                    int bytesReceived = clientSocket.Receive(receive);
                    if (bytesReceived == 0)
                    {
                        MessageBox.Show($"{clientName} đã rời khỏi cuộc trò chuyện!");
                        CloseClientConnection(clientSocket);
                        return;
                    }
                    else
                    {
                        msgFromClient = Encoding.UTF8.GetString(receive, 0, bytesReceived);
                      
                     
                         // Raise the MessageReceived event
                        OnMessageReceived(new MessageEventArgs(msgFromClient));

                       
                    }
                }
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    MessageBox.Show("Timeout receiving data from client.");
                }
                else
                {
                    MessageBox.Show("Error Receive Data TCP: " + ex.Message);
                }
                CloseClientConnection(clientSocket);
            }
        }

        private void CloseClientConnection(Socket clientSocket)
        {
            clientSocket.Close();
            listSocketClientTCP.Remove(clientSocket);
        }

        public void Broadcast(string msg)
        {
            foreach (Socket clientSocket in listSocketClientTCP)
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    clientSocket.Send(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending message: " + ex.Message);
                }
            }
        }

        public void SendDataToClient(string msg)
        {
            foreach (Socket clientSocket in listSocketClientTCP)
            {
                byte[] data = Encoding.UTF8.GetBytes(msg);
                clientSocket.Send(data);
            }
            
        }

        protected virtual void OnMessageReceived(MessageEventArgs e)
        {
            MessageReceived?.Invoke(this, e);
        }

      

       
    }
}
