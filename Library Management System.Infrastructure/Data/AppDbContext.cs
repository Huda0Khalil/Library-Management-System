using Microsoft.EntityFrameworkCore;
using Library_Management_System.Domain.Entities;
namespace Library_Management_System.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasMany(c => c.Categories)
                .WithMany(b => b.Books); 
        }
    }
}
