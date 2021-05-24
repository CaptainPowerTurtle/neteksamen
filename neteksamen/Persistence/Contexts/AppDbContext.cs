using Microsoft.EntityFrameworkCore;
using neteksamen.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neteksamen.model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.ID);
            builder.Entity<Category>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Entity<Category>().Property(p => p.Desc).IsRequired().HasMaxLength(100);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category { ID = 100, Name = "Hardware" , Desc = "Super Nice"},
                new Category { ID = 200, Name = "Software", Desc = "I Cry" }
            );

            builder.Entity<Supplier>().ToTable("Suppliers");
            builder.Entity<Supplier>().HasKey(p => p.ID);
            builder.Entity<Supplier>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Supplier>().Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Entity<Supplier>().Property(p => p.Address).IsRequired();
            builder.Entity<Supplier>().Property(p => p.ZipCode).IsRequired();
            builder.Entity<Supplier>().Property(p => p.ContactPerson).IsRequired();
            builder.Entity<Supplier>().Property(p => p.Email).IsRequired();
            builder.Entity<Supplier>().Property(p => p.Phone).IsRequired();
            builder.Entity<Supplier>().HasMany(p => p.Products).WithOne(p => p.Supplier).HasForeignKey(p => p.SupplierId);

            builder.Entity<Supplier>().HasData
            (
                new Supplier { ID = 100, Name = "Super Supplier", Address = "Slagelse", ZipCode = "4200", ContactPerson = "Morten", Email = "morten@super.dk", Phone = "1234567890" },
                new Supplier { ID = 200, Name = "Small Supplier", Address = "Slagelse", ZipCode = "4200", ContactPerson = "Morten", Email = "morten@super.dk", Phone = "1234567890" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.ID);
            builder.Entity<Product>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Desc).IsRequired().HasMaxLength(100);
            builder.Entity<Product>().Property(p => p.AmountInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
            builder.Entity<Product>().Property(p => p.Price).IsRequired();
            builder.Entity<Product>().Property(p => p.Stock).IsRequired();

            builder.Entity<Product>().HasData
    (
        new Product
        {
            ID = 100,
            Name = "Apple",
            Desc = "Juicy Apple",
            AmountInPackage = 6,
            UnitOfMeasurement = EUnitOfMeasurement.Amount,
            Price = 20,
            Stock = 200,
            CategoryId = 100,
            SupplierId = 100,
        },
        new Product
        {
            ID = 101,
            Name = "Milk",
            Desc = "Milk from the farm",
            AmountInPackage = 2,
            UnitOfMeasurement = EUnitOfMeasurement.Liter,
            Price = 7,
            Stock = 50,
            CategoryId = 200,
            SupplierId = 200,
        }
    );
        }
    }
}
