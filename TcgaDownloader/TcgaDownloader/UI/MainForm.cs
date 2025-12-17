using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcgaDownloader.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TcgaDownloader.UI
{
    public partial class MainForm : Form
    {
        private readonly ManifestService _manifestService = new();
        private readonly DownloadService _downloadService = new();
        private string? _manifestPath;
        public MainForm()
        {
            InitializeComponent();

            _downloadService.OnOutput += msg =>
            {
                if (!IsHandleCreated) return;
                Invoke(() => txtLog.AppendText(msg + Environment.NewLine));
            };

            _downloadService.OnProgress += p =>
            {
                if (!IsHandleCreated) return;
                Invoke(() => progressBar1.Value = Math.Min(100, Math.Max(0, p)));
            };

        }

        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    InitializeComponent();

        //    _downloadService.OnOutput += msg =>
        //    {
        //        if (!IsHandleCreated) return;
        //        Invoke(() => txtLog.AppendText(msg + Environment.NewLine));
        //    };

        //    _downloadService.OnProgress += p =>
        //    {
        //        if (!IsHandleCreated) return;
        //        Invoke(() => progressBar1.Value = Math.Min(100, Math.Max(0, p)));
        //    };
        //}


        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //    if (_manifestPath == null)
        //    {
        //        MessageBox.Show("Select manifest first");
        //        return;
        //    }

        //    _downloadService.Start(_manifestPath);
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Manifest files (*.json;*.txt;*.tsv;*.csv)|*.json;*.txt;*.tsv;*.csv|All files (*.*)|*.*"

            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _manifestPath = dialog.FileName;
                txtLog.AppendText("Manifest loaded\n");

                var items = _manifestService.Load(_manifestPath);
                txtLog.AppendText($"Files: {items.Count}\n");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_manifestPath == null)
            {
                MessageBox.Show("Select manifest first");
                return;
            }

            _downloadService.Start(_manifestPath);
        }
    }
}
