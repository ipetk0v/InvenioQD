using Invenio.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [RegularExpression("[A-Z a-z]+", ErrorMessage = "Username must have only latters.")]
        public string Username { get; set; }

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

        [RegularExpression(@"\+\d{10,12}", ErrorMessage = "Phone start with a '+' sign and contain between 10 and 20 symbols.")]
        public string Phone { get; set; }
    }
}
