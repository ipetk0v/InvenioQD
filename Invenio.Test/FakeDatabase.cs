using Invenio.Data;
using Microsoft.EntityFrameworkCore;
using System;
 
namespace Invenio.Test
{
    public static class FakeDatabase
    {
        public static InvenioDbContext InitialDatabase()
        {
            var options = new DbContextOptionsBuilder<InvenioDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var db = new InvenioDbContext(options);

            return db;
        }

    }
}
