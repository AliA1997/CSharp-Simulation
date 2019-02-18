using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Houser.Data;
using Houser_App.Data.Seed;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Houser_App.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHost(args);

            using (var scope = host.Services.GetService<IServiceScopeFactory>().CreateScope()) 
            {

                using (var dbContext = scope.ServiceProvider.GetRequiredService<HouserContext>())
                {
                    dbContext.Database.Migrate();

                    Console.WriteLine("Database up to date.");

                }
                
            }

            using (var scope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                try
                {

                    var dbContext = scope.ServiceProvider.GetRequiredService<HouserContext>();

                    SeedHouseData.Seed(dbContext);

                    host.Run();

                } catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }

        public static IWebHost CreateWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
