using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Data.Models
{
    public class CustomerUser : User
    {
        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string Manufacturing { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
