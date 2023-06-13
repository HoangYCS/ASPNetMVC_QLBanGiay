using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName).HasColumnType("nvarchar(250)").
            IsRequired(true);

            builder.Property(x => x.Image).HasColumnType("image").
            IsRequired(false);

            builder.Property(x => x.Description).HasColumnType("text").
            IsRequired(false);

            builder.HasOne(x => x.Category).WithMany(y => y.Product).
            HasForeignKey(c => c.CategoryId);

            builder.HasOne(x => x.Brand).WithMany(y => y.Product).
            HasForeignKey(c => c.BrandId);

            builder.HasOne(x => x.Color).WithMany(y => y.Product).
            HasForeignKey(c => c.ColorId);

            builder.HasOne(x => x.Size).WithMany(y => y.Product).
            HasForeignKey(c => c.SizeId);
        }
    }
}
