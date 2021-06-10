using System;
using OpenQA.Selenium;
using System.Linq;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages;


namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers
{
    public class AEDStepsHelper
    {
        private readonly ScenarioContext _context;

        public AEDStepsHelper(ScenarioContext context)
        {
            _context = context;
        }

        public GetHelpWithFindingATrainingProviderPage GetHelpWithFindingATrainingProvider()
        {
            new AEDIndexPage(_context).ClickGetHelpWithFindingATrainingProviderLink();
            return new GetHelpWithFindingATrainingProviderPage(_context);
        }
    }
}
