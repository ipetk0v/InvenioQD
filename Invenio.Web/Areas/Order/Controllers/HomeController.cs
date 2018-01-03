using Invenio.Data.Models;
using Invenio.Service.Interfaces;
using Invenio.Web.Areas.Order.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Invenio.Web.Areas.Order.Controllers
{
    [Authorize]
    [Area("Order")]
    public class HomeController : Controller
    {
        private readonly IOrdersService orders;
        private readonly UserManager<User> user;
        private readonly IUsersService users;

        public HomeController(IOrdersService orders, UserManager<User> user, IUsersService users)
        {
            this.orders = orders;
            this.user = user;
            this.users = users;
        }

        public IActionResult Index()
        {
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).FirstOrDefault();

            if (roles == "Customer")
            {
                var customerId = ((ClaimsIdentity)User.Identity).Claims.First().Value;
                return RedirectToAction("AllOrders", new { id = customerId });
            }

                return View(users.AllCustomer());
        }

        public IActionResult Create()
        {
            ViewBag.CustomerList = users.AllCustomer().Select(c => c.FullName).ToList();
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model, string customerId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.orders.Create(
                model.OrderName,
                model.CountToFinishOrder,
                model.OrderNumber,
                model.CustomerName);

            TempData["SuccessMessage"] = $"Order {model.OrderName} created successfully";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AllOrders(string id)
            => this.View(orders.OrderById(id));
    }
}