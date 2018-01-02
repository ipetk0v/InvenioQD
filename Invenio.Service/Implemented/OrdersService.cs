using AutoMapper.QueryableExtensions;
using Invenio.Data;
using Invenio.Data.Models;
using Invenio.Service.Interfaces;
using Invenio.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Invenio.Service.Implemented
{
    public class OrdersService : IOrdersService
    {
        private readonly InvenioDbContext db;

        public OrdersService(InvenioDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, int CountToFinishOrder, string OderNumber, string customerUser)
        {
            var customerId = this.db.CustomerUser.Where(n => n.FullName == customerUser).Select(x => x.Id).FirstOrDefault();

            var order = new Order
            {
                Name = name,
                CountToFinishOrder = CountToFinishOrder,
                Status = false,
                OrderNumber = OderNumber,
                StartOrder = DateTime.UtcNow,
                CustomerUserId = customerId                
            };

            this.db.Order.Add(order);
            db.SaveChanges();
        }

        public IEnumerable<CustomerOrderModel> OrderById(string id)
         => this.db
            .Order
            .Where(u => u.CustomerUserId == id)
            .OrderByDescending(d => d.StartOrder)
            .ProjectTo<CustomerOrderModel>()
            .ToList();
    }
}
