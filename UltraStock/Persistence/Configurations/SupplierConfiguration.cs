using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UltraStock.Core.Models;

namespace UltraStock.Persistence.Configurations
{
    public class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            ToTable("Suppliers");

            HasKey(s => s.Id);

            Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.Address)
                .HasMaxLength(255);

            Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(s => s.Phone)
                .HasMaxLength(255);

            HasMany(s => s.Invoices)
                .WithRequired(i => i.Supplier)
                .HasForeignKey(i => i.SupplierId)
                .WillCascadeOnDelete(false);
        }
    }
}