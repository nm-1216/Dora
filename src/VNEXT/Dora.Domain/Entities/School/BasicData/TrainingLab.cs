//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PraClaRoom.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:52:06</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;


    /// <summary>
    /// TrainingLab 实训室基本信息表
    /// </summary>
    public partial class TrainingLab: BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets 实训室基本信息表实训室编号 
        /// </summary>
        public virtual string TrainingLabId { get; set; }


        /// <summary>
        /// Gets or sets 实训室名称 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 所在校区 
        /// </summary>
        public virtual string School { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 所在楼号 
        /// </summary>
        public virtual string BuildingNo { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 所在房间号 
        /// </summary>
        public virtual string RoomNo { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 面积 
        /// </summary>
        public virtual decimal? Area { get; set; }


        /// <summary>
        /// Gets or sets 所属基地 
        /// </summary>
        public virtual string Base { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 所属中心 
        /// </summary>
        public virtual string Center { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets Status 在用    停用
        /// </summary>
        public virtual BaseStatus Status { get; set; }
        public virtual ICollection<TrainingLabDevice> TrainingLabDevice { get; set; }

        
        #endregion

    }
}





