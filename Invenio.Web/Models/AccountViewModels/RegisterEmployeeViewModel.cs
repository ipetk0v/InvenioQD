using Invenio.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.AccountViewModels
{
    public class RegisterEmployeeViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public PositionType Position { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [RegularExpression(@"\+\d{10,12}", ErrorMessage = "Phone start with a '+' sign and contain between 10 and 20 symbols.")]
        public string Phone { get; set; }
    }
}
