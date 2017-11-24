using Invenio.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Invenio.Data
{
    public class InvenioDbContext : IdentityDbContext<User>
    {
        public DbSet<CustomerUser> CustomerUser { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Order> Order { get; set; }

        public InvenioDbContext(DbContextOptions<InvenioDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<CustomerUser>()
                .HasMany(cu => cu.Orders)
                .WithOne(o => o.CustomerUser)
                .HasForeignKey(cu => cu.CustomerUserId);

            builder
                .Entity<Report>()
                .HasOne(r => r.Order)
                .WithOne(o => o.Report)
                .HasForeignKey<Order>(o => o.ReportId);

            base.OnModelCreating(builder);
        }
    }
}
