using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnType("nvarchar(250)").
            IsRequired(true);
            builder.Property(x => x.Email).HasColumnType("nvarchar(250)").
            IsRequired(true);
            builder.Property(x => x.Address).HasColumnType("nvarchar(250)").
            IsRequired(true);

        }
    }
}
