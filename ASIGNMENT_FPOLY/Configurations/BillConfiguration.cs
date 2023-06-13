using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status).HasColumnType("int").IsRequired(true);

            builder.Property(x => x.Note).HasColumnType("text").IsRequired(true);
            
            builder.Property(x => x.shipping_address).HasColumnType("nvarchar(250)").IsRequired(true);

            builder.HasOne(x => x.User).WithMany(y => y.Bill).
            HasForeignKey(c => c.UserId);
        }
    }
}
