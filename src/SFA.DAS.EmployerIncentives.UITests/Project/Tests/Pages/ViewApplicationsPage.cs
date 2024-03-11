using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ViewApplicationsPage(ScenarioContext context) : EIBasePage(context)
    {
        protected override string PageTitle => "Hire a new apprentice payment applications";

        private static By CancelAnApplicationSelector => By.CssSelector("a[href*='cancel-application']");

        public WhichApprenticeToCancelPage CancelAnApplication()
        {
            formCompletionHelper.Click(CancelAnApplicationSelector);

            return new WhichApprenticeToCancelPage(context);
        }
    }
}