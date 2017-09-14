using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UltraStock.Core.Models;

namespace UltraStock.Persistence.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Products");

            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(p => p.BarCodes)
                .WithRequired(b => b.Product)
                .HasForeignKey(b => b.ProductId)
                .WillCascadeOnDelete(true);

            HasMany(p => p.InvoiceDetails)
                .WithRequired(d => d.Product)
                .HasForeignKey(d => d.ProductId)
                .WillCascadeOnDelete(false);
        }
    }
}