using Invenio.Data.Models;

namespace Invenio.Service.Models
{
    public class AllCustomerModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string Manufacturing { get; set; }

        public string FullName { get; set; }

        public string Region { get; set; }

        public PositionType Position { get; set; }
    }
}
