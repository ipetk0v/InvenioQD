using Invenio.Data;
using Invenio.Data.Models;
using Invenio.Service.Interfaces;
using Invenio.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Invenio.Service.Implemented
{
    public class UsersService : IUsersService
    {
        private readonly InvenioDbContext db;

        public UsersService(InvenioDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AllCustomerModel> AllCustomer()
        {
            return this.db
                 .CustomerUser
                 .Where(u => u.Position == PositionType.Customer)
                 .Select(u => new AllCustomerModel
                 {
                     Country = u.Country,
                     Email = u.Email,
                     FullName = u.FullName,
                     Id = u.Id,
                     Manufacturing = u.Manufacturing,
                     PhoneNumber = u.PhoneNumber,
                     Region = u.Region,
                     UserName = u.UserName,
                     Position = u.Position,
                     orderCount = u.Orders.Count
                 }).ToList();
        }

        public IEnumerable<AllEmployeeModel> AllEmployee()
        {
            return this.db
            .User
            .Where(u => u.Position != PositionType.Customer)
            .Select(u => new AllEmployeeModel
            {
                Email = u.Email,
                FullName = u.FullName,
                Id = u.Id,
                PhoneNumber = u.PhoneNumber,
                Region = u.Region,
                UserName = u.UserName,
                Position = u.Position
            }).ToList();
        }
    }
}
