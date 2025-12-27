using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using TcgaDownloader.Model;

namespace TcgaDownloader.Services
{
    public class ManifestService
    {
        public List<ManifestItem> Load(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Manifest file not found.", path);

            // خواندن تمام محتویات فایل
            var content = File.ReadAllText(path, Encoding.UTF8).TrimStart();

            // تشخیص فرمت
            if (content.StartsWith("[") || content.StartsWith("{"))
            {
                // JSON
                try
                {
                    return JsonSerializer.Deserialize<List<ManifestItem>>(content)
                           ?? new List<ManifestItem>();
                }
                catch (JsonException ex)
                {
                    throw new Exception("Failed to parse manifest JSON.", ex);
                }
            }
            else
            {
                // TSV یا CSV
                var lines = File.ReadAllLines(path);
                if (lines.Length < 2)
                    return new List<ManifestItem>();

                var items = new List<ManifestItem>();

                // خط اول header است
                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i].Trim();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // تشخیص delimiter: tab یا comma
                    string[] parts;
                    if (line.Contains('\t'))
                        parts = line.Split('\t');
                    else
                        parts = line.Split(',');

                    if (parts.Length >= 5)
                    {
                        if (!long.TryParse(parts[3], out var size))
                            size = 0;

                        items.Add(new ManifestItem
                        {
                            Id = parts[0],
                            FileName = parts[1],
                            Md5 = parts[2],
                            Size = size,
                            State = parts[4]
                        });
                    }
                }

                return items;
            }
        }
    }
}
