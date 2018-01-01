namespace Invenio.Data.Models
{
    public class Files
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public int Size { get; set; }

        public string ContentType { get; set; }

        public string FileExtension { get; set; }

        public string FileContent { get; set; }

        public byte[] FileBytes { get; set; }
    }
}
