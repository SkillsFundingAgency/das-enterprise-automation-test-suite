using NUnit.Framework;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Search
{
    [Binding]
    public class SearchSteps
    {
        private readonly ScenarioContext _context;

        public SearchSteps(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"the admin searches for a provider in Gateway by provider name")]
        public void WhenTheAdminSearchesForAProviderInGatewayByProviderName()
        {
            new StaffDashboardPage(_context).AccessGatewayApplications().SelectInOutcomeTab().SearchProviderByName();
        }

        [Then(@"the search results should be displayed")]
        public void ThenTheSearchResultsShouldBeDisplayed()
        {
            GatewayLandingPage gatewayLandingPage = new GatewayLandingPage(_context);
            Assert.IsTrue(gatewayLandingPage.VerifyApplication(), "Gateway Search failed");
        }

        [When(@"the admin searches for a provider in Gateway by UKPRN")]
        public void WhenTheAdminSearchesForAProviderInGatewayByUKPRN()
        {
            new GatewayLandingPage(_context).ClearSearchResult_OutcomeTab().SelectInOutcomeTab().SearchProviderByUKPRN();
        }

    }
}
