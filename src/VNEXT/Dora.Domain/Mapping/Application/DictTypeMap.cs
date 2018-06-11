namespace Dora.Domain.Mapping.Application
{
    using Dora.Infrastructure.Features.Common;
    using Entities.Application;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DictTypeMap : EntityBaseConfiguration<DictType>
    {
        public override void ConfigureDerived(EntityTypeBuilder<DictType> builder)
        {
            //Primary Key
            builder.HasKey(b => new { b.Id });

            //Properties
            //builder.Property(b => b.Value).HasMaxLength(Constants.INT256).IsRequired();

            //Table & Column Mappings
            builder.ToTable("System_DictTypes");
            //builder.Property(b => b.Key).HasColumnName("Key");
            //builder.Property(b => b.Value).HasColumnName("Value");
            //builder.Property(b => b.Type).HasColumnName("Type");

            //Relationships
            
        }
    }
}

