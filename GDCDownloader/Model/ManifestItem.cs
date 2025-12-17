namespace TcgaDownloader.Model
{
    public class ManifestItem
    {
        public string Id { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Md5 { get; set; } = string.Empty;
        public long Size { get; set; }
        public string State { get; set; } = string.Empty;
    }
}
