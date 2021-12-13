using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplicationCompletePage : EIBasePage
    {
        protected override string PageTitle => "Application complete";

        public ApplicationCompletePage(ScenarioContext context) : base(context)  { }

        public ViewApplicationsPage NavigateToViewApplicationsPage()
        {
            formCompletionHelper.ClickLinkByText("View applications");
            return new ViewApplicationsPage(_context);
        }
    }
}
