//namespace Dora.Domain.Mapping.Application
//{
//    using Dora.Domain.Entities;
//    using Dora.Domain.Entities.Application;
//    using Dora.Infrastructure.Extensions;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    public class GroupMap : EntityTypeConfiguration<Group<string>>
//    {
//        public override void Map(EntityTypeBuilder<Group<string>> builder)
//        {
//            ///Primary Key
//            builder.HasKey(b => b.GroupId);

//            ///Properties
//            //builder.Property(b => b.GroupId).HasMaxLength(36);
//            builder.Property(b => b.GroupName).HasMaxLength(Constants.INT128);
//            builder.Property(b => b.Description).HasMaxLength(Constants.INT4000);

//            ///Table & Column Mappings
//            builder.ToTable("AspNetGroups");

//            ///Relationships
//            builder.HasMany(u => u.Users).WithOne().HasForeignKey(ur => ur.UserId);
//            builder.HasOne(b => b.Parent).WithMany(b => b.Childs).HasForeignKey(b => b.ParentId);
//        }
//    }
//}
