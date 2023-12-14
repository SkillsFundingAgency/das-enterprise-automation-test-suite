using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class WhichApprenticeToCancelPage : EIBasePage
    {
        protected override string PageTitle => "Which apprentices do you want to cancel an application for?";

        private static By CancelApprenticeshipSelector => By.CssSelector("input[id*='cancel-apprenticeships']");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public WhichApprenticeToCancelPage(ScenarioContext context) : base(context) { }

        public ConfirmApprenticeCancelPage SelectApprenticeToCancel()
        {
            var apprentices = pageInteractionHelper.FindElements(CancelApprenticeshipSelector);

            foreach (var apprentice in apprentices)
            {
                formCompletionHelper.ClickElement(apprentice);
            }

            Continue();

            return new ConfirmApprenticeCancelPage(context);
        }
    }
}