using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIHubPage : EIBasePage
    {
        protected override string PageTitle => "Hire a new apprentice payment";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public EIHubPage(ScenarioContext context) : base(context) => _context = context;

        public EIApplyPage ClickApplyLinkOnEIHubPage()
        {
            HireANewApprenticePayment();
            return new EIApplyPage(_context);
        }

        public EIApplicationOpenOn11JanPage NavigateToApplicationsOpenOn22JanPage()
        {
            HireANewApprenticePayment();
            return new EIApplicationOpenOn11JanPage(_context);
        }

        public ViewApplicationsPage NavigateToEIViewApplicationsPage()
        {
            ViewApplications();
            return new ViewApplicationsPage(_context);
        }

        public ViewApplicationsShutterPage NavigateToEIViewApplicationsShutterPage()
        {
            ViewApplications();
            return new ViewApplicationsShutterPage(_context);
        }

        public ChangeBankDetailsPage NavigateToChangeBankDetailsPage()
        {
            formCompletionHelper.ClickLinkByText("Change organisation and finance details");
            return new ChangeBankDetailsPage(_context);
        }

        private void HireANewApprenticePayment() => formCompletionHelper.ClickLinkByText("Apply for the hire a new apprentice payment");

        private void ViewApplications() => formCompletionHelper.ClickLinkByText("View applications");
    }
}
