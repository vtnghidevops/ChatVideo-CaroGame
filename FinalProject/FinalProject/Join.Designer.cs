namespace FinalProject
{
    partial class Join
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Join));
            groupBox1 = new GroupBox();
            tb_name = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            tb_ipHost = new TextBox();
            btn_JoinChat = new Button();
            label2 = new Label();
            btn_CreateHost = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.MenuBar;
            groupBox1.Controls.Add(tb_name);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(352, 125);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Your Infomation";
            // 
            // tb_name
            // 
            tb_name.Location = new Point(105, 51);
            tb_name.Name = "tb_name";
            tb_name.Size = new Size(211, 27);
            tb_name.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 51);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Your Name";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tb_ipHost);
            groupBox2.Controls.Add(btn_JoinChat);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 161);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 125);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Guest Connection";
            // 
            // tb_ipHost
            // 
            tb_ipHost.Location = new Point(105, 40);
            tb_ipHost.Name = "tb_ipHost";
            tb_ipHost.Size = new Size(166, 27);
            tb_ipHost.TabIndex = 5;
            tb_ipHost.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_JoinChat
            // 
            btn_JoinChat.Location = new Point(105, 73);
            btn_JoinChat.Name = "btn_JoinChat";
            btn_JoinChat.Size = new Size(166, 30);
            btn_JoinChat.TabIndex = 3;
            btn_JoinChat.Text = "Join Chat";
            btn_JoinChat.UseVisualStyleBackColor = true;
            btn_JoinChat.Click += btn_JoinChat_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 43);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 1;
            label2.Text = "IP Host";
            // 
            // btn_CreateHost
            // 
            btn_CreateHost.Location = new Point(12, 337);
            btn_CreateHost.Name = "btn_CreateHost";
            btn_CreateHost.Size = new Size(358, 53);
            btn_CreateHost.TabIndex = 2;
            btn_CreateHost.Text = "Create Host Room";
            btn_CreateHost.UseVisualStyleBackColor = true;
            btn_CreateHost.Click += btn_CreateHost_Click;
            // 
            // Join
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 416);
            Controls.Add(btn_CreateHost);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Join";
            Text = "Chat";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btn_CreateHost;
        private TextBox tb_name;
        private Label label1;
        private TextBox tb_ipHost;
        private Button btn_JoinChat;
        private Label label2;
    }
}