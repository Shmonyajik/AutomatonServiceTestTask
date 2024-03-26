
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class RepositoryContext : DbContext
    {

        public DbSet<Keeper>? Keepers { get; set; }
        public DbSet<Product>? Products { get; set; }

        public DbSet<Store>? Stores { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}
