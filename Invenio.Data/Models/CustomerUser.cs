using Invenio.Web.Helper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Data.Models
{
    public class CustomerUser : User
    {
        [MaxLength(DataAnnotationsAttributesHelper.CustomerUerCountryMaxLength)]
        public string Country { get; set; }

        [MaxLength(DataAnnotationsAttributesHelper.CustomerUserManufacturingMaxLength)]
        public string Manufacturing { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
