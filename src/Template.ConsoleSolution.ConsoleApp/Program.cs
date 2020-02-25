﻿using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Template.ConsoleSolution.ConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();

            var startup = host.Services.GetRequiredService<Startup>();
            await startup.StartApplicationAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services)
                    => RegisterServices(services, hostContext.Configuration));
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Startup>();
        }
    }
}