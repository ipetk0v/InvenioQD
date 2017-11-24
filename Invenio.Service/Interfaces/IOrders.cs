using Invenio.Data.Models;

namespace Invenio.Service.Interfaces
{
    public interface IOrders
    {
        void Create(string name, int CountToFinishOrder, string OderNumber, CustomerUser user);
    }
}
