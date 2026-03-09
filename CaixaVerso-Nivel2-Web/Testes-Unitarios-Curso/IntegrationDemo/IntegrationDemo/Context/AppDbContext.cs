using IntegrationDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegrationDemo.Context
{
    public class AppDbContext : DbContext
    { 
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { 
            
        }
    }
}
