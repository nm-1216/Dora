namespace Dora.Infrastructure.Features.Common
{
    using Domains;
    using Extensions;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class EntityBaseConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public override void Map(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.UpdateTime).IsRequired();
            builder.Property(x => x.CreateUser).IsRequired().HasMaxLength(64);
            builder.Property(x => x.UpdateUser).IsRequired().HasMaxLength(64);

            ConfigureDerived(builder);
        }

        public abstract void ConfigureDerived(EntityTypeBuilder<TEntity> builder);
    }
}
