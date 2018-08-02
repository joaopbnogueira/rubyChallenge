using System.Linq;
using Cabify.DataRepository.Entities.Configuration;
using Cabify.DataRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cabify.DataRepository
{
    public class StorefrontContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public StorefrontContext(DbContextOptions<StorefrontContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());            
            modelBuilder.ApplyConfiguration(new CartProductConfiguration());

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            {
                property.Relational().ColumnType = "decimal(18, 6)";
            }
        }
    }
}
