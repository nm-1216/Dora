//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PraTraEqu.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:52:46</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// TrainingLabDevice 实训设备信息表
    /// </summary>
    public partial class TrainingLabDevice : BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets 设备编号 
        /// </summary>
        public virtual string TrainingLabDeviceId { get; set; }


        /// <summary>
        /// Gets or sets 实训室基本信息表 
        /// </summary>
        public virtual string TrainingLabId { get; set; }

        /// <summary>
        /// Gets or sets 设备名称 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 设备价值 
        /// </summary>
        public virtual decimal? Value { get; set; } 
        
        /// <summary>
        /// Gets or sets Status 正常    待维修    停用    报废
        /// </summary>
        public virtual TrainingLabDeviceStatus Status { get; set; }

        /// <summary>
        /// 实训室
        /// </summary>
        public virtual TrainingLab TrainingLab { get; set; }


        #endregion

    }
}





