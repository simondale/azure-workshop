using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.Introduction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddEnvironmentVariables();
                    config.AddCommandLine(Environment.GetCommandLineArgs().Skip(1).ToArray());
                    var cfg = config.Build();
                    config.AddAzureKeyVault(cfg["KeyVault:Vault"], cfg["KeyVault:ClientId"], cfg["KeyVault:ClientSecret"]);
                })
                .UseStartup<Startup>();
    }
}
