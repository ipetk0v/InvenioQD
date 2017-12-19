using Invenio.Data;
using Invenio.Data.Models;
using Invenio.Service.Implemented;
using Invenio.Service.Models;
using System.Linq;
using Xunit;

namespace Invenio.Test.Service
{
    public class ReportServiceTest
    {
        private readonly InvenioDbContext db;

        public ReportServiceTest()
        {
            db = FakeDatabase.InitialDatabase();
        }

        [Fact]
        public void ShouldBeCreateReport()
        {
            //Arange
            var reportService = new ReportsService(db);

            //Act
            reportService.Create("test", "1");
            var result = this.db.Report.First();

            //Assert
            var expectReportText = "test";
            var expectOrderId = "1";
            Assert.Equal(expectReportText, result.ReportText);
            Assert.Equal(expectOrderId, result.OrderId);
        }

        [Fact]
        public void CheckIfThereIsAorderInTheReports()
        {
            //Arange
            var reportService = new ReportsService(db);

            var firstOrder = new Order { Id = "1", Name = "Test1" };
            var secondOrder = new Order { Id = "2", Name = "Test2" };
            var thirdOrder = new Order { Id = "3", Name = "Test3" };
            var firstReport = new Report { Id = "1", OrderId = firstOrder.Id , Order = firstOrder };
            var secondReport = new Report { Id = "2", OrderId = secondOrder.Id, Order = secondOrder };
            var thirdReport = new Report { Id = "3", OrderId = thirdOrder.Id, Order = thirdOrder };

            db.Order.AddRange(firstOrder, secondOrder, thirdOrder);
            db.Report.AddRange(firstReport, secondReport, thirdReport);
            db.SaveChanges();

            //Act
            var positiveResult = reportService.CheckForOrderId("1");
            var negativeResult = reportService.CheckForOrderId("11");

            //Assert
            var expectedPositive = true;
            var expectedNegative = false;
            Assert.Equal(expectedPositive, positiveResult);
            Assert.Equal(expectedNegative, negativeResult);
        }

        [Fact]
        public ReportModel ShouldBeReturnReportById()
        {
            //Arange
            var reportService = new ReportsService(db);

            this.db.Report.Add(new Report { Id = "0", OrderId = "1", ReportText = "FunTesting" });

            //Act
            var result = reportService.ReportById("1");

            //Assert
            return result;
        }

        [Fact]
        public void TestingOrderEntryWhenCheckReportById()
        {
            //Arange
            var reportService = new ReportsService(db);

            var firstOrder = new Order { Id = "0", Name = "Fun0" };
            var secondOrder = new Order { Id = "1", Name = "Fun1" };
            this.db.Report.Add(new Report { Id = "0", ReportText = "FunTesting0", OrderId = firstOrder.Id, Order = firstOrder });
            this.db.Report.Add(new Report { Id = "1", ReportText = "FunTesting1", OrderId = secondOrder.Id, Order = secondOrder });
            this.db.SaveChanges();

            //Act
            var asd = this.db.Report.First();
            var result = reportService.ReportById("0");

            //Assert
            var ReportTextExpected = "FunTesting0";
            var OrderIdExpected = "0";

            Assert.Equal(ReportTextExpected, result.ReportText);
            Assert.Equal(OrderIdExpected, result.OderId);
        }
    }
}
