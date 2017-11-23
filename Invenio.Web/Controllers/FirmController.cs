using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Controllers
{
    [Authorize]
    public class FirmController : Controller
    {
        public IActionResult Documentation()
        {
            return View();
        }
    }
}