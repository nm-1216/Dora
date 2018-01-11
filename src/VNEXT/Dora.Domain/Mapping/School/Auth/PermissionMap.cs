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
            builder.HasKey(b => new { b.ModuleTypeId, b.RoleId });

            ///Properties


            ///Table & Column Mappings
            builder.ToTable("School_Permission");

            ///Relationships
            builder.HasOne(b => b.Role).WithMany(b=>b.Permissions).HasForeignKey(b => b.RoleId);
        }
    }
}
