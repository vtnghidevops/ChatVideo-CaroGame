namespace FinalProject
{
    partial class Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            panel1 = new Panel();
            ptb_Cam = new PictureBox();
            lb_checkConnectUser = new Label();
            lb_username = new Label();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            rtb_msg = new RichTextBox();
            ptb_sendMsg = new PictureBox();
            lv_log = new ListView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptb_Cam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptb_sendMsg).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(ptb_Cam);
            panel1.Controls.Add(lb_checkConnectUser);
            panel1.Controls.Add(lb_username);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(9, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(473, 91);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // ptb_Cam
            // 
            ptb_Cam.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ptb_Cam.Cursor = Cursors.Hand;
            ptb_Cam.Image = (Image)resources.GetObject("ptb_Cam.Image");
            ptb_Cam.Location = new Point(394, 16);
            ptb_Cam.Name = "ptb_Cam";
            ptb_Cam.Size = new Size(58, 62);
            ptb_Cam.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_Cam.TabIndex = 5;
            ptb_Cam.TabStop = false;
            ptb_Cam.Click += ptb_Cam_Click;
            // 
            // lb_checkConnectUser
            // 
            lb_checkConnectUser.AutoSize = true;
            lb_checkConnectUser.Font = new Font("SF Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_checkConnectUser.Location = new Point(100, 49);
            lb_checkConnectUser.Name = "lb_checkConnectUser";
            lb_checkConnectUser.Size = new Size(163, 20);
            lb_checkConnectUser.TabIndex = 4;
            lb_checkConnectUser.Text = "Đang hoạt động";
            // 
            // lb_username
            // 
            lb_username.AutoSize = true;
            lb_username.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_username.Location = new Point(100, 16);
            lb_username.Name = "lb_username";
            lb_username.Size = new Size(106, 24);
            lb_username.TabIndex = 3;
            lb_username.Text = "User ...";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(81, 53);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(rtb_msg);
            panel2.Controls.Add(ptb_sendMsg);
            panel2.Location = new Point(9, 721);
            panel2.Name = "panel2";
            panel2.Size = new Size(473, 60);
            panel2.TabIndex = 1;
            // 
            // rtb_msg
            // 
            rtb_msg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_msg.Font = new Font("SF Mono", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtb_msg.Location = new Point(3, 6);
            rtb_msg.Name = "rtb_msg";
            rtb_msg.Size = new Size(421, 46);
            rtb_msg.TabIndex = 2;
            rtb_msg.Text = "Enter your message here";
            rtb_msg.TextChanged += rtb_msg_TextChanged;
            // 
            // ptb_sendMsg
            // 
            ptb_sendMsg.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ptb_sendMsg.Cursor = Cursors.Hand;
            ptb_sendMsg.Image = (Image)resources.GetObject("ptb_sendMsg.Image");
            ptb_sendMsg.Location = new Point(430, 9);
            ptb_sendMsg.Name = "ptb_sendMsg";
            ptb_sendMsg.Size = new Size(41, 43);
            ptb_sendMsg.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_sendMsg.TabIndex = 4;
            ptb_sendMsg.TabStop = false;
            ptb_sendMsg.Click += ptb_sendMsg_Click;
            // 
            // lv_log
            // 
            lv_log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lv_log.Cursor = Cursors.Hand;
            lv_log.Font = new Font("SF Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lv_log.Location = new Point(9, 97);
            lv_log.Name = "lv_log";
            lv_log.Size = new Size(474, 618);
            lv_log.TabIndex = 2;
            lv_log.UseCompatibleStateImageBehavior = false;
            lv_log.View = View.List;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 779);
            Controls.Add(lv_log);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(505, 826);
            Name = "Chat";
            Text = "Chat";
            Load += Chat_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptb_Cam).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptb_sendMsg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private RichTextBox rtb_msg;
        private Label lb_username;
        private PictureBox pictureBox2;
        private PictureBox ptb_sendMsg;
        private ListView lv_log;
        private Label lb_checkConnectUser;
        private PictureBox ptb_Cam;
    }
}