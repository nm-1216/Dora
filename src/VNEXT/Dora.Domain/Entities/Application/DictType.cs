namespace Dora.Domain.Entities.Application
{
    using Dora.Infrastructure.Domains;


    /// <summary>
    /// 键值对字典表
    /// </summary>
    public class DictType : BaseEntity
    {
        /// <summary>
        /// 分类主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string name { get; set; }
    }
}
