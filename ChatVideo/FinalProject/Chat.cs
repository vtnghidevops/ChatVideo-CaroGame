using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Chat : Form
    {
        private SocketTCPClient clientTCP;
        private SocketTCPServer tcpServer;
        private string nameServer;
        private string nameClient;
        private bool isServerNameReceived = false; // Cờ để kiểm tra việc nhận tên server


        public IPAddress iPAddress; // use for UDP
        int portUDPVideo = 15234;
        int portUDPAudio = 17231;


        public Chat()
        {
            InitializeComponent();

            rtb_msg.Enter += Rtb_msg_Enter;
            rtb_msg.Leave += Rtb_msg_Leave;
            // Gán sự kiện KeyDown cho RichTextBox
            rtb_msg.KeyDown += new KeyEventHandler(rtb_msg_KeyDown);
            this.FormClosing += new FormClosingEventHandler(Chat_Closing);
        }

        private void Rtb_msg_Leave(object? sender, EventArgs e)
        {
            // Khôi phục văn bản mặc định nếu không có gì được nhập
            if (string.IsNullOrWhiteSpace(rtb_msg.Text))
            {
                rtb_msg.Text = "Enter your message here";

            }
        }

        private void Rtb_msg_Enter(object? sender, EventArgs e)
        {
            // Xóa văn bản mặc định khi người dùng nhấp vào RichTextBox
            if (rtb_msg.Text == "Enter your message here")
            {
                rtb_msg.Text = "";

            }
        }

        public Chat(SocketTCPServer tcpServer, IPAddress iPAddress)
        {

            InitializeComponent();
            this.tcpServer = tcpServer;
            this.iPAddress = iPAddress;

            // Đăng ký sự kiện cho tcpServer
            this.tcpServer.MessageReceived += TcpServer_MessageReceived;

            // Waiting from server
            lb_checkConnectUser.Text = tcpServer.msgWait;

            // this.Shown += Chat_Shown; // Sự kiện tải xong form 

            rtb_msg.Enter += Rtb_msg_Enter;
            rtb_msg.Leave += Rtb_msg_Leave;

            // Gán sự kiện KeyDown cho RichTextBox
            rtb_msg.KeyDown += new KeyEventHandler(rtb_msg_KeyDown);

            this.FormClosing += new FormClosingEventHandler(Chat_Closing);

            // Đăng ký sự kiện
            tcpServer.ClientConnected += TcpServer_ClientConnected;

        }

        public Chat(SocketTCPClient clientTCP, string nameClient, IPAddress iPAddress)
        {
            InitializeComponent();
            this.clientTCP = clientTCP;
            clientTCP.clientName = nameClient;

            this.iPAddress = iPAddress;


            // Đăng ký sự kiện cho clientTCP
            this.clientTCP.MessageReceived += ClientTCP_MessageReceived;


            this.Shown += Chat_Shown;

            rtb_msg.Enter += Rtb_msg_Enter;
            rtb_msg.Leave += Rtb_msg_Leave;

            // Gán sự kiện KeyDown cho RichTextBox
            rtb_msg.KeyDown += new KeyEventHandler(rtb_msg_KeyDown);

            this.FormClosing += new FormClosingEventHandler(Chat_Closing);


        }

        private void TcpServer_ClientConnected()
        {
            // Chuyển đổi về luồng giao diện người dùng
            this.Invoke(new Action(() =>
            {
                lb_checkConnectUser.Text = "Đang hoạt động";
                MessageBox.Show("A client has connected.", "Server Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }

        private void Chat_Shown(object sender, EventArgs e)
        {
            if (clientTCP != null)
            {
                // Message Connect client
                string msgConnect = "ClientConnected";
                clientTCP.SendDataToServer(msgConnect);

                // Message Name của client
                string msgFromClient = $"Client name: {clientTCP.clientName}";
                clientTCP.SendDataToServer(msgFromClient);
            }
        }


        private void rtb_msg_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu phím được ấn là Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Ngăn chặn tiếng bíp hệ thống khi ấn Enter
                e.SuppressKeyPress = true;

                // Kiểm tra nếu text trong richTextBox không rỗng
                if (!string.IsNullOrWhiteSpace(rtb_msg.Text))
                {
                    // Gọi sự kiện click của PictureBox
                    ptb_sendMsg_Click(sender, e);
                }
            }
        }

        private void ptb_sendMsg_Click(object sender, EventArgs e)
        {

            string msgSend = rtb_msg.Text;
            if (!string.IsNullOrWhiteSpace(msgSend))
            {
                if (tcpServer != null)
                {
                    tcpServer.SendDataToClient($"{tcpServer.serverName}: " + msgSend);

                }
                else if (clientTCP != null)
                {
                    clientTCP.SendDataToServer($"{clientTCP.clientName}: " + msgSend);

                }
                lv_log.Items.Add($"You: " + msgSend);
                rtb_msg.Text = "";
            }
        }


        private void TcpServer_MessageReceived(object sender, MessageEventArgs e)
        {

            // Tức là bảng này là server
            Invoke(new Action(() =>
            {

                if (e.Message.Contains("Client name:"))
                {

                    string[] parts = e.Message.Split(new[] { "Client name: " }, StringSplitOptions.RemoveEmptyEntries);


                    if (parts.Length > 0)
                    {
                        tcpServer.clientName = parts[0].Trim();
                        lb_username.Text = tcpServer.clientName;
                    }


                }
                else
                {
                    lv_log.Items.Add($"{e.Message}");

                }
            }));
            // tcpServer.Broadcast(e.Message); // lan truyền tới các client khác

        }

        private void ClientTCP_MessageReceived(object sender, MessageEventArgs e)
        {
            // Là người connect tới
            Invoke(new Action(() =>
            {



                // Kiểm tra nếu message nhận được là tên server
                if (e.Message.StartsWith("Server name:"))
                {
                    // Split the string using "Server name:" as the delimiter
                    string[] parts = e.Message.Split(new[] { "Server name:" }, StringSplitOptions.None);
                    if (parts.Length > 1)
                    {
                        // Trim any leading or trailing spaces from the server name
                        clientTCP.serverName = parts[1].Trim();
                        lb_username.Text = parts[1].Trim();
                    }


                }
                else if (e.Message.StartsWith("Your IP: "))
                {
                    string[] parts = e.Message.Split(new[] { "Your IP:" }, StringSplitOptions.None);
                    if (parts.Length > 1)
                    {
                        clientTCP.myIp = parts[1].Trim();
                        //MessageBox.Show("MY IP: " + clientTCP.myIp);
                    }
                }
                else
                {
                    lv_log.Items.Add($"{e.Message}");
                }
            }));

        }

        private void ptb_Cam_Click(object sender, EventArgs e)
        {

            if (tcpServer != null)
            {
                // Server
                CallVideo call = new CallVideo(true, iPAddress, tcpServer.ipClientConnect);
                call.Show();
            }
            else
            {
                // Client
                CallVideo call = new CallVideo(false, iPAddress, clientTCP.myIp);
                call.Show();
            }

        }


        private void Chat_Closing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra phản hồi từ hộp thoại
            if (result == DialogResult.No)
            {
                // Hủy bỏ sự kiện đóng form
                e.Cancel = true;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void rtb_msg_TextChanged(object sender, EventArgs e)
        {

        }

        private void Chat_Load(object sender, EventArgs e)
        {

        }
    }
}
