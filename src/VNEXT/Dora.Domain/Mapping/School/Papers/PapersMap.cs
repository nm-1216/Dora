﻿namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PapersMap : EntityBaseConfiguration<Papers>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Papers> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.PaperId });

            ///Properties
            builder.Property(b => b.Title).HasMaxLength(Constants.INT256).IsRequired();

            /// builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_Papers");

            ///Relationships
            builder.HasMany(b => b.PaperQuestions).WithOne().HasForeignKey(b => b.PaperId);
            builder.HasMany(b => b.PaperAnswers).WithOne().HasForeignKey(b => b.PaperId);

            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);

        }
    }
}