using DotNetCore2.WebJob.TemplateProject;
using DotNetCore2.WebJob.TemplateProject.Data;
using DotNetCore2.WebJob.TemplateProject.Services.Concrete;
using DotNetCore2.WebJob.TemplateProject.Services.Interface;
using DotNetCore2.WebJob.TemplateProject.Services.Settings;
using DotNetCore2.WebJob.TemplateProject.WebJob.Framework;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DotNetCore2.WebJob.TemplateProject.WebJob
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var configuration = new JobHostConfiguration();
            configuration.Queues.MaxPollingInterval = TimeSpan.FromSeconds(10);
            configuration.Queues.BatchSize = 1;
            configuration.JobActivator = new CustomJobActivator(serviceCollection.BuildServiceProvider());
            configuration.UseTimers();

            var host = new JobHost(configuration);
            host.RunAndBlock();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Optional: Setup your configuration:
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddApplicationInsightsTelemetry(configuration);

            services.AddOptions();
            services.Configure<ConfigSettings>(configuration.GetSection("AppSettings"));
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbContext")));
            services.AddScoped<DbContext, MyDbContext>();

            services.AddScoped<Functions>();

            services.AddSingleton<ITelemetryService, TelemetryService>();

            // These two are needed
            Environment.SetEnvironmentVariable("AzureWebJobsDashboard",
                configuration.GetConnectionString("AzureWebJobsDashboard"));
            Environment.SetEnvironmentVariable("AzureWebJobsStorage",
                configuration.GetConnectionString("AzureWebJobsStorage"));
        }
    }
}
