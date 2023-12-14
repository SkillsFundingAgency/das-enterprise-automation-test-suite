using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ViewApplicationsPage(ScenarioContext context) : EIBasePage(context)
    {
        protected override string PageTitle => "Hire a new apprentice payment applications";

        private static By Links => By.CssSelector("#main-content a");

        public WhichApprenticeToCancelPage CancelAnApplication()
        {
            formCompletionHelper.ClickLinkByText(Links, "Cancel an application");

            return new WhichApprenticeToCancelPage(context);
        }
    }
}