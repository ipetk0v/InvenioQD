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

        public void Create(string ReportText, string orderId)
        {
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
                    ReportText = r.ReportText
                })
                .FirstOrDefault();
        }
    }
}
