using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ConfirmApprenticeCancelPage : EIBasePage
    {
        protected override string PageTitle => "Confirm apprentices";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ConfirmApprenticeCancelPage(ScenarioContext context) : base(context) { }

        public ApplicationCancelledPage ConfirmCancelApplications()
        {
            Continue();
            return new ApplicationCancelledPage(context);
        }
    }
}