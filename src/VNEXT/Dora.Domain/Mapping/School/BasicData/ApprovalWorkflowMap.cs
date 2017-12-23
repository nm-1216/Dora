namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApprovalWorkflowMap : EntityBaseConfiguration<ApprovalWorkflow>
    {
        public override void ConfigureDerived(EntityTypeBuilder<ApprovalWorkflow> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.ApprovalWorkflowId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Memo).HasMaxLength(Constants.INT4000).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_ApprovalWorkflow");

            ///Relationships
            builder.HasOne(b => b.Department).WithMany().HasForeignKey(b => b.OrganizationId);
            builder.HasOne(b => b.Role).WithMany().HasForeignKey(b => b.RoleId);
        }
    }
}
