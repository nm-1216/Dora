namespace Dora.Utilities.ThreadUtility
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 线程处理类
    /// </summary>
    public static class DoraThreadUtility
    {
        /// <summary>
        /// 异步线程容器
        /// </summary>
        public static Dictionary<string, Thread> AsynThreadCollection = new Dictionary<string, Thread>();//后台运行线程

        /// <summary>
        /// 注册线程
        /// </summary>
        public static void Register()
        {
            if (AsynThreadCollection.Count==0)
            {
                {
                    DoraMessageQueueThreadUtility senparcMessageQueue = new DoraMessageQueueThreadUtility();
                    Thread senparcMessageQueueThread = new Thread(senparcMessageQueue.Run) { Name = "DoraMessageQueue" };
                    AsynThreadCollection.Add(senparcMessageQueueThread.Name, senparcMessageQueueThread);
                }

                AsynThreadCollection.Values.ToList().ForEach(z =>
                {
                    z.IsBackground = true;
                    z.Start();
                });

            }
        }
    }
}
