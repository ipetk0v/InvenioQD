using Invenio.Data;
using Invenio.Data.Models;
using Invenio.Service.Implemented;
using Invenio.Service.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Invenio.Test.Service
{
    public class OrderServiceTest
    {
        private readonly InvenioDbContext db;

        public OrderServiceTest()
        {
            db = FakeDatabase.InitialDatabase();
        }

        [Fact]
        public void CreateNewOrder()
        {
            // Arange
            var orderService = new OrdersService(db);

            // Act
            orderService.Create("Washing details", 1, "12313asdad", "BHTC");
            var result = db.Order.First();

            // Assert
            var expectName = "Washing details";
            var expectCountToFinishOrder = 1;
            var expectOderNumber = "12313asdad";

            Assert.Equal(expectName, result.Name);
            Assert.Equal(expectCountToFinishOrder, result.CountToFinishOrder);
            Assert.Equal(expectOderNumber, result.OderNumber);
        }

        [Fact]
        public void OrderById()
        {
            //Arange
            var orderService = new OrdersService(db);

            var customerUser = new CustomerUser { Id = "1", FullName = "BHTC" };
            var firstOrder = new Order { Id = "0", Name = "firstOrder", CustomerUserId = customerUser.Id, CustomerUser = customerUser };
            var secondOrder = new Order { Id = "1", Name = "secondOrder" };
            var thirdOrder = new Order { Id = "2", Name = "thirdOrder" };

            db.CustomerUser.Add(customerUser);
            db.Order.AddRange(firstOrder,secondOrder,thirdOrder);
            db.SaveChanges();

            //Act
            var resultCount = orderService.OrderById("1").Count();
            var firstResult = orderService.OrderById("1").First();

            //Assert
            var expected =
               new CustomerOrderModel
               {
                   Name = "firstOrder",
                   OrderId = "0",
                   CustomerUserId = "1"
               };
            var expectedResultCount = 1;

            Assert.Equal(expectedResultCount, resultCount);
            Assert.Equal(expected.Name, firstResult.Name);
            Assert.Equal(expected.OrderId, firstResult.OrderId);
            Assert.Equal(expected.CustomerUserId,firstResult.CustomerUserId);            
        }

    }
}
