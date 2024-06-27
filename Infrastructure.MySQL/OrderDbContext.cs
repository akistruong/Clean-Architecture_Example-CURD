using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MySQL
{
    public class OrderDbContext : DbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=123456;database=ordermodule;Allow User Variables=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductID);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.OrderID);
            });
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(x => new { x.ProductID, x.OrderID });
                entity.HasOne(x => x.Order).WithMany(x=>x.Items).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x=>x.OrderID);  
                entity.HasOne(x => x.Product).WithMany(x=>x.OrderItems).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x=>x.ProductID);  
            });
        }
    }
}
