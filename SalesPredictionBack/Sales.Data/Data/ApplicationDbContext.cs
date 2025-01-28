using Microsoft.EntityFrameworkCore;
using Sales.Data.Entities;

namespace Sales.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetailsEntity>()
                .HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<OrderDetailsEntity>()
                .ToTable("OrderDetails", "Sales");
            modelBuilder.Entity<EmployeesEntity>()
                .ToTable("Employees", "HR");
            modelBuilder.Entity<OrdersEntity>()
                .ToTable("Orders", "Sales");
            modelBuilder.Entity<ShippersEntity>()
                .ToTable("Shippers", "Sales");
            modelBuilder.Entity<ProductsEntity>()
                .ToTable("Products", "Production");
            modelBuilder.Entity<CustomersEntity>()
                .ToTable("Customers", "Sales");
        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<EmployeesEntity> Employees { get; set; }
        public DbSet<CustomersEntity> Customers { get; set; }
        public DbSet<OrderDetailsEntity> OrderDetails { get; set; }
        public DbSet<OrdersEntity> Orders { get; set; }
        public DbSet<ProductsEntity> Products { get; set; }
        public DbSet<ShippersEntity> Shippers { get; set; }
        public DbSet<SuppliersEntity> Suppliers { get; set; }
    }
}
