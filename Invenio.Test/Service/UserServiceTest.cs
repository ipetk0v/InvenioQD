using Invenio.Data;
using Invenio.Data.Models;
using Invenio.Service.Implemented;
using Invenio.Service.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Invenio.Test.Service
{
    public class UserServiceTest
    {
        private readonly InvenioDbContext db;

        public UserServiceTest()
        {
            db = FakeDatabase.InitialDatabase();
        }

        [Fact]
        public void GetAllCustomerFromDb()
        {
            // Arange
            var userService = new UsersService(db);

            var firstCustomer = new CustomerUser { Id = "0", FullName = "BHTC" };
            var secondCustomer = new CustomerUser { Id = "1", FullName = "FischerTech" };
            var thirdCustomer = new CustomerUser { Id = "2", FullName = "InnoTape" };

            db.CustomerUser.AddRange(firstCustomer, secondCustomer, thirdCustomer);
            db.SaveChanges();

            // Act
            var result = userService.AllCustomer();

            // Assert
            var expectedCount = 3;
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public void GetAllEmpliyeeFromDb()
        {
            // Arange
            var userService = new UsersService(db);

            var firstEmployee = new User { Id = "0", FullName = "TeamLead", Position = PositionType.TeamLeader };
            var secondEmployee = new User { Id = "1", FullName = "ProductionCordinator", Position = PositionType.ProductionCordinator };
            var thirdEmployee = new User { Id = "2", FullName = "GeneralManager", Position = PositionType.GeneralManager };

            db.User.AddRange(firstEmployee, secondEmployee, thirdEmployee);
            db.SaveChanges();

            // Act
            var result = userService.AllEmployee();

            // Assert
            var expectedCount = 3;
            Assert.Equal(expectedCount, result.Count());
        }
    }
}
