using Invenio.Data.Models;
using Invenio.Service.Models;
using System.Collections.Generic;

namespace Invenio.Service.Interfaces
{
    public interface IOrders
    {
        void Create(string name, int CountToFinishOrder, string OderNumber, string customerId);

        IEnumerable<CustomerOrderModel> OrderById(string id);
    }
}
