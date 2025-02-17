using ContactsWebApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApp.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasKey(c => c.Id);
            modelBuilder.Entity<Contact>().HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
