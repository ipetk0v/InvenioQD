using Invenio.Data.Models;
using Invenio.Service.Models;
using System.Collections.Generic;

namespace Invenio.Service.Interfaces
{
    public interface IOrdersService
    {
        void Create(string name, int CountToFinishOrder, string OderNumber, string customerUser);

        IEnumerable<CustomerOrderModel> OrderById(string id);
    }
}
