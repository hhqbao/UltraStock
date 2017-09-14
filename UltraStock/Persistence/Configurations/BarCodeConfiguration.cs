using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UltraStock.Core.Models;

namespace UltraStock.Persistence.Configurations
{
    public class BarCodeConfiguration : EntityTypeConfiguration<BarCode>
    {
        public BarCodeConfiguration()
        {
            ToTable("BarCodes");

            HasKey(b => new { b.Id, b.ProductId });

            Property(b => b.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(b => b.Value)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}