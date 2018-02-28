using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudPlatformsComment.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CloudPlatformsComment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            MigrateDbContext(host);

            host.Run();
        }

        private static void MigrateDbContext(IWebHost host, int error = 0)
        {
            using (var scope = host.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var logger = provider.GetRequiredService<ILogger<ApplicationDbContext>>();
                var context = provider.GetService<ApplicationDbContext>();

                try
                {
                    context.Database.Migrate();
                    new ApplicationDbContextSeed().SeedAsync(context, provider).Wait();

                    logger.LogInformation($"执行DbContext{ typeof(ApplicationDbContext).Name } seed执行成功");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"执行DbContext { typeof(ApplicationDbContext).Name } seed方法失败");
                    error++;
                    if (error <= 10)
                    {
                        logger.LogError($"第 {error} 次重试。");

                        MigrateDbContext(host, error);
                    }
                }
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {

            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://+:80")
                .UseStartup<Startup>()
                .Build();
        }
    }
}
