namespace FinalProject
{
    partial class CallVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallVideo));
            ptb_mainCall = new PictureBox();
            ptb_otherCall = new PictureBox();
            ptb_interurpt = new PictureBox();
            ptb_controlMic = new PictureBox();
            ptb_controlCam = new PictureBox();
            menuStrip1 = new MenuStrip();
            chọnCameraToolStripMenuItem = new ToolStripMenuItem();
            cb_optionCam = new ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)ptb_mainCall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptb_otherCall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptb_interurpt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptb_controlMic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptb_controlCam).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ptb_mainCall
            // 
            ptb_mainCall.Cursor = Cursors.Hand;
            ptb_mainCall.Image = (Image)resources.GetObject("ptb_mainCall.Image");
            ptb_mainCall.Location = new Point(1, 35);
            ptb_mainCall.MinimumSize = new Size(445, 719);
            ptb_mainCall.Name = "ptb_mainCall";
            ptb_mainCall.Size = new Size(520, 719);
            ptb_mainCall.SizeMode = PictureBoxSizeMode.CenterImage;
            ptb_mainCall.TabIndex = 0;
            ptb_mainCall.TabStop = false;
            ptb_mainCall.Click += ptb_mainCall_Click;
            // 
            // ptb_otherCall
            // 
            ptb_otherCall.Image = (Image)resources.GetObject("ptb_otherCall.Image");
            ptb_otherCall.Location = new Point(309, 58);
            ptb_otherCall.MinimumSize = new Size(139, 172);
            ptb_otherCall.Name = "ptb_otherCall";
            ptb_otherCall.Size = new Size(195, 172);
            ptb_otherCall.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_otherCall.TabIndex = 1;
            ptb_otherCall.TabStop = false;
            // 
            // ptb_interurpt
            // 
            ptb_interurpt.BackColor = Color.Transparent;
            ptb_interurpt.Cursor = Cursors.Hand;
            ptb_interurpt.Image = (Image)resources.GetObject("ptb_interurpt.Image");
            ptb_interurpt.Location = new Point(554, 605);
            ptb_interurpt.Name = "ptb_interurpt";
            ptb_interurpt.Size = new Size(75, 54);
            ptb_interurpt.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_interurpt.TabIndex = 2;
            ptb_interurpt.TabStop = false;
            ptb_interurpt.Click += ptb_interurpt_Click;
            // 
            // ptb_controlMic
            // 
            ptb_controlMic.BackColor = Color.Transparent;
            ptb_controlMic.Cursor = Cursors.Hand;
            ptb_controlMic.Image = (Image)resources.GetObject("ptb_controlMic.Image");
            ptb_controlMic.Location = new Point(557, 515);
            ptb_controlMic.Name = "ptb_controlMic";
            ptb_controlMic.Size = new Size(72, 66);
            ptb_controlMic.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_controlMic.TabIndex = 3;
            ptb_controlMic.TabStop = false;
            ptb_controlMic.Click += ptb_controlMic_Click;
            // 
            // ptb_controlCam
            // 
            ptb_controlCam.BackColor = Color.Transparent;
            ptb_controlCam.Cursor = Cursors.Hand;
            ptb_controlCam.Image = (Image)resources.GetObject("ptb_controlCam.Image");
            ptb_controlCam.Location = new Point(554, 678);
            ptb_controlCam.Name = "ptb_controlCam";
            ptb_controlCam.Size = new Size(75, 63);
            ptb_controlCam.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_controlCam.TabIndex = 4;
            ptb_controlCam.TabStop = false;
            ptb_controlCam.Click += ptb_controlCam_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { chọnCameraToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(656, 28);
            menuStrip1.TabIndex = 26;
            menuStrip1.Text = "menuStrip1";
            // 
            // chọnCameraToolStripMenuItem
            // 
            chọnCameraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cb_optionCam });
            chọnCameraToolStripMenuItem.Font = new Font("SF Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chọnCameraToolStripMenuItem.Name = "chọnCameraToolStripMenuItem";
            chọnCameraToolStripMenuItem.Size = new Size(144, 24);
            chọnCameraToolStripMenuItem.Text = "Chọn Camera";
            // 
            // cb_optionCam
            // 
            cb_optionCam.DropDownHeight = 100;
            cb_optionCam.DropDownWidth = 140;
            cb_optionCam.IntegralHeight = false;
            cb_optionCam.Name = "cb_optionCam";
            cb_optionCam.Size = new Size(150, 28);
            // 
            // CallVideo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 752);
            Controls.Add(ptb_controlCam);
            Controls.Add(ptb_controlMic);
            Controls.Add(ptb_interurpt);
            Controls.Add(ptb_otherCall);
            Controls.Add(ptb_mainCall);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(561, 799);
            Name = "CallVideo";
            Text = "Video Call";
            ((System.ComponentModel.ISupportInitialize)ptb_mainCall).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptb_otherCall).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptb_interurpt).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptb_controlMic).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptb_controlCam).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ptb_mainCall;
        private PictureBox ptb_otherCall;
        private PictureBox ptb_interurpt;
        private PictureBox ptb_controlMic;
        private PictureBox ptb_controlCam;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem chọnCameraToolStripMenuItem;
        private ToolStripComboBox cb_optionCam;
    }
}
