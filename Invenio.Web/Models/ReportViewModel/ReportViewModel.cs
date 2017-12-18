using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.ReportViewModel
{
    public class ReportViewModel
    {
        [Required]
        [Display(Name="Text report")]
        public string TextReport { get; set; }

        public string OrderId { get; set; }
    }
}
