using Microsoft.EntityFrameworkCore;
using TestRestAPI.Models;

namespace TestRestAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }
        public DbSet<Category> categories { get; set; }
    }
}
