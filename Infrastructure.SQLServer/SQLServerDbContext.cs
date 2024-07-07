using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQLServer
{
    public class SQLServerDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Iventory> Iventories { get; set; }
        public SQLServerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-FTH3N2IO;Database=OrderExample;User Id=sa;Password=123456;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;");
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
                entity.HasOne(x => x.Order).WithMany(x => x.Items).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.OrderID).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(x => x.Product).WithMany(x => x.OrderItems).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Iventory>(entity =>
            {
                entity.HasKey(x => new { x.ID });
                entity.HasOne(x => x.Product).WithMany(x => x.Iventories).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade); ;
            });
        }
    }
}
