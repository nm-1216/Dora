//namespace Dora.Domain.Mapping.Application
//{
//    using Dora.Domain.Entities;
//    using Dora.Domain.Entities.Application;
//    using Dora.Infrastructure.Extensions;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    public class ActionMap : EntityTypeConfiguration<Action<string>>
//    {
        
//        public override void Map(EntityTypeBuilder<Action<string>> builder)
//        {
            

//            ///Primary Key
//            builder.HasKey(b => b.ActionId);

//            ///Properties
//            //builder.Property(b => b.ActionId).HasMaxLength(36);
//            builder.Property(b => b.ActionCategory).HasMaxLength(Constants.INT64);
//            builder.Property(b => b.ActionName).HasMaxLength(Constants.INT128);
//            builder.Property(b => b.Description).HasMaxLength(Constants.INT512);

//            ///Table & Column Mappings
//            builder.ToTable("AspNetActions");
//            builder.Property(b => b.ActionId).HasColumnName("ActionId");
//            builder.Property(b => b.ActionCategory).HasColumnName("ActionCategory");
//            builder.Property(b => b.ActionName).HasColumnName("ActionName");
//            builder.Property(b => b.Description).HasColumnName("Description");
//            builder.Property(b => b.ApplicationId).HasColumnName("ApplicationId");
//            builder.Property(b => b.ParentId).HasColumnName("ParentId");

//            /// Relationships
//            builder.HasMany(b => b.Childs).WithOne().HasForeignKey(b => b.ParentId);
//            builder.HasMany(b => b.Roles).WithOne().HasForeignKey(b => b.ActionId);

//        }
//    }
//}
