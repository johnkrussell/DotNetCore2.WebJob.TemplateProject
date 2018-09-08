using DotNetCore2.WebJob.TemplateProject.Services.Interface;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore2.WebJob.TemplateProject
{
    public class Functions
    {
        private readonly IMyService _myService;

        public Functions(IMyService myService)
        {
            _myService = myService;
        }

        public async Task DoSomething([TimerTrigger("* */1 * * * *", RunOnStartup = true)] TimerInfo timerInfo, TextWriter log)
        {
            await _myService.MyMethod();
        }
    }
}
