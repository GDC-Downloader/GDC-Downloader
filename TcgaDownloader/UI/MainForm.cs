using System;
using System.Linq;
using System.Windows.Forms;
using TcgaDownloader.Services;

namespace TcgaDownloader.UI
{
    public partial class MainForm : Form
    {
        private readonly ManifestService _manifestService = new();
        private readonly DownloadService _downloadService = new();

        private string? _manifestPath;
        private long _totalBytes;

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
                Invoke(() => progressBar1.Value = p);
            };

            _downloadService.OnCompleted += () =>
            {
                if (!IsHandleCreated) return;
                Invoke(() =>
                {
                    progressBar1.Value = 100;
                    start.Enabled = true;
                    txtLog.AppendText("Download completed." + Environment.NewLine);
                });
            };
        }

        private void browse_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Manifest (*.txt;*.json)|*.txt;*.json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _manifestPath = dialog.FileName;
                txtLog.AppendText("Manifest loaded." + Environment.NewLine);

                var items = _manifestService.Load(_manifestPath);
                _totalBytes = items.Sum(x => x.Size);

                txtLog.AppendText($"Files: {items.Count}" + Environment.NewLine);
                txtLog.AppendText($"Total size: {_totalBytes / (1024 * 1024)} MB" + Environment.NewLine);
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (_manifestPath == null)
            {
                MessageBox.Show("Select manifest first");
                return;
            }

            using var dialog = new FolderBrowserDialog
            {
                Description = "Select download location"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            start.Enabled = false;
            progressBar1.Value = 0;

            _downloadService.Start(
                _manifestPath,
                _totalBytes,
                dialog.SelectedPath
            );
        }

     
    }
}
