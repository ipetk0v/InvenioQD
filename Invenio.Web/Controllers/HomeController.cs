using Invenio.Service.Interfaces;
using Invenio.Service.Models;
using Invenio.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Invenio.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUsers users;

        public HomeController(IUsers users)
        {
            this.users = users;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            if (User.IsInRole("Customer"))
            {
                return View(users.AllEmployee());
            }

            return View(users.AllCustomer());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
