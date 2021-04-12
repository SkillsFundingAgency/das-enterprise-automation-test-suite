using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class OversightLandingPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "RoATP application outcomes";
        protected By ApplicationsTab => By.CssSelector("a[href='#applications']");
        protected By ApplicationsStatus => By.CssSelector("[data-label='Outcome']");
        protected override By OutcomeTab => By.CssSelector("a[href='#outcomes']");
        protected override By OutcomeStatus => By.CssSelector("[data-label='Overall outcome']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OversightLandingPage(ScenarioContext context) : base(context) => _context = context;

        public OversightLandingPage VerifyApplicationsOutcomeStatus(string expectedStatus)
        {
            VerifyOutcomeStatus(ApplicationsTab, ApplicationsStatus, expectedStatus);
            return this;
        }

        public OversightLandingPage VerifyOverallOutcomeStatus(string expectedStatus)
        {
            VerifyOutcomeStatus(expectedStatus);
            return this;
        }

        public ApplicationSummaryPage SelectApplication(string expectedStatus)
        {
            if (expectedStatus == "IN PROGRESS") VerifyOverallOutcomeStatus(expectedStatus);
            else VerifyApplicationsOutcomeStatus(expectedStatus);

            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());

            return new ApplicationSummaryPage(_context);
        }
    }
}
