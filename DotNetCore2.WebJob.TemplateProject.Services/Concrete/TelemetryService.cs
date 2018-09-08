using Microsoft.Extensions.Options;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationInsights;
using System.Diagnostics;
using DotNetCore2.WebJob.TemplateProject.Services.Interface;
using DotNetCore2.WebJob.TemplateProject.Services.Settings;

namespace DotNetCore2.WebJob.TemplateProject.Services.Concrete
{
    public class TelemetryService : ITelemetryService
    {
        private readonly TelemetryClient _telemetry = new TelemetryClient();
        private readonly ConfigSettings _configSettings;

        public TelemetryService(IOptions<ConfigSettings> configSettings)
        {
            _configSettings = configSettings.Value;

            TelemetryConfiguration.Active.InstrumentationKey = _configSettings.InstrumentationKey;
        }

        public TelemetryService() { }

        public void TrackException(Exception ex)
        {
            _telemetry.TrackException(ex);
        }

        public void TrackTrace(string message, SeverityLevel severity)
        {
            _telemetry.TrackTrace(message, severity);
        }

        public void TrackEvent(string eventName, Dictionary<string, string> properties = null)
        {
            _telemetry.TrackEvent(eventName, properties);
        }

        public Stopwatch StartTrackRequest(string requestName)
        {
            _telemetry.Context.Operation.Id = Guid.NewGuid().ToString();
            return Stopwatch.StartNew();
        }

        public void StopTrackRequest(string requestName, Stopwatch stopwatch)
        {
            stopwatch.Stop();
            _telemetry.TrackRequest(requestName, DateTime.Now, stopwatch.Elapsed, "200", true);
        }
    }
}
