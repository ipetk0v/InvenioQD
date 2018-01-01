using System.ComponentModel.DataAnnotations;

namespace Invenio.Service.Models
{
    public class FileModel
    {
        public int Id { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        public int Size { get; set; }

        [Display(Name = "Content Type")]
        public string ContentType { get; set; }

        [Display(Name = "File Extension")]
        public string FileExtension { get; set; }

        [Display(Name = "File Content")]
        public string FileContent { get; set; }

        public byte[] FileBytes { get; set; }
    }
}
