using CSMP.Portal.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CSMP.Portal.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var logger = scope.ServiceProvider.GetService<ILogger<AppDbContext>>();
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

                new DataSender(dbContext).Initialize();
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
