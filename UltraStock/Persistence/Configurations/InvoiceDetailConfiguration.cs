using System.Data.Entity.ModelConfiguration;
using UltraStock.Core.Models;

namespace UltraStock.Persistence.Configurations
{
    public class InvoiceDetailConfiguration : EntityTypeConfiguration<InvoiceDetail>
    {
        public InvoiceDetailConfiguration()
        {
            ToTable("InvoiceDetails");

            HasKey(i => new { i.InvoiceId, i.ProductId });

            Property(i => i.DiscountRate)
                .IsOptional();
        }
    }
}