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
        private GatewayLandingPage _gatewayLandingPage;
        private FinancialLandingPage _financialLandingPage;

        public SearchSteps(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"the admin searches for a provider in Gateway by provider name")]
        public void WhenTheAdminSearchesForAProviderInGatewayByProviderName()
        {
            _gatewayLandingPage = new StaffDashboardPage(_context).AccessGatewayApplications().SelectInOutcomeTab().ConfirmGatewaySearchByName();
        }

        [Then(@"the search results should be displayed for Gateway")]
        public void ThenTheSearchResultsShouldBeDisplayedForGateway()
        {
            Assert.IsTrue(_gatewayLandingPage.VerifyApplication(), "Verify gateway search functionality");
        }

        [When(@"the admin searches for a provider in Gateway by UKPRN")]
        public void WhenTheAdminSearchesForAProviderInGatewayByUKPRN()
        {
            _gatewayLandingPage = new GatewayLandingPage(_context).ClearSearchResult_OutcomeTab().SelectInOutcomeTab().ConfirmFinanceSearchByUkprn();
        }
        [When(@"the admin searches for a provider in Finance by provider name")]
        public void WhenTheAdminSearchesForAProviderInFinanceByProviderName()
        {
            _financialLandingPage = new StaffDashboardPage(_context).AccessFinancialApplications().SelectInOutcomeTab().ConfirmFinanceSearchByName();
        }

        [Then(@"the search results should be displayed for Finance")]
        public void ThenTheSearchResultsShouldBeDisplayedForFinance()
        {
            Assert.IsTrue(_financialLandingPage.VerifyApplication(), "Verify Finance search functionality");
        }

        [When(@"the admin searches for a provider in Finance by UKPRN")]
        public void WhenTheAdminSearchesForAProviderInFinanceByUKPRN()
        {
            gatewayLandingPage = new GatewayLandingPage(_context).ClearSearchResult_OutcomeTab().SelectInOutcomeTab().ConfirmFinanceSearchByUkprn();
        }
    }
}
