using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class BillDetaiConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantily).HasColumnType("int").
            IsRequired(true);

            builder.HasOne(x => x.Bill).WithMany(y => y.BillDetail).
            HasForeignKey(c => c.BillId);

            builder.HasOne(x => x.Product).WithMany(y => y.BillDetail).
            HasForeignKey(c => c.ProductId);

        }
    }
}
