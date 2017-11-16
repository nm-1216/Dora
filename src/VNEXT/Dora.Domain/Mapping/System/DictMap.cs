﻿namespace Dora.Domain.Mapping.System
{
    using Dora.Infrastructure.Features.Common;
    using Entities.System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DictMap : EntityBaseConfiguration<Dict>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Dict> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.Key, b.Type });

            ///Properties
            builder.Property(b => b.Value).HasMaxLength(Constants.INT256).IsRequired();

            ///Table & Column Mappings
            builder.ToTable("System_Dicts");
            builder.Property(b => b.Key).HasColumnName("Key");
            builder.Property(b => b.Value).HasColumnName("Value");
            builder.Property(b => b.Type).HasColumnName("Type");

            ///Relationships
        }
    }
}
