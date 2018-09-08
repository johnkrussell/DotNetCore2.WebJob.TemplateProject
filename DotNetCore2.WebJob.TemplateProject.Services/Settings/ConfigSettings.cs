using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.WebJob.TemplateProject.Services.Settings
{
    public class ConfigSettings
    {
        // Custom settings are mapped here from the appsettings.json
        // A single setting for the Azure Application Insights telemetry service has been included for brevity.
        public string InstrumentationKey { get; set; }
    }
}
