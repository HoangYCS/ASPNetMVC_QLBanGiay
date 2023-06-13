using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASIGNMENT_FPOLY.Models;
namespace ASIGNMENT_FPOLY.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.IdUser);

            builder.Property(x => x.UserName).HasColumnType("nvarchar(30)").
            IsRequired(true);

            builder.Property(x => x.UserName).HasColumnType("nvarchar(30)").
            IsRequired(true);


            builder.HasOne(x => x.Role).WithMany(y => y.User).
            HasForeignKey(c => c.RoleId);

        }
    }
}
