using Invenio.Service.Interfaces;
using Invenio.Service.Models;
using Invenio.Web.Areas.Documentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Areas.Documentation.Controllers
{
    [Authorize]
    [Area("Documentation")]
    public class HomeController : Controller
    {
        private readonly IFilesService files;

        public HomeController(IFilesService files)
        {
            this.files = files;
        }

        public IActionResult Index()
        {
            return View(files.AllFiles());
        }

        public IActionResult Upload()
            => this.View();

        [HttpPost]
        public IActionResult Upload(DocumentationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            files.UploadFileAsync(model.File);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string id)
            => this.View(files.CurrentFile(int.Parse(id)));

        [HttpPost]
        public IActionResult Delete(FileModel file)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            files.Delete(file.Id);

            return Redirect("../../Home/Index");
        }

        public IActionResult Download(string id)
        {
            var file = files.CurrentFile(int.Parse(id));

            return File(file.FileBytes, "application/x-msdownload", file.FileName);
        }
    }
}