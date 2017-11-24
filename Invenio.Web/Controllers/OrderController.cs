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
        private readonly IOrders orders;
        private readonly UserManager<User> user;

        public OrderController(IOrders orders, UserManager<User> user)
        {
            this.orders = orders;
            this.user = user;
        }

        public IActionResult Index()
        {
            return View();
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
                model.Customer);

            return RedirectToAction(nameof(Index));
        }
    }
}