using System;

namespace Invenio.Data.Models
{
    public class Order
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string OderNumber { get; set; }

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
