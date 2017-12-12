﻿using Invenio.Data.Models;
using Invenio.Service.Interfaces;
using Invenio.Web.Models.OrderViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
                model.OderNumber,
                // Добавяне на валидно ID ,а не име на CustomerName
                model.CustomerName);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AllOrders(string id)
            => this.View(orders.OrderById(id));
    }
}