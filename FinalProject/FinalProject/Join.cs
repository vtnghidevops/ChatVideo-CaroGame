using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Join : Form
    {
        int portTCP = 16923;
       
        bool isHostServerSuccess = false;
        bool isConnectSuccessFromClient = false;
        public Join()
        {
            InitializeComponent();
        }

        private void btn_CreateHost_Click(object sender, EventArgs e)
        {
            try
            {
                string ipHostText = tb_ipHost.Text.Trim();
                if (string.IsNullOrEmpty(ipHostText))
                {
                    MessageBox.Show("IP address cannot be empty.");
                    return;
                }
                else
                {
                    IPAddress ipAddress = IPAddress.TryParse(ipHostText, out var parsedIp) ? parsedIp : throw new ArgumentException("Invalid IP address.");


                    IPEndPoint ipepServerTCP = new IPEndPoint(ipAddress, portTCP);
                   

                    string serverName = $"Server name: {tb_name.Text}";
                    SocketTCPServer tcpServer = new SocketTCPServer(ipepServerTCP, serverName);
                    tcpServer.StartListening();

                    

                    isHostServerSuccess = true;
                    if (isHostServerSuccess)
                    {
                        Chat chat = new Chat(tcpServer, ipAddress);
                        chat.Show();
                        //this.Hide();
                        btn_CreateHost.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Server Host setup failed, please check the ports and try again later.");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btn_JoinChat_Click(object sender, EventArgs e)
        {
            try
            {
                string ipHostText = tb_ipHost.Text.Trim();
                if (string.IsNullOrEmpty(ipHostText))
                {
                    MessageBox.Show("IP address cannot be empty.");
                    return;
                }
                else
                {
                    IPAddress ipAddress = IPAddress.TryParse(ipHostText, out var parsedIp) ? parsedIp : throw new ArgumentException("Invalid IP address.");


                    IPEndPoint ipepServerTCP = new IPEndPoint(ipAddress, portTCP);
                    SocketTCPClient clientTCP = new SocketTCPClient(ipepServerTCP);
                    clientTCP.ConnectServerTCP();
                    
                    
                    


                    isConnectSuccessFromClient = true;
                    if (isConnectSuccessFromClient)
                    {
                       
                        Chat chat = new Chat(clientTCP,tb_name.Text, ipAddress);
                        chat.Show();
                        //this.Hide();
                        btn_JoinChat.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Server Host setup failed, please check the ports and try again later.");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



           
        }
    }
}
