using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ViewApplicationsPage : EIBasePage
    {
        protected override string PageTitle => "Hire a new apprentice payment applications";

        private By Links => By.CssSelector("#main-content a");

        public ViewApplicationsPage(ScenarioContext context) : base(context)  { }

        public EIHubPage NavigateToEIHubPage()
        {
            formCompletionHelper.ClickLinkByText("Back");

            return new EIHubPage(context);
        }

        public WhichApprenticeToCancelPage CancelAnApplication()
        {
            formCompletionHelper.ClickLinkByText(Links, "Cancel an application");

            return new WhichApprenticeToCancelPage(context);
        }
    }
}