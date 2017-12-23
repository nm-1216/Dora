namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PersonnelTrainingApprovalMap : EntityBaseConfiguration<PersonnelTrainingApproval>
    {
        public override void ConfigureDerived(EntityTypeBuilder<PersonnelTrainingApproval> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.PersonnelTrainingApprovalId });

            ///Properties
            builder.Property(b => b.AudName).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Memo).HasMaxLength(Constants.INT4000).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_PersonnelTrainingApproval");

            ///Relationships
        }
    }
}
