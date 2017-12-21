using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Controllers
{
    [Authorize]
    public class DocumentationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
            => this.View();

        [HttpPost]
        public IActionResult Create(DocumentationController model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            return this.View();
        }
    }
}