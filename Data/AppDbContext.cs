using Events.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Events.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClientModel>? Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");

            protected override void OnModelCreating(ModelBuilder modelBuilder) {
                modelBuilder.Entity<ClientModel>().ToTable("Eventos");
            }
    }
}