using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using UltraStock.Core.Models;
using UltraStock.Persistence.Configurations;

namespace UltraStock.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BarCode> BarCodes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new BarCodeConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            modelBuilder.Configurations.Add(new InvoiceDetailConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}