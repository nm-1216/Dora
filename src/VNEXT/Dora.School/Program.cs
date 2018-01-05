using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Dora.School
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var config = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("hosting.json", optional: true)
            //.Build();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .Build();
    }
}
