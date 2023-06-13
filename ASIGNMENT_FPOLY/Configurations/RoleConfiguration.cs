using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RoleName).HasColumnType("nvarchar(250)").
            IsRequired(true);

            builder.Property(x => x.Description).HasColumnType("text").
            IsRequired(false);
        }
    }
}
