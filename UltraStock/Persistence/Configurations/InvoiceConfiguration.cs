using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UltraStock.Core.Models;

namespace UltraStock.Persistence.Configurations
{
    public class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfiguration()
        {
            ToTable("Invoices");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(i => i.Number)
                .IsRequired()
                .HasMaxLength(255);

            Property(i => i.DiscountRate)
                .IsOptional();

            HasMany(i => i.InvoiceDetails)
                .WithRequired(d => d.Invoice)
                .HasForeignKey(d => d.InvoiceId)
                .WillCascadeOnDelete(true);
        }
    }
}