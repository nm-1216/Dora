//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PubClaRoom.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:54:19</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// PubClaRoom 公共教室信息
    /// </summary>
    public partial class PublicClassRoom: BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets 公共教室信息 
        /// </summary>
        public virtual string PublicClassRoomId { get; set; }

        /// <summary>
        /// Gets or sets 教室名称 
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
        /// Gets or sets 座位数 
        /// </summary>
        public virtual int? SeatNum { get; set; }

        /// <summary>
        /// Gets or sets 当前使用状态
        /// </summary>
        public virtual BaseStatus Status { get; set; } 

        #endregion

    }
}





