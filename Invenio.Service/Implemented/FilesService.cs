using Invenio.Data;
using Invenio.Data.Models;
using Invenio.Service.Interfaces;
using Invenio.Service.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Invenio.Service.Implemented
{
    public class FilesService : IFilesService
    {
        private readonly InvenioDbContext db;

        public FilesService(InvenioDbContext db)
        {
            this.db = db;
        }

        public void UploadFileAsync(IFormFile file)
        {
            var files = new Files
            {
                ContentType = file.ContentType,
                FileName = file.FileName
            };

            using (var stream = new MemoryStream())
            {
                file.CopyToAsync(stream);
                files.FileBytes = stream.ToArray();

                byte[] buffer = new byte[4096];

                var dd = stream.ReadAsync(buffer, 0, 4096);
                var st = new StreamReader(stream);

                stream.Close();
            }


            db.Files.Add(files);
            db.SaveChanges();
        }

        public IEnumerable<FileModel> AllFiles()
        {
            return this.db
                .Files
                .Select(f => new FileModel
                {
                    ContentType = f.ContentType,
                    FileBytes = f.FileBytes,
                    FileContent = f.FileContent,
                    FileExtension = f.FileExtension,
                    FileName = f.FileName,
                    Size = f.Size,
                    Id = f.Id
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var file = this.db.Files.Where(f => f.Id == id).FirstOrDefault();

            this.db.Files.Remove(file);
            this.db.SaveChanges();
        }

        public FileModel CurrentFile(int id)
         => this.db
            .Files
            .Where(f => f.Id == id)
            .Select(f => new FileModel
            {
                Id = f.Id,
                ContentType = f.ContentType,
                FileBytes = f.FileBytes,
                FileContent = f.FileContent,
                FileExtension = f.FileExtension,
                FileName = f.FileName,
                Size = f.Size
            })
            .FirstOrDefault();
    }
}
