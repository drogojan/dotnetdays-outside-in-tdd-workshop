using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OpenChat.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // IHost host = CreateHostBuilder(args).Build();

            // // migrate the database.  Best practice = in Main, using service scope
            // using (var scope = host.Services.CreateScope())
            // {
            //     var dbContext = scope.ServiceProvider.GetService<OpenChatDbContext>();
            //     dbContext.Database.Migrate();
            // }

            // host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
