using Invenio.Web.Helper;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(DataAnnotationsAttributesHelper.UserPasswordLength, 
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = DataAnnotationsAttributesHelper.UserPasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
