using AutoMapper.QueryableExtensions;
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
                 .ProjectTo<AllCustomerModel>()
                 .ToList();
        }

        public IEnumerable<AllEmployeeModel> AllEmployee()
        {
            return this.db
            .User
            .Where(u => u.Position != PositionType.Customer)
            .ProjectTo<AllEmployeeModel>()
            .ToList();
        }
    }
}
