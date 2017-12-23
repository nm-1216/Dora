namespace Dora.Domain.Entities.Application
{
    using Dora.Infrastructure.Domains;


    /// <summary>
    /// 键值对字典表
    /// </summary>
    public class Dict : BaseEntity
    {
        /// <summary>
        /// 键值对(类型)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 键值对(建)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 键值对(值)
        /// </summary>
        public string Value { get; set; }
    }
}
