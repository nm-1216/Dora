namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaperAnswerDetailsMap : EntityBaseConfiguration<PaperAnswerDetails>
    {
        public override void ConfigureDerived(EntityTypeBuilder<PaperAnswerDetails> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.PaperAnswerId,b.PaperQuestionId});

            ///Table & Column Mappings
            builder.ToTable("School_PaperAnswerDetails");

            ///Relationships
            //builder.HasOne(b => b.Class).WithMany(b => b.Students).HasForeignKey(b => b.ClassId);
            //builder.HasOne(b => b.SchoolUser).WithOne(b => b.Student).HasForeignKey<Student>(b => b.StudentId);
        }
    }
}