using Invenio.Service.Models;
using System.Collections.Generic;

namespace Invenio.Service.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<AllEmployeeModel> AllEmployee();

        IEnumerable<AllCustomerModel> AllCustomer();
    }
}
