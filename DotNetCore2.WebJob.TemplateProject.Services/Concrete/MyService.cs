using DotNetCore2.WebJob.TemplateProject.Services.Interface;
using DotNetCore2.WebJob.TemplateProject.Services.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace DotNetCore2.WebJob.TemplateProject.Services.Concrete
{
    public class MyService : IMyService
    {
        // Included here is a sample dependency injection class containing config settings and a
        // telemtry class for reporting data to Azure telemetry services (required an instrumentation key).

        private readonly ITelemetryService _telemetryService;
        private readonly ConfigSettings _configSettings;

        public MyService(
            IOptions<ConfigSettings> configSettings,
            ITelemetryService telemetryService)
        {
            _configSettings = configSettings.Value;
            _telemetryService = telemetryService;
        }

        public Task MyMethod()
        {
            throw new NotImplementedException();
        }
    }
}