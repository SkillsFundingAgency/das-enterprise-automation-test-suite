using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ConfirmApprenticeCancelPage(ScenarioContext context) : EIBasePage(context)
    {
        protected override string PageTitle => "Confirm apprentices";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ApplicationCancelledPage ConfirmCancelApplications()
        {
            Continue();
            return new ApplicationCancelledPage(context);
        }
    }
}