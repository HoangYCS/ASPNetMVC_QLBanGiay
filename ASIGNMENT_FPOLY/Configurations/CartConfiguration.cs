using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Descripttion).HasColumnType("text").
            IsRequired(true);
        }
    }
}
