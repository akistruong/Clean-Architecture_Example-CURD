using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.MySQL
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }

  

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Iventory> Iventories { get; set; }
      
              protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=123456;database=ordermodule;Allow User Variables=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductID);
                entity.HasData(DataSeed.Products.ProductInit());
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.OrderID);
            });
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(x => new { x.ProductID, x.OrderID });
                entity.HasOne(x => x.Order).WithMany(x=>x.Items).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x=>x.OrderID).OnDelete(DeleteBehavior.Cascade);  
                entity.HasOne(x => x.Product).WithMany(x=>x.OrderItems).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x=>x.ProductID).OnDelete(DeleteBehavior.Cascade);   
            });
            modelBuilder.Entity<Iventory>(entity =>
            {
                entity.HasKey(x => new { x.ID });
                entity.HasOne(x => x.Product).WithMany(x => x.Iventories).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade); ;
                entity.HasData(DataSeed.Iventories.IventoriesInit());
            });
        }
    }
}
