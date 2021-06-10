using System;
using OpenQA.Selenium;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.ProviderLogin.Service;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;


        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
        }

        public AedProviderHomePage GoToProviderHomePagePage(ProviderLoginUser login, bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(login, newTab);
            return new AedProviderHomePage(_context);
        }
    }
}
