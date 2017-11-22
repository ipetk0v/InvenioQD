using Invenio.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Invenio.Data
{
    public class InvenioDbContext : IdentityDbContext<User>
    {
        public InvenioDbContext(DbContextOptions<InvenioDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
