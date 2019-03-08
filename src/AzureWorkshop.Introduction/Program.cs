using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;

[assembly: UserSecretsId("AzureWorkshop.Introduction")]

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
                    config.AddUserSecrets<Program>(false);
                    var cfg = config.Build();
                    config.AddAzureKeyVault(cfg["KeyVault:Vault"], cfg["KeyVault:ClientId"], cfg["KeyVault:ClientSecret"]);
                })
                .UseStartup<Startup>();
    }
}
