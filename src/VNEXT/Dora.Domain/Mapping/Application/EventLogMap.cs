//namespace Dora.Domain.Mapping.Application
//{
//    using Dora.Domain.Entities;
//    using Dora.Domain.Entities.Application;
//    using Dora.Infrastructure.Extensions;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    public class EventLogMap : EntityTypeConfiguration<EventLog>
//    {
//        public override void Map(EntityTypeBuilder<EventLog> builder)
//        {
//            ///Primary Key
//            builder.HasKey(b => b.LogID);

//            ///Properties
//            builder.Property(b => b.Exception).HasMaxLength(Constants.INT4000);
//            builder.Property(b => b.Level).HasMaxLength(Constants.INT128);
//            builder.Property(b => b.Logger).HasMaxLength(Constants.INT512);
//            builder.Property(b => b.Message).HasMaxLength(Constants.INT4000);
//            builder.Property(b => b.Thread).HasMaxLength(Constants.INT128);

//            ///Table & Column Mappings
//            builder.ToTable("AspNetEventLogs");
//            builder.Property(b => b.Exception).HasColumnName("Exception");
//            builder.Property(b => b.Level).HasColumnName("Level");
//            builder.Property(b => b.Logger).HasColumnName("Logger");
//            builder.Property(b => b.Message).HasColumnName("Message");
//            builder.Property(b => b.Thread).HasColumnName("Thread");
//            builder.Property(b => b.UserId).HasColumnName("UserId");
//            builder.Property(b => b.LogID).HasColumnName("LogID");
//            builder.Property(b => b.LogType).HasColumnName("LogType");
//            builder.Property(b => b.Date).HasColumnName("Date");

//            ///Relationships
//            builder.HasOne(u => u.ApplicationUser).WithMany(u => u.EventLogs).HasForeignKey(ur => ur.UserId);
//        }
//    }
//}
