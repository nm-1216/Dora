namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ModuleMap : EntityBaseConfiguration<Module>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Module> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.ModuleId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Ico).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Url).HasMaxLength(Constants.INT256).IsRequired();

            ///Table & Column Mappings
            builder.ToTable("School_Module");

            ///Relationships
            //builder.HasMany(b => b.Permissions).WithOne(b => b.Module).HasForeignKey(b => b.ModuleId);
        }
    }
}
