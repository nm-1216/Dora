//namespace Dora.Domain.Mapping.Application
//{
//    using Dora.Domain.Entities.Application;
//    using Dora.Infrastructure.Extensions;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    public class ActionInRoleMap : EntityTypeConfiguration<ActionInRole<string>>
//    {
//        public override void Map(EntityTypeBuilder<ActionInRole<string>> builder)
//        {
//            ///Primary Key
//            builder.HasKey(b => new { b.ActionId, b.RoleId });

//            ///Properties


//            ///Table & Column Mappings
//            builder.ToTable("AspNetActionInRoles");
//            builder.Property(b => b.ActionId).HasColumnName("ActionId");
//            builder.Property(b => b.RoleId).HasColumnName("RoleId");

//            ///Relationships

//        }
//    }
//}
