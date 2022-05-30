using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplicationClosedPage : EIBasePage
    {
        protected override string PageTitle => "Sorry, applications for incentive payments have closed";

        public ApplicationClosedPage(ScenarioContext context) : base(context) { }
    }

    public class ApplicationCompletePage : EIBasePage
    {
        protected override string PageTitle => "Application complete";

        public ApplicationCompletePage(ScenarioContext context) : base(context)  { }

        public ViewApplicationsPage NavigateToViewApplicationsPage()
        {
            formCompletionHelper.ClickLinkByText("View applications");
            return new ViewApplicationsPage(context);
        }
    }
}
