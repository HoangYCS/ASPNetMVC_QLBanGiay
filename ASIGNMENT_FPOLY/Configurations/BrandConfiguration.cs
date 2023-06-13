using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnType("nvarchar(250)").
            IsRequired(true);
        }
    }
}
