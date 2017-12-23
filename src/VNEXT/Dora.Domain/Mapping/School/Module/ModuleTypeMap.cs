namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ModuleTypeMap : EntityBaseConfiguration<ModuleType>
    {
        public override void ConfigureDerived(EntityTypeBuilder<ModuleType> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.ModuleTypeId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();

            ///Table & Column Mappings
            builder.ToTable("School_ModuleType");

            ///Relationships
            builder.HasMany(b => b.Modules).WithOne(b => b.ModuleType).HasForeignKey(b => b.ModuleTypeId);
        }
    }
}
