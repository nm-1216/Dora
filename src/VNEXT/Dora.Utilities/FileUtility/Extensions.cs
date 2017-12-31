//using System;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;

//namespace Micrrosoft.Extensions.DependencyInjection
//{
//    public static class Extensions
//    {
//        public static IServiceCollection AddWKMvcDI(this IServiceCollection services)
//        {
//            return services;
//        }

//        public static IApplicationBuilder UseWKMvcDI(this IApplicationBuilder builder)
//        {
//            DI.ServiceProvider = builder.ApplicationServices;
//            return builder;
//        }
//    }

//    public static class DI
//    {
//        public static IServiceProvider ServiceProvider
//        {
//            get;set;
//        }
//    }
//}
