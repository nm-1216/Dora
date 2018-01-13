namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;
    using System;

    public partial class Infomation : BaseEntity
    {
        public Infomation()
        {
            this.InfomationId = Guid.NewGuid().ToString();
        }

        public virtual InfomationType InfomationType { get; set; }

        public virtual string InfomationId { get; set; }

        public virtual string Title { get; set; }

        public virtual string Summary { get; set; }

        public virtual string Content { get; set; }
    }
}
