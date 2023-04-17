using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<ProductPropertyDetails> ProductPropertyDetails { get; set; } 
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductCart> ProductsCart { get; set; } 
        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<ProductPropertyType> ProductPropertyTypes { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPropertyDetails>((builder =>
            {
                builder.HasNoKey();
                builder.ToView("View_ProductProperties");
            }));

            modelBuilder.Entity<ProductCart>((builder =>
            {
                builder.ToTable("ProductsCart");
            }));

            modelBuilder.Entity<Office>((builder =>
            {
                builder.ToTable("OfficeAddress");
            }));

            modelBuilder.Entity<ProductProperty>((builder =>
            {
                builder.ToTable("ProductProperties");
            }));
        }
    }
}