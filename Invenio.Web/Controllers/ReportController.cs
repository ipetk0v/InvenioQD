using Invenio.Service.Interfaces;
using Invenio.Web.Models.ReportViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Controllers
{
    [Authorize]
    public class ReportController : Controller
    { 
        private readonly IReportsService reports;

        public ReportController(IReportsService reports)
        {
            this.reports = reports;
        }

        public IActionResult Create(string orderId)
        {
            ViewBag.OrderId = orderId;
            return this.View();
        }


        [HttpPost]
        public IActionResult Create(ReportViewModel model)
        {
            this.reports.Create(model.TextReport, model.OrderId);
            return RedirectToAction(nameof(ReportById));
        }

        public IActionResult ReportById(string id)
        {
            if (!reports.CheckForOrderId(id))
            {
                return RedirectToAction("Index", "Order");
            }

            return this.View(reports.ReportById(id));
        }
    }
}
