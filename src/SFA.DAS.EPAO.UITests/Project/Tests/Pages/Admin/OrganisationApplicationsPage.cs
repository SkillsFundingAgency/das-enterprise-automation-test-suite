using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationApplicationsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Organisation applications";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NewTab => By.CssSelector("#tab_new");
        private By InProgressTab => By.CssSelector("#tab_in-progress");
        private By FeedbackTab => By.CssSelector("#tab_feedback");
        private By ApprovedTab => By.CssSelector("#tab_approved");


        public OrganisationApplicationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public new StaffDashboardPage ReturnToDashboard() => base.ReturnToDashboard();

        public ApplicationOverviewPage GoToNewApplicationOverviewPage() => GoToApplicationOverviewPage(NewTab);

        public ApplicationOverviewPage GoToInProgressApplicationOverviewPage() => GoToApplicationOverviewPage(InProgressTab);

        public ApplicationOverviewPage GoToApprovedApplicationOverviewPage() => GoToApplicationOverviewPage(ApprovedTab);

        private ApplicationOverviewPage GoToApplicationOverviewPage(By by)
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(by));
            formCompletionHelper.ClickLinkByText(objectContext.GetApplyOrganisationName());
            return new ApplicationOverviewPage(_context);
        }
    }
}