using Invenio.Data.Models;
using Invenio.Web.Helper;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.AccountViewModels
{
    public class RegisterEmployeeViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [MinLength(DataAnnotationsAttributesHelper.UserFullNameMinLength)]
        [MaxLength(DataAnnotationsAttributesHelper.UserFullNameMaxLength)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(DataAnnotationsAttributesHelper.UserPasswordLength, 
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = DataAnnotationsAttributesHelper.UserPasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public PositionType Position { get; set; }

        [MaxLength(DataAnnotationsAttributesHelper.UserRegionMaxLength)]
        public string Region { get; set; }

        [RegularExpression(@"\+\d{10,12}", ErrorMessage = "Phone start with a '+' sign and contain between 10 and 20 symbols.")]
        public string Phone { get; set; }
    }
}
