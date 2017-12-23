namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClassMap : EntityBaseConfiguration<Class>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Class> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.ClassId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_Classes");

            ///Relationships
            builder.HasOne(b => b.Department).WithMany().HasForeignKey(b => b.DepID);
            builder.HasOne(b => b.Professional).WithMany().HasForeignKey(b => b.SpeID);
            builder.HasOne(b => b.PersonnelTraining).WithMany().HasForeignKey(b => b.PersonnelTrainingId);
        }
    }
}
