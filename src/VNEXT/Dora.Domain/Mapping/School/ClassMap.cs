namespace Dora.Domain.Mapping.System
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Entities.System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClassMap : EntityBaseConfiguration<Class>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Class> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.ClassId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();
            

            ///Table & Column Mappings
            builder.ToTable("School_Class");
            builder.Property(b => b.ClassId).HasColumnName("ClassId");
            builder.Property(b => b.CourseId).HasColumnName("CourseId");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.InviteCode).HasColumnName("InviteCode");

            ///Relationships
            builder.HasMany(b => b.User).WithOne(b => b.Class).HasForeignKey(b => b.ClassId);
        }
    }
}
