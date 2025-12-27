using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace TcgaDownloader.Services
{
    public class DownloadService
    {
        public event Action<string>? OnOutput;
        public event Action<int>? OnProgress;
        public event Action? OnCompleted;

        private long _totalBytes;
        private long _downloadedBytes;

        public void Start(string manifestPath, long totalBytes, string outputDir)
        {
            _totalBytes = totalBytes;
            _downloadedBytes = 0;

            var gdcPath = Path.Combine(
                AppContext.BaseDirectory,
                "Tools",
                "gdc-client.exe"
            );

            if (!File.Exists(gdcPath))
                throw new FileNotFoundException("gdc-client.exe not found", gdcPath);

            var psi = new ProcessStartInfo
            {
                FileName = gdcPath,
                Arguments = $"download -m \"{manifestPath}\" -d \"{outputDir}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = new Process
            {
                StartInfo = psi,
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += OnData;
            process.ErrorDataReceived += OnData;

            process.Exited += (s, e) =>
            {
                OnCompleted?.Invoke();
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        private void OnData(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Data))
                return;

            OnOutput?.Invoke(e.Data);

            // مثال خروجی: "13.6 MB / 136.7 MB"
            var match = Regex.Match(e.Data, @"([\d\.]+)\s*MB\s*/");

            if (match.Success && _totalBytes > 0)
            {
                double mb = double.Parse(
                    match.Groups[1].Value,
                    CultureInfo.InvariantCulture
                );

                _downloadedBytes = (long)(mb * 1024 * 1024);

                int percent = (int)((_downloadedBytes * 100) / _totalBytes);
                OnProgress?.Invoke(Math.Min(100, Math.Max(0, percent)));
            }
        }
    }
}
