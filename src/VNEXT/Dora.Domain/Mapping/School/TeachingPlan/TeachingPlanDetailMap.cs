namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeachingPlanDetailMap : EntityBaseConfiguration<TeachingPlanDetail>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TeachingPlanDetail> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeachingPlanDetailId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TeachingPlanDetail");

            ///Relationships
            //builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);


        }
    }
}

