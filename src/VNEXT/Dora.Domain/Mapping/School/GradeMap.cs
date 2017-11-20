namespace Dora.Domain.Mapping.System
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Entities.System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GradeMap : EntityBaseConfiguration<Grade>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Grade> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.GradeId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();
            

            ///Table & Column Mappings
            builder.ToTable("School_Grade");
            builder.Property(b => b.GradeId).HasColumnName("GradeId");
            //builder.Property(b => b.CourseId).HasColumnName("CourseId");
            builder.Property(b => b.Name).HasColumnName("Name");
            //builder.Property(b => b.InviteCode).HasColumnName("InviteCode");

            ///Relationships
        }
    }
}
