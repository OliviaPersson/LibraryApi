using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Helpers
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<BookItem> mytable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
    }
}
