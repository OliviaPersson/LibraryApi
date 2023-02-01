using LibraryApi.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Helpers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<Book>? books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
    }
}
