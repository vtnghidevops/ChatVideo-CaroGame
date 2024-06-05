

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FinalProject
{
    public class SocketTCPClient
    {
        public TcpClient tcpClient;
        public NetworkStream stream;
        public string clientName;
        public IPEndPoint IPEndPointServer;
        public string messRecServer;
        public string serverName;
        public string myIp; // ip client

        public event EventHandler<MessageEventArgs> MessageReceived;

        public SocketTCPClient(IPEndPoint ipep)
        {
            IPEndPointServer = ipep;
        }

        public void ConnectServerTCP()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(IPEndPointServer);


                // Set receive and send timeouts
                tcpClient.ReceiveTimeout = 600000; // 60 seconds
                tcpClient.SendTimeout = 600000; // 60 seconds


                stream = tcpClient.GetStream();
                Thread receiver = new Thread(ReceiveFromServer);
                receiver.Start();

                MessageBox.Show("Successfully Connected To Server");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connecting To Server. " + e.Message);
            }
        }

        private void ReceiveFromServer()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024];
                    int bytesRead = stream.Read(data, 0, data.Length);
                    if (bytesRead > 0)
                    {
                        messRecServer = Encoding.UTF8.GetString(data, 0, bytesRead);
                      
                        OnMessageReceived(new MessageEventArgs(messRecServer));
                    }
                }
            }
            catch (IOException ex)
            {
                if (ex.InnerException is SocketException socketException && socketException.SocketErrorCode == SocketError.TimedOut)
                {
                    MessageBox.Show("Timeout receiving data from server.");
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public void SendDataToServer(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            tcpClient.Client.Send(data);
        }

        protected virtual void OnMessageReceived(MessageEventArgs e)
        {
            MessageReceived?.Invoke(this, e);
        }
    }
}
