using System.ComponentModel.DataAnnotations;

namespace Invenio.Data.Models
{
    public class Report
    {
        public string Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(5000)]
        public string ReportText { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }
    }
}
