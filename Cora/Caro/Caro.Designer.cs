namespace Caro
{
    partial class Caro
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caro));
            pnlChessBoard = new Panel();
            panel2 = new Panel();
            label4 = new Label();
            label2 = new Label();
            btnLAN = new Button();
            txbPlayerName = new TextBox();
            txbIP = new TextBox();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            pctbMark = new PictureBox();
            prcbCoolDown = new ProgressBar();
            tmCoolDown = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctbMark).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.BackColor = SystemColors.Control;
            pnlChessBoard.Location = new Point(14, 37);
            pnlChessBoard.Margin = new Padding(3, 4, 3, 4);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(635, 635);
            pnlChessBoard.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnLAN);
            panel2.Controls.Add(txbPlayerName);
            panel2.Controls.Add(txbIP);
            panel2.Location = new Point(684, 84);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(309, 272);
            panel2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SF Mono", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(49, 23);
            label4.Name = "label4";
            label4.Size = new Size(163, 20);
            label4.TabIndex = 9;
            label4.Text = "Turn/Your name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Mono", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(49, 121);
            label2.Name = "label2";
            label2.Size = new Size(174, 20);
            label2.TabIndex = 6;
            label2.Text = "Your IP/IP Host";
            // 
            // btnLAN
            // 
            btnLAN.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLAN.Location = new Point(52, 210);
            btnLAN.Margin = new Padding(3, 4, 3, 4);
            btnLAN.Name = "btnLAN";
            btnLAN.Size = new Size(202, 46);
            btnLAN.TabIndex = 3;
            btnLAN.Text = "Connect";
            btnLAN.UseVisualStyleBackColor = true;
            btnLAN.Click += btnLAN_Click;
            // 
            // txbPlayerName
            // 
            txbPlayerName.Font = new Font("SF Mono", 12F);
            txbPlayerName.Location = new Point(49, 59);
            txbPlayerName.Margin = new Padding(3, 4, 3, 4);
            txbPlayerName.Name = "txbPlayerName";
            txbPlayerName.Size = new Size(202, 31);
            txbPlayerName.TabIndex = 0;
            // 
            // txbIP
            // 
            txbIP.Font = new Font("SF Mono", 12F);
            txbIP.Location = new Point(52, 161);
            txbIP.Margin = new Padding(3, 4, 3, 4);
            txbIP.Name = "txbIP";
            txbIP.Size = new Size(202, 31);
            txbIP.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pctbMark);
            panel3.Controls.Add(prcbCoolDown);
            panel3.Location = new Point(684, 377);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(309, 267);
            panel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(149, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SF Mono", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 175);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 7;
            label3.Text = "Count time";
            // 
            // pctbMark
            // 
            pctbMark.BackColor = SystemColors.Control;
            pctbMark.BackgroundImageLayout = ImageLayout.Stretch;
            pctbMark.Location = new Point(230, 95);
            pctbMark.Margin = new Padding(3, 4, 3, 4);
            pctbMark.Name = "pctbMark";
            pctbMark.Size = new Size(52, 47);
            pctbMark.SizeMode = PictureBoxSizeMode.StretchImage;
            pctbMark.TabIndex = 4;
            pctbMark.TabStop = false;
            // 
            // prcbCoolDown
            // 
            prcbCoolDown.Location = new Point(23, 215);
            prcbCoolDown.Margin = new Padding(3, 4, 3, 4);
            prcbCoolDown.Name = "prcbCoolDown";
            prcbCoolDown.Size = new Size(250, 31);
            prcbCoolDown.TabIndex = 1;
            // 
            // tmCoolDown
            // 
            tmCoolDown.Tick += tmCoolDown_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1058, 30);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, undoToolStripMenuItem, quitToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGameToolStripMenuItem.Size = new Size(217, 26);
            newGameToolStripMenuItem.Text = "New game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(217, 26);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            quitToolStripMenuItem.Size = new Size(217, 26);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // Caro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 696);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pnlChessBoard);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Caro";
            Text = "Game Caro";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctbMark).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlChessBoard;
        private Panel panel2;
        private Panel panel3;
        private TextBox txbPlayerName;
        private PictureBox pctbMark;
        private Button btnLAN;
        private TextBox txbIP;
        private ProgressBar prcbCoolDown;
        private System.Windows.Forms.Timer tmCoolDown;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Label label4;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
    }
}
