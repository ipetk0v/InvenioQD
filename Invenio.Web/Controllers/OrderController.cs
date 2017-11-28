using Invenio.Data.Models;
using Invenio.Service.Interfaces;
using Invenio.Web.Models.OrderViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrdersService orders;
        private readonly UserManager<User> user;
        private readonly IUsersService users;

        public OrderController(IOrdersService orders, UserManager<User> user, IUsersService users)
        {
            this.orders = orders;
            this.user = user;
            this.users = users;
        }

        public IActionResult Index()
        {
            return View(users.AllCustomer());
        }

        public IActionResult Create()
            => this.View();

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.orders.Create(
                model.Name,
                model.CountToFinishOrder,
                model.OderNumber,
                "27b23270-dd09-4dcd-bd09-210c6410d2ca");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AllOrders(string id)
            => this.View(orders.OrderById(id));
    }
}