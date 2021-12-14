using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIHubPage : EIBasePage
    {
        protected override string PageTitle => "Hire a new apprentice payment";

        public EIHubPage(ScenarioContext context) : base(context)  { }

        public EIApplyPage ClickApplyLinkOnEIHubPage()
        {
            HireANewApprenticePayment();
            return new EIApplyPage(context);
        }

        public EIApplicationOpenOn11JanPage NavigateToApplicationsOpenOn22JanPage()
        {
            HireANewApprenticePayment();
            return new EIApplicationOpenOn11JanPage(context);
        }

        public ViewApplicationsPage NavigateToEIViewApplicationsPage()
        {
            ViewApplications();
            return new ViewApplicationsPage(context);
        }

        public ViewApplicationsShutterPage NavigateToEIViewApplicationsShutterPage()
        {
            ViewApplications();
            return new ViewApplicationsShutterPage(context);
        }

        public ChangeBankDetailsPage NavigateToChangeBankDetailsPage()
        {
            formCompletionHelper.ClickLinkByText("Change organisation and finance details");
            return new ChangeBankDetailsPage(context);
        }

        private void HireANewApprenticePayment() => formCompletionHelper.ClickLinkByText("Apply for the hire a new apprentice payment");

        private void ViewApplications() => formCompletionHelper.ClickLinkByText("View applications");
    }
}
