using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Infrastructures.Attributes
{
    public class ValidationFileNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = (IFormFile)value;

            var fileName = file.FileName.Substring(file.FileName.Length - 4);                      

            if (fileName != "xlsx" && fileName != "docx" && fileName != "pptx" && fileName != ".pdf")
            {
                return new ValidationResult(ErrorMessage = "Allowed file extensions: Xlsx, Docx, PPT, pdf");
            }

            return ValidationResult.Success;
        }
    }
}
