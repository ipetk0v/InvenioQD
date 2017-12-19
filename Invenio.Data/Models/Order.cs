using System;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Data.Models
{
    public class Order
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderNumber { get; set; }

        [Range(1,int.MaxValue)]
        public int CountToFinishOrder { get; set; }

        public DateTime StartOrder { get; set; }

        public DateTime FinishOrder { get; set; }

        public bool Status { get; set; }

        public Report Report { get; set; }

        public string CustomerUserId { get; set; }

        public CustomerUser CustomerUser { get; set; }

        public string ReportId { get; set; }
    }
}
