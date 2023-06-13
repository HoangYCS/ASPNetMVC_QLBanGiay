using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Cart).WithMany(y => y.CartDetail).
            HasForeignKey(c => c.UserId);

            builder.HasOne(x => x.Product).WithMany(y => y.CartDetail).
            HasForeignKey(c => c.ProductId);
        }
    }
}
