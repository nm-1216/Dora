namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CoursewareMap : EntityBaseConfiguration<Courseware>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Courseware> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.CoursewareId });

            ///Properties
            builder.Property(b => b.Title).HasMaxLength(Constants.INT256).IsRequired();

            /// builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_Coursewares");

            ///Relationships
            //builder.HasMany(b => b.PaperQuestions).WithOne().HasForeignKey(b => b.PaperId);
            //builder.HasMany(b => b.PaperAnswers).WithOne().HasForeignKey(b => b.PaperId);

            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);

        }
    }
}