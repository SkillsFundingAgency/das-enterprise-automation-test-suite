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
        private GatewayLandingPage gatewayLandingPage;

        public SearchSteps(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"the admin searches for a provider in Gateway by provider name")]
        public void WhenTheAdminSearchesForAProviderInGatewayByProviderName()
        {
            gatewayLandingPage = new StaffDashboardPage(_context).AccessGatewayApplications().SelectInOutcomeTab().ConfirmGatewaySearchByName();
        }

        [Then(@"the search results should be displayed")]
        public void ThenTheSearchResultsShouldBeDisplayed()
        {
            Assert.IsTrue(gatewayLandingPage.VerifyApplication(), "Verify gateway search functionality");
        }

        [When(@"the admin searches for a provider in Gateway by UKPRN")]
        public void WhenTheAdminSearchesForAProviderInGatewayByUKPRN()
        {
            gatewayLandingPage = new GatewayLandingPage(_context).ClearSearchResult_OutcomeTab().SelectInOutcomeTab().ConfirmGatewaySearchByUkprn();
        }

    }
}
