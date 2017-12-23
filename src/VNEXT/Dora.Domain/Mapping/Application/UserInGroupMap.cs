//namespace Dora.Domain.Mapping.Application
//{
//    using Dora.Domain.Entities.Application;
//    using Dora.Infrastructure.Extensions;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    public class UserInGroupMap : EntityTypeConfiguration<UserInGroup<string>>
//    {
//        public override void Map(EntityTypeBuilder<UserInGroup<string>> builder)
//        {
//            ///Primary Key
//            builder.HasKey(b => new { b.GroupId, b.UserId });

//            ///Properties


//            ///Table & Column Mappings
//            builder.ToTable("AspNetUserInGroups");

//            ///Relationships
//        }
//    }
//}
