using Invenio.Service.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Invenio.Service.Interfaces
{
    public interface IFilesService
    {
        void UploadFileAsync(IFormFile file);

        IEnumerable<FileModel> AllFiles();

        void Delete(int id);

        FileModel CurrentFile(int id);
    }
}
