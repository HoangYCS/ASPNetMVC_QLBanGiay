using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class SupplierProductConfiguration : IEntityTypeConfiguration<SupplierProduct>
    {
        public void Configure(EntityTypeBuilder<SupplierProduct> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(y => y.SupplierProduct).
            HasForeignKey(c => c.ProductId);

            builder.HasOne(x => x.Supplier).WithMany(y => y.SupplierProduct).
            HasForeignKey(c => c.SupplierId);
        }
    }
}
