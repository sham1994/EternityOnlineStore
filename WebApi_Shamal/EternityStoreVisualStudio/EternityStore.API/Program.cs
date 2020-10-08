using EternityStore.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;


namespace EternityStore.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                            .WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day)
                            .CreateLogger();

            CreateHostBuilder(args).Build().SeedData().Run();
            //CreateHostBuilder(args).Build().See
            //CreateWebHostBuilder(args).Build().SeedData().Run();




        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();






    }
}
