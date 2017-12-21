using Invenio.Web.Helper;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(DataAnnotationsAttributesHelper.UserFullNameMaxLength)]
        public string FullName { get; set; }

        [MaxLength(DataAnnotationsAttributesHelper.UserRegionMaxLength)]
        public string Region { get; set; }

        [Required]
        public PositionType Position { get; set; }
    }
}
