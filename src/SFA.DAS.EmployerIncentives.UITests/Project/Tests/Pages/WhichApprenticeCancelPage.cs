using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class WhichApprenticeCancelPage : EIBasePage
    {
        protected override string PageTitle => "Which apprentices do you want to cancel an application for?";

        private readonly ScenarioContext _context;

        private By CancelApprenticeshipSelector => By.CssSelector("input[id*='cancel-apprenticeships']");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public WhichApprenticeCancelPage(ScenarioContext context) : base(context) => _context = context;

        public ConfirmApprenticeCancelPage SelectApprenticeToCancel()
        {
            var apprentices = pageInteractionHelper.FindElements(CancelApprenticeshipSelector);

            foreach (var apprentice in apprentices)
            {
                formCompletionHelper.ClickElement(apprentice);
            }

            Continue();

            return new ConfirmApprenticeCancelPage(_context);
        }
    }
}