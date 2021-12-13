using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplicationSavedPage : EIBasePage
    {
        protected override string PageTitle => "Application saved";

        public ApplicationSavedPage(ScenarioContext context) : base(context)  { }

        public ViewApplicationsPage NavigateToViewApplicationsPage()
        {
            formCompletionHelper.ClickLinkByText("View applications");
            return new ViewApplicationsPage(context);
        }
    }
}
