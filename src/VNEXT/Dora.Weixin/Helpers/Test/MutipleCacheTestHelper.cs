using System;
using System.Collections.Generic;
using Dora.Helpers;
using Dora.Weixin;
using Dora.Weixin.Cache;

namespace Dora.Weixin.Helpers
{
    /// <summary>
    /// 多种缓存测试帮助类
    /// </summary>
    public class MutipleCacheTestHelper
    {
        /// <summary>
        /// 测试多种缓存
        /// </summary>
        public static void RunMutipleCache(Action action)
        {
            RunMutipleCache(action, CacheType.Local);
        }

        /// <summary>
        /// 遍历使用多种缓存测试同一个过程（委托），确保不同的缓存策略行为一致
        /// </summary>
        public static void RunMutipleCache(Action action, params CacheType[] cacheTypes)
        {
            List<IObjectCacheStrategy> cacheStrategies = new List<IObjectCacheStrategy>();

            foreach (var cacheType in cacheTypes)
            {
                var assabmleName = cacheType == CacheType.Local
                    ? "Dora.Weixin"
                    : "Dora.Weixin.Cache." + cacheType.ToString();

                var nameSpace = cacheType == CacheType.Local
                                    ? "Dora.Weixin.Cache"
                                    : "Dora.Weixin.Cache." + cacheType.ToString();

                var className = cacheType.ToString() + "ObjectCacheStrategy";

                var cacheInstance = ReflectionHelper.CreateInstance<IObjectCacheStrategy>(assabmleName, nameSpace,
                    className);

                cacheStrategies.Add(cacheInstance);


            }

            foreach (var objectCacheStrategy in cacheStrategies)
            {
                //原始缓存策越
                var originalCache = CacheStrategyFactory.GetObjectCacheStrategyInstance();

                Console.WriteLine("== 使用缓存策略：" + objectCacheStrategy.GetType().Name + " 开始 == ");

                //使用当前缓存策略
                CacheStrategyFactory.RegisterObjectCacheStrategy(() => objectCacheStrategy);

                try
                {
                    action();//执行
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.WriteLine("== 使用缓存策略：" + objectCacheStrategy.GetType().Name + " 结束 == \r\n");

                //还原缓存策略
                CacheStrategyFactory.RegisterObjectCacheStrategy(() => originalCache);
            }
        }
    }
}
