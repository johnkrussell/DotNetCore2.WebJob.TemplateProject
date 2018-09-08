using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.WebJob.TemplateProject.WebJob.Settings
{
    public class ConnectionStrings
    {
        public string DbContext { get; set; }
        public string AzureWebJobsDashboard { get; set; }
        public string AzureWebJobsStorage { get; set; }
    }
}
