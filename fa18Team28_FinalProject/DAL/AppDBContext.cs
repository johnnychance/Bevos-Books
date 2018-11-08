using fa18Team28_FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace fa18Team28_FinalProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //You need one db set for each model class
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}