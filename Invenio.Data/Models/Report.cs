namespace Invenio.Data.Models
{
    public class Report
    {
        public string Id { get; set; }

        public string ReportText { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }
    }
}
