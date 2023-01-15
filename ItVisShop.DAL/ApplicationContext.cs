using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using ItVisShop.Domain.Enum;
using ItVisShop.Domain.Helpers;

namespace ItVisShop.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<ProductProperty> ProductProperties { get; set; } 
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductProperty>((builder =>
            {
                builder.HasNoKey();
                builder.ToView("View_ProductProperties");
            }));

        //    modelBuilder.Entity<User>(builder =>
        //    {
        //        builder.HasData(new User
        //        {
        //            UserId = -1,
        //            Name = "Andrey",
        //            Surname = "Android",
        //            Phone = "89277775577",
        //            Email = "ggg.admin@gmail.com",
        //            Password = HashPasswordHelper.HashPassword("admin"),
        //            Role = Role.Admin
        //        });

        //        builder.ToTable("Users").HasKey(x => x.UserId);

        //        builder.Property(x => x.UserId).ValueGeneratedOnAdd();
        //    });    
        }
    }
}