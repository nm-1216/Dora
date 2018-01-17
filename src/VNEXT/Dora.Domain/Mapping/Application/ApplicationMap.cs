//namespace Dora.Domain.Mapping.Application
//{
//    using Dora.Domain.Entities;
//    using Dora.Domain.Entities.Application;
//    using Dora.Infrastructure.Extensions;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    public class ApplicationMap : EntityTypeConfiguration<Application>
//    {
//        public override void Map(EntityTypeBuilder<Application> builder)
//        {
//            ///Primary Key
//            builder.HasKey(b => b.ApplicationId);

//            ///Properties
//            //builder.Property(b => b.ApplicationId).HasMaxLength(450);
//            builder.Property(b => b.ApplicationName).HasMaxLength(Constants.INT128);

//            ///Table & Column Mappings
//            builder.ToTable("AspNetApplications");
//            builder.Property(b => b.ApplicationId).HasColumnName("ApplicationId");
//            builder.Property(b => b.ApplicationName).HasColumnName("ApplicationName");

//            ///Relationships
//        }
//    }
//}
