using Invenio.Web.Infrastructures.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.DocumentationViewModels
{
    public class DocumentationViewModel
    {
        public string Caption { set; get; }

        public string Description { set; get; }

        [Required]
        [ValidationFileName]
        public IFormFile File { set; get; }
    }
}
