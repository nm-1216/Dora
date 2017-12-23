namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrganizationMap : EntityBaseConfiguration<Organization>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Organization> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.OrganizationId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();

            ///Table & Column Mappings
            builder.ToTable("School_Organization");

            ///Relationships
            //builder.HasMany(b => b.Permissions).WithOne(b => b.Module).HasForeignKey(b => b.ModuleId);
        }
    }
}

