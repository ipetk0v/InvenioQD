using Invenio.Service.Interfaces;
using Invenio.Web.Areas.Report.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Areas.Report.Controllers
{
    [Authorize]
    [Area("Report")]
    public class HomeController : Controller
    { 
        private readonly IReportsService reports;

        public HomeController(IReportsService reports)
        {
            this.reports = reports;
        }

        public IActionResult Create(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return this.View();
        }


        [HttpPost]
        public IActionResult Create(ReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.reports.Create(model.TextReport, model.OrderId);

            TempData["SuccessMessage"] = $"Report created successfully";
            return RedirectToAction(nameof(ReportById));
        }

        public IActionResult ReportById(string id)
        {
            var successMessage = TempData["SuccessMessage"];

            if (!reports.CheckForOrderId(id))
            {
                if (successMessage == null)
                {
                    TempData["AlertMessage"] = "The report you want to see does not exist!";
                }

                return Redirect("../../../order/home/index");
            }

            return this.View(reports.ReportById(id));
        }
    }
}
