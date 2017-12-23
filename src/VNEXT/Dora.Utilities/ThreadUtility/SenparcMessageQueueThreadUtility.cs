namespace Dora.Utilities.ThreadUtility
{
    using System;
    using System.Threading;
    using MessageQueue;

    /// <summary>
    /// SenparcMessageQueue线程自动处理
    /// </summary>
    public class DoraMessageQueueThreadUtility
    {
        private readonly int _sleepMilliSeconds;


        public DoraMessageQueueThreadUtility(int sleepMilliSeconds = 1000)
        {
            _sleepMilliSeconds = sleepMilliSeconds;
        }

        /// <summary>
        /// 析构函数，将未处理的队列处理掉
        /// </summary>
        ~DoraMessageQueueThreadUtility()
        {
            try
            {
                var mq = new DoraMessageQueue();


                DoraMessageQueue.OperateQueue();//处理队列
            }
            catch (Exception ex)
            {
                //此处可以添加日志
            }
        }

        /// <summary>
        /// 启动线程轮询
        /// </summary>
        public void Run()
        {
            do
            {
                DoraMessageQueue.OperateQueue();
                Thread.Sleep(_sleepMilliSeconds);
            } while (true);
        }
    }
}
