using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UltraStock.Core.Models;

namespace UltraStock.Persistence.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");

            HasKey(c => c.Id);

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(c => c.Products)
                .WithRequired(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}