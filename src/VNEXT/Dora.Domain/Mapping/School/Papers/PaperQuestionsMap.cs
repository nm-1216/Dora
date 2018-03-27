namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaperQuestionsMap : EntityBaseConfiguration<PaperQuestions>
    {
        public override void ConfigureDerived(EntityTypeBuilder<PaperQuestions> builder)
        {
            ///Primary Key
            builder.HasKey(b => new {b.PaperQuestionId});

            ///Properties
            builder.Property(b => b.Text).HasMaxLength(Constants.INT256).IsRequired();

            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_PaperQuestions");

            ///Relationships
            //builder.HasOne(b => b.Class).WithMany(b => b.Students).HasForeignKey(b => b.ClassId);
            builder.HasMany(b => b.PaperAnswerDetails).WithOne().HasForeignKey(b => b.PaperQuestionId);
        }
    }
}