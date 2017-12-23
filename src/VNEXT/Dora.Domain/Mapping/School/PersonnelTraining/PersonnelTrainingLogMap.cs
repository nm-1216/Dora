namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PersonnelTrainingLogMap : EntityBaseConfiguration<PersonnelTrainingLog>
    {
        public override void ConfigureDerived(EntityTypeBuilder<PersonnelTrainingLog> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.PersonnelTrainingLogId });

            ///Properties
            builder.Property(b => b.Memo).HasMaxLength(Constants.INT4000).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_PersonnelTrainingLog");

            ///Relationships
        }
    }
}
