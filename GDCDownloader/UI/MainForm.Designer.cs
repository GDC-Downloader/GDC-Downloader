namespace TcgaDownloader.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            txtLog = new TextBox();
            progressBar1 = new ProgressBar();
            browse = new Button();
            start = new Button();
            SuspendLayout();
            // 
            // txtLog
            // 
            txtLog.Location = new Point(68, 106);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(469, 23);
            txtLog.TabIndex = 0;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(68, 48);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(469, 23);
            progressBar1.TabIndex = 2;
            // 
            // browse
            // 
            browse.Location = new Point(543, 105);
            browse.Name = "browse";
            browse.Size = new Size(75, 23);
            browse.TabIndex = 3;
            browse.Text = "Browse";
            browse.UseVisualStyleBackColor = true;
            browse.Click += browse_Click;
            // 
            // start
            // 
            start.Location = new Point(543, 48);
            start.Name = "start";
            start.Size = new Size(75, 23);
            start.TabIndex = 4;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.WhatsApp_Image_2025_12_17_at_16_04_29;
            ClientSize = new Size(686, 298);
            Controls.Add(start);
            Controls.Add(browse);
            Controls.Add(progressBar1);
            Controls.Add(txtLog);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "GDC Downloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLog;
        private ProgressBar progressBar1;
        private Button browse;
        private Button start;
    }
}