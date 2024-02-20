using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class StoreContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Product> Product { get; set; }

    public StoreContext(DbContextOptions options) : base(options)
    {
        
    }
}