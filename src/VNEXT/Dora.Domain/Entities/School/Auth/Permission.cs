namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// Permission 权限
    /// </summary>
    public partial class Permission : BaseEntity
    {
        public Permission() : base()
        {

        }

        public Permission(string moduleTypeId,string roleId) : base()
        {
            this.ModuleTypeId = moduleTypeId;
            this.RoleId = roleId;
        }
        #region Public Properties


        /// <summary>
        /// Gets or sets 模块表Id
        /// </summary>
        public virtual string ModuleTypeId { get; set; }

        /// <summary>
        /// Gets or sets 角色 
        /// </summary>
        public virtual string RoleId { get; set; }

        /// <summary>
        /// Gets or sets 权限 
        /// </summary>
        public virtual int Authority { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public virtual ModuleType ModuleType { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual SchoolRole Role { get; set; }
        #endregion

    }
}





