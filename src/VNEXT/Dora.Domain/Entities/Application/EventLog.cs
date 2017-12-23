//namespace Dora.Domain.Entities.Application
//{
//    using System;
//    using Infrastructure.Domains;
//    using static Constants;

//    public partial class EventLog : BaseEntity
//    {
//        /// <summary>
//        /// Gets or sets LogID 模块主键
//        /// </summary>
//        public virtual int LogID { get; set; }

//        /// <summary>
//        /// Gets or sets LogType 日志类型 Event or Error
//        /// </summary>
//        public virtual LogType LogType { get; set; }

//        public virtual string UserId { get; set; }

//        /// <summary>
//        /// Gets or sets Date 创建时间
//        /// </summary>
//        public virtual DateTime Date { get; set; }

//        /// <summary>
//        /// Gets or sets Father 父亲节点
//        /// </summary>
//        public virtual string Thread { get; set; }

//        /// <summary>
//        /// Gets or sets Layer 层集关系
//        /// </summary>
//        public virtual String Level { get; set; }

//        /// <summary>
//        /// Gets or sets Code 模块编号
//        /// </summary>
//        public virtual String Logger { get; set; }

//        /// <summary>
//        /// Gets or sets Ico 图标
//        /// </summary>
//        public virtual String Message { get; set; }

//        /// <summary>
//        /// Gets or sets Exception 异常
//        /// </summary>
//        public virtual string Exception { get; set; }

//        public virtual ApplicationUser ApplicationUser { get; set; }
//    }
//}
