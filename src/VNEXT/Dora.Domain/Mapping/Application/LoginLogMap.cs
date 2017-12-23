//namespace Dora.Domain.Mapping.Application
//{
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;
//    using Dora.Domain.Entities.Application;
//    using Dora.Infrastructure.Extensions;
//    using Dora.Domain.Entities;

//    public class LoginLogMap : EntityTypeConfiguration<LoginLog>
//    {
//        public override void Map(EntityTypeBuilder<LoginLog> builder)
//        {
//            ///Primary Key
//            builder.HasKey(b => b.Id);

//            ///Properties
//            builder.Property(b => b.IP).HasMaxLength(Constants.INT128).IsRequired();
//            builder.Property(b => b.Description).HasMaxLength(Constants.INT4000).IsRequired();

//            ///Table & Column Mappings
//            builder.ToTable("AspNetLoginLogs");
//            builder.Property(b => b.Id).HasColumnName("Id");
//            builder.Property(b => b.UserId).HasColumnName("UserId");
//            builder.Property(b => b.IP).HasColumnName("IP");
//            builder.Property(b => b.Description).HasColumnName("Description");
//            builder.Property(b => b.AddTime).HasColumnName("AddTime");

//            ///Relationships
//            builder.HasOne(u => u.ApplicationUser).WithMany(u => u.LoginLogs).HasForeignKey(ur => ur.UserId);
//        }
//    }
//}
