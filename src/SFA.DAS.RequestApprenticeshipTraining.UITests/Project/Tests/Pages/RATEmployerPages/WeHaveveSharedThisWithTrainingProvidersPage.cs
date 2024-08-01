using OpenQA.Selenium;
using Polly;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class WeHaveveSharedThisWithTrainingProvidersPage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "We've shared this with training providers";

    }
}