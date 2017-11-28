using Invenio.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Controllers
{
    public class ReportController : Controller
    { 
        private readonly IReportsService reports;

        public ReportController(IReportsService reports)
        {
            this.reports = reports;
        }

        public IActionResult ReportById(string id)
        {
            return this.View(reports.ReportById(id));
        }

        public IActionResult Create()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult Create(string reportText, string orderId)
        {
            this.reports.Create(reportText, orderId);

            return RedirectToAction(nameof(Create));
        }
    }
}
