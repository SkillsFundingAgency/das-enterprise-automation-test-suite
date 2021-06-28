using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial
{
    public class FinancialLandingPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "RoATP financial applications";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        protected By CurrentApplicationsTab => By.CssSelector("a[href='/Roatp/Financial/Current']");
        protected override By ClarificationTab => By.CssSelector("a[href='/Roatp/Financial/Clarification']");
        protected override By OutcomeTab => By.CssSelector("a[href='/Roatp/Financial/Outcome']");
       

        public FinancialLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FinancialLandingPage DownloadAllCurrentApplications()
        {
            formCompletionHelper.ClickLinkByText("Download all current applications");
            return new FinancialLandingPage(_context);
        }

        public FinancialHealthAssessmentOverviewPage SelectNewApplication()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(CurrentApplicationsTab));
            formCompletionHelper.ClickLinkByText( objectContext.GetProviderName());
            return new FinancialHealthAssessmentOverviewPage(_context);
        }

        public FinancialHealthAssessmentOverviewPage SelectClarificationApplication()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ClarificationTab));
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new FinancialHealthAssessmentOverviewPage(_context);
        }

        public new FinancialLandingPage VerifyOutcomeStatus(string expectedStatus)
        {
            base.VerifyOutcomeStatus(expectedStatus);
            return new FinancialLandingPage(_context);
        }
    }
}
