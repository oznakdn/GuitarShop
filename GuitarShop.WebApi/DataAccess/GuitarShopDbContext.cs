using GuitarShop.WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.WebApi.DataAccess
{
    public class GuitarShopDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;Database=GuitarShop;Trusted_Connection=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<CustomerContact>()
            .HasKey(x=>x.ContactID);
        }

        public DbSet<Guitar>Guitars{get;set;}
        public DbSet<Brand>Brands{get;set;}
        public DbSet<Customer>Customers{get;set;}
        public DbSet<CustomerContact>customerContacts{get;set;}
        public DbSet<Order>Orders{get;set;}

    }
}