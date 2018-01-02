using Invenio.Data;
using Invenio.Data.Models;
using Invenio.Service.Interfaces;
using Invenio.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Invenio.Service.Implemented
{
    public class ReportsService : IReportsService
    {
        private readonly InvenioDbContext db;

        public ReportsService(InvenioDbContext db)
        {
            this.db = db;
        }

        public bool CheckForOrderId(string orderId)
         => this.db.Report.Any(x => x.OrderId == orderId);

        public void Create(string ReportText, string orderId)
        {
            var a = this.db.Report.Where(o => o.OrderId == orderId).ToList();

            db.Report.RemoveRange(a);

            this.db.Add(new Report
            {
                ReportText = ReportText,
                OrderId = orderId
            });
            db.SaveChanges();
        }

        public ReportModel ReportById(string id)
        {
            return this.db
                .Report
                .Where(u => u.OrderId == id)
                .Select(r => new ReportModel
                {
                    ReportText = r.ReportText,
                    OderId = r.OrderId
                })
                .FirstOrDefault();
        }
    }
}
