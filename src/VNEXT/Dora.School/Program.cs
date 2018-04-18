namespace Dora.School
{
    using System.Net;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .UseConfiguration(
                    new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("hosting.json", optional: true)
                        .Build()
                )
//                .UseKestrel(options =>
//                {
//                    options.Listen(IPAddress.Loopback, 5000);
//                    options.Listen(IPAddress.Any, 80);
//                    options.Listen(IPAddress.Loopback, 443, listenOptions =>
//                    {
//                        //listenOptions.UseHttps("certificate.pfx", "password");
//                    });
//                })
                .UseStartup<Startup>()
                .Build();
    }
}
