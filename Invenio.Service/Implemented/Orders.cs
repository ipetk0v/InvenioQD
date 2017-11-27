using Invenio.Data;
using Invenio.Data.Models;
using Invenio.Service.Interfaces;
using Invenio.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Invenio.Service.Implemented
{
    public class Orders : IOrders
    {
        private readonly InvenioDbContext db;

        public Orders(InvenioDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, int CountToFinishOrder, string OderNumber, string customerId)
        {
            var order = new Order
            {
                Name = name,
                CountToFinishOrder = CountToFinishOrder,
                Status = false,
                OderNumber = OderNumber,
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
            .Select(o => new CustomerOrderModel
            {
                Name = o.Name,
                StartOrder = o.StartOrder,
                CountToFinishOrder = o.CountToFinishOrder,
                FinishOrder = o.FinishOrder,
                OderNumber = o.OderNumber,
                Status = o.Status
            }).ToList();
    }
}
