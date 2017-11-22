using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LasName { get; set; }

        public PositionType Position { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [MaxLength(100)]
        public string Manufacturing { get; set; }
    }
}
