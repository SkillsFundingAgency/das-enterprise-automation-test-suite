using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply
{
    public class AP_ApplicationOverviewPage : EPAO_BasePage
    {
        protected override string PageTitle => "Application overview";
        private readonly ScenarioContext _context;

        #region Locators
        private By GoToOrganisationDetailsLink => By.LinkText("Go to organisation details");
        private By GoToDeclarationsLink => By.LinkText("Go to declarations");
        private By GoToFinancialHealthAssessmentLink => By.LinkText("Go to financial health assessment");
        #endregion

        public AP_ApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void ClickSubmitInApplicationOverviewPage()
        {
            Continue();
        }

        public AP_OrganisationDetailsPage ClickGoToOrganisationDetailsLinkInApplicationOverviewPage()
        {
            formCompletionHelper.Click(GoToOrganisationDetailsLink);
            return new AP_OrganisationDetailsPage(_context);
        }
    }
}
