namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Dora.Domain.Entities.School;

    public class PersonnelTrainingMap : EntityBaseConfiguration<PersonnelTraining>
    {
        public override void ConfigureDerived(EntityTypeBuilder<PersonnelTraining> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.PersonnelTrainingId });

            ///Properties
            builder.Property(b => b.LenOfSch).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.TraObj).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.GraReq).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Post).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.BasReq).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.OpiExp).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.EnrTar).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Year).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.CulProPath).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.MeeSumPath).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.AudName).HasMaxLength(Constants.INT256).IsRequired();
            
            ///Table & Column Mappings
            builder.ToTable("School_PersonnelTraining");

            ///Relationships
            builder.HasMany(b => b.PersonnelTrainingApprovals).WithOne(b=>b.PersonnelTraining).HasForeignKey(b => b.PersonnelTrainingId);
            builder.HasMany(b => b.PersonnelTrainingLogs).WithOne(b => b.PersonnelTraining).HasForeignKey(b => b.PersonnelTrainingId);
            builder.HasOne(b => b.Professional).WithMany().HasForeignKey(b => b.OrganizationId);

        }
    }
}
