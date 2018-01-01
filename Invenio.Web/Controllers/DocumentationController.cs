using Invenio.Service.Interfaces;
using Invenio.Service.Models;
using Invenio.Web.Models.DocumentationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Controllers
{
    [Authorize]
    public class DocumentationController : Controller
    {
        private readonly IFilesService files;

        public DocumentationController(IFilesService files)
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

            return Redirect("../../Documentation/Index");
        }
    }
}