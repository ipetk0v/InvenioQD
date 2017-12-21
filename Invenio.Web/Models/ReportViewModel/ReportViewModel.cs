using Invenio.Web.Helper;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.ReportViewModel
{
    public class ReportViewModel
    {
        [Required]
        [MinLength(DataAnnotationsAttributesHelper.ReportTextMinLength)]
        [MaxLength(DataAnnotationsAttributesHelper.ReportTextMaxLength)]
        [Display(Name="Text report")]
        public string TextReport { get; set; }

        public string OrderId { get; set; }
    }
}
