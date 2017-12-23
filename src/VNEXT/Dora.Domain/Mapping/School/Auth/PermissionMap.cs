namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PermissionMap : EntityBaseConfiguration<Permission>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Permission> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.PermissionId });

            ///Properties


            ///Table & Column Mappings
            builder.ToTable("School_Permission");

            ///Relationships
            builder.HasOne(b => b.Role).WithMany().HasForeignKey(b => b.RoleId);
        }
    }
}
