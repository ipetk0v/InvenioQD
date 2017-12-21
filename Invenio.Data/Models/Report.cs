using Invenio.Web.Helper;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Data.Models
{
    public class Report
    {
        public string Id { get; set; }

        [Required]
        [MinLength(DataAnnotationsAttributesHelper.ReportTextMinLength)]
        [MaxLength(DataAnnotationsAttributesHelper.ReportTextMaxLength)]
        public string ReportText { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }
    }
}
