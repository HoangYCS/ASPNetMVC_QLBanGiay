using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnType("nvarchar(250)").
            IsRequired(true);

            builder.Property(x => x.Title).HasColumnType("nvarchar(250)").
            IsRequired(false);
            
        }
    }
}
