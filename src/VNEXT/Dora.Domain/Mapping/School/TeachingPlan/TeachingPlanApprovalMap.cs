namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeachingPlanApprovalMap : EntityBaseConfiguration<TeachingPlanApproval>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TeachingPlanApproval> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeachingPlanApprovalId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TeachingPlanApproval");

            ///Relationships
            
        }
    }
}

