namespace Dora.Domain.Mapping.System
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Entities.System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SchoolUserMap : EntityBaseConfiguration<SchoolUser>
    {
        public override void ConfigureDerived(EntityTypeBuilder<SchoolUser> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.UserId });

            ///Properties
            builder.Property(b => b.UserType).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.WxOpenId).HasMaxLength(Constants.INT256);
            builder.Property(b => b.WxName).HasMaxLength(Constants.INT256);
            builder.Property(b => b.WxAvatar).HasMaxLength(Constants.INT256);

            ///Table & Column Mappings
            builder.ToTable("School_User");
            builder.Property(b => b.UserId).HasColumnName("UserId");
            builder.Property(b => b.UserType).HasColumnName("UserType");
            builder.Property(b => b.WxOpenId).HasColumnName("WxOpenId");
            builder.Property(b => b.WxName).HasColumnName("WxName");
            builder.Property(b => b.WxAvatar).HasColumnName("WxAvatar");

            ///Relationships
            builder.HasMany(b => b.Classes).WithOne(b => b.User).HasForeignKey(b => b.UserId);

        }
    }
}
