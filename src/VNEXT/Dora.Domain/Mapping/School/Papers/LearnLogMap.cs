
namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LearnLogMap : EntityBaseConfiguration<LearnLog>
    {
        public override void ConfigureDerived(EntityTypeBuilder<LearnLog> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.LearnLogId });

            ///Properties
            //builder.Property(b => b.Title).HasMaxLength(Constants.INT256).IsRequired();

            /// builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_LearnLogs");

            ///Relationships
            

        }
    }
}