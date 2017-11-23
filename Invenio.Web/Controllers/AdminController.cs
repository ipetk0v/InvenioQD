using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Controllers
{
    [Authorize(Roles = "ProductuionCordinator")]
    [Authorize(Roles = "RegionalManager")]
    [Authorize(Roles = "GeneralManager")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}