using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIHubPage : EIBasePage
    {
        protected override string PageTitle => "Hire a new apprentice payment";

        public EIHubPage(ScenarioContext context) : base(context)  { }

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

        public AddYourOrgBankDetailsPage AddOrgAndFinDetails()
        {
            formCompletionHelper.ClickLinkByText("Add organisation and finance details");
            return new AddYourOrgBankDetailsPage(context);
        }

        public ChangeBankDetailsPage NavigateToChangeBankDetailsPage()
        {
            formCompletionHelper.ClickLinkByText("Change organisation and finance details");
            return new ChangeBankDetailsPage(context);
        }

        private void ViewApplications() => formCompletionHelper.ClickLinkByText("View applications");
    }
}
