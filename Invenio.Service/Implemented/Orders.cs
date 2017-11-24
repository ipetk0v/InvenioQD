using Invenio.Data;
using Invenio.Data.Models;
using Invenio.Service.Interfaces;
using System;

namespace Invenio.Service.Implemented
{
    public class Orders : IOrders
    {
        private readonly InvenioDbContext db;

        public Orders(InvenioDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, int CountToFinishOrder, string OderNumber, CustomerUser user)
        {
            var order = new Order
            {
                Name = name,
                CountToFinishOrder = CountToFinishOrder,
                Status = false,
                OderNumber = OderNumber,
                StartOrder = DateTime.UtcNow,
                CustomerUser = user
            };

            this.db.Order.Add(order);
            db.SaveChanges();
        }
    }
}
