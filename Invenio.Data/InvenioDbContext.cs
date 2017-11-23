using Invenio.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Invenio.Data
{
    public class InvenioDbContext : IdentityDbContext<User>
    {
        public DbSet<CustomerUser> CustomerUser { get; set; }
        public DbSet<User> User { get; set; }

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
