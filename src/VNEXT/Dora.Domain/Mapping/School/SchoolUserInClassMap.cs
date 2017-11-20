namespace Dora.Domain.Mapping.System
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Entities.System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SchoolUserInClassMap : EntityBaseConfiguration<SchoolUserInClass>
    {
        public override void ConfigureDerived(EntityTypeBuilder<SchoolUserInClass> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.ClassId, b.UserId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_UserInClass");
            builder.Property(b => b.ClassId).HasColumnName("ClassId");
            builder.Property(b => b.UserId).HasColumnName("UserId");
            //builder.Property(b => b.Name).HasColumnName("Name");
            //builder.Property(b => b.InviteCode).HasColumnName("InviteCode");

            ///Relationships
            
        }
    }
}
