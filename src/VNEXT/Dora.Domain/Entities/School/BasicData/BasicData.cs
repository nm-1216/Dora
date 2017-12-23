//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="DataBase.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:48:47</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// 基础数据
    /// </summary>
    public partial class BasicData: BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets ID 
        /// </summary>
        public virtual int BasicDataId { get; set; }

        /// <summary>
        /// Gets or sets 基础数据类型 1=教师职称    2=课程性质    3=课程类别    4=实训方式    5=教育资源平台    6=适用教育层次    7=学制    8=授课方式    9=校区    10=公共教室楼号    11=校内实训基地    12=校内实训中心
        /// </summary>
        public virtual BasicDataType Type { get; set; }

        /// <summary>
        /// Gets or sets 基础数据名称 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 基础数据编码
        /// </summary>
        public virtual string Value { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 排序
        /// </summary>
        public virtual int Order { get; set; }

        /// <summary>
        /// Gets or sets 状态 
        /// </summary>
        public virtual BaseStatus Status { get; set; } 
        
        #endregion

    }
}





