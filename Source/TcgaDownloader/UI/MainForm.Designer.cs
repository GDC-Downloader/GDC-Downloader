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
            label1 = new Label();
            SuspendLayout();
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.None;
            txtLog.Enabled = false;
            txtLog.ImeMode = ImeMode.On;
            txtLog.Location = new Point(49, 98);
            txtLog.Margin = new Padding(4, 5, 4, 5);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(605, 31);
            txtLog.TabIndex = 0;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.None;
            progressBar1.Location = new Point(49, 38);
            progressBar1.Margin = new Padding(4, 5, 4, 5);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(605, 31);
            progressBar1.TabIndex = 2;
            // 
            // browse
            // 
            browse.Anchor = AnchorStyles.None;
            browse.BackColor = Color.Silver;
            browse.Location = new Point(694, 98);
            browse.Margin = new Padding(4, 5, 4, 5);
            browse.Name = "browse";
            browse.Size = new Size(107, 38);
            browse.TabIndex = 3;
            browse.TabStop = false;
            browse.Text = "Browse";
            browse.UseVisualStyleBackColor = false;
            browse.Click += browse_Click;
            // 
            // start
            // 
            start.Anchor = AnchorStyles.None;
            start.BackColor = SystemColors.AppWorkspace;
            start.Location = new Point(694, 31);
            start.Margin = new Padding(4, 5, 4, 5);
            start.Name = "start";
            start.Size = new Size(107, 38);
            start.TabIndex = 4;
            start.TabStop = false;
            start.Text = "Start";
            start.UseVisualStyleBackColor = false;
            start.Click += start_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(49, 295);
            label1.Name = "label1";
            label1.Size = new Size(39, 25);
            label1.TabIndex = 5;
            label1.Text = "v1.1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(853, 339);
            Controls.Add(label1);
            Controls.Add(start);
            Controls.Add(browse);
            Controls.Add(progressBar1);
            Controls.Add(txtLog);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.On;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "GDC Downloader";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLog;
        private ProgressBar progressBar1;
        private Button browse;
        private Button start;
        private Label label1;
    }
}