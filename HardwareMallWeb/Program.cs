using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareMall.Tool;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HardwareMallWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static readonly string Port = ConfigHelper.Configuration["ServerPort"];
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"http://*:{Port}").UseStartup<Startup>();
                });
    }
}
