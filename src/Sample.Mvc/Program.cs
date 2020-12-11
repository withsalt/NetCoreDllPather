using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Mvc
{

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    string baseConfigPath = $"{AppContext.BaseDirectory}appsettings.Base.json";
                    if (!File.Exists(baseConfigPath))
                    {
                        throw new Exception($"Base app config not exist. Please check file '{baseConfigPath}'");
                    }
                    config.AddJsonFile(baseConfigPath, optional: false, reloadOnChange: true);

                    string nornalConfigPath = $"{AppContext.BaseDirectory}appsettings.json";
                    string eventName = hostingContext.HostingEnvironment.EnvironmentName;
                    if (!string.IsNullOrEmpty(eventName))
                    {
                        string eventAppConfigPath = $"{AppContext.BaseDirectory}appsettings.{eventName}.json";
                        if (File.Exists(eventAppConfigPath))
                        {
                            config.AddJsonFile(eventAppConfigPath, optional: false, reloadOnChange: true);
                        }
                        else
                        {
                            if (File.Exists(nornalConfigPath))
                            {
                                config.AddJsonFile(nornalConfigPath, optional: false, reloadOnChange: true);
                            }
                        }
                    }
                    else
                    {
                        if (File.Exists(nornalConfigPath))
                        {
                            config.AddJsonFile(nornalConfigPath, optional: false, reloadOnChange: true);
                        }
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
