using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotNetCore2.WebJob.TemplateProject.Services.Interface
{
    public interface ITelemetryService
    {
        void TrackException(Exception ex);
        void TrackTrace(string message, SeverityLevel severity);
        void TrackEvent(string eventName, Dictionary<string, string> properties = null);
        Stopwatch StartTrackRequest(string requestName);
        void StopTrackRequest(string requestName, Stopwatch stopwatch);
    }
}
