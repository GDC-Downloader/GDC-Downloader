using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TcgaDownloader.Services
{
    public class DownloadService
    {
        public event Action<string>? OnOutput;
        public event Action<int>? OnProgress;

        public void Start(string manifestPath)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Users\azmeh\Desktop\Project\Tcga Downloader\gdc-client.exe",
                    Arguments = $"download -m \"{manifestPath}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = @"C:\Users\azmeh\Downloads"
                }
            };

            process.OutputDataReceived += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(e.Data)) return;

                OnOutput?.Invoke(e.Data);

                var match = Regex.Match(e.Data, @"(\d+)%");
                if (match.Success)
                    OnProgress?.Invoke(int.Parse(match.Groups[1].Value));
            };

            process.Start();
            process.BeginOutputReadLine();
        }
    }
}
