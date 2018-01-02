using Invenio.Web.Helper;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(DataAnnotationsAttributesHelper.UserPasswordLength, 
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = DataAnnotationsAttributesHelper.UserPasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
