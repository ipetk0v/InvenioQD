using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }
    }
}
