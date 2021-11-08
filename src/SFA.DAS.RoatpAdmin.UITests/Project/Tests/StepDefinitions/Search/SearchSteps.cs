using NUnit.Framework;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
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
        private RoatpAssessorApplicationsHomePage _roatpAssessorApplicationsHomePage;

        public SearchSteps(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"the admin searches for a provider in Gateway by provider name")]
        public void WhenTheAdminSearchesForAProviderInGatewayByProviderName()
        {
            _gatewayLandingPage = new StaffDashboardPage(_context).AccessGatewayApplications().SelectInOutcomeTab_Gateway().ConfirmGatewaySearchByName();
        }

        [Then(@"the search results should be displayed for Gateway")]
        public void ThenTheSearchResultsShouldBeDisplayedForGateway()
        {
            Assert.IsTrue(_gatewayLandingPage.VerifyApplication(), "Verify gateway search functionality");
        }

        [When(@"the admin searches for a provider in Gateway by UKPRN")]
        public void WhenTheAdminSearchesForAProviderInGatewayByUKPRN()
        {
            _gatewayLandingPage = new GatewayLandingPage(_context).ClearSearchResult_OutcomeTab().ConfirmGatewaySearchByUkprn();
        }
        [When(@"the admin searches for a provider in Finance by provider name")]
        public void WhenTheAdminSearchesForAProviderInFinanceByProviderName()
        {
            _financialLandingPage = new StaffDashboardPage(_context).AccessFinancialApplications().SelectInOutcomeTab_Finance().ConfirmFinanceSearchByName();
        }

        [Then(@"the search results should be displayed for Finance")]
        public void ThenTheSearchResultsShouldBeDisplayedForFinance()
        {
            Assert.IsTrue(_financialLandingPage.VerifyApplication(), "Verify Finance search functionality");
        }

        [When(@"the admin searches for a provider in Finance by UKPRN")]
        public void WhenTheAdminSearchesForAProviderInFinanceByUKPRN()
        {
            _financialLandingPage = new FinancialLandingPage(_context).ClearSearchResult_FinancialOutcomeTab().ConfirmFinanceSearchByUkprn();
        }
        [When(@"the admin searches for a provider in Assessor by provider name")]
        public void WhenTheAdminSearchesForAProviderInAssessorByProviderName()
        {
            _roatpAssessorApplicationsHomePage = new StaffDashboardPage(_context).AccessAssessorAndModerationApplications().SelectInOutcomeTab_Assessor().ConfirmAssessorSearchByName();
        }

        [Then(@"the search results should be displayed for Assessor")]
        public void ThenTheSearchResultsShouldBeDisplayedForAssessor()
        {
            Assert.IsTrue(_roatpAssessorApplicationsHomePage.VerifyApplication(), "Verify Assessor search functionality");
        }

        [When(@"the admin searches for a provider in Assessor by UKPRN")]
        public void WhenTheAdminSearchesForAProviderInAssessorByUKPRN()
        {
            _roatpAssessorApplicationsHomePage = new RoatpAssessorApplicationsHomePage(_context).ClearSearchResult_AssessorOutcomeTab().ConfirmAssessorSearchByUkprn();
        }
    }
}
