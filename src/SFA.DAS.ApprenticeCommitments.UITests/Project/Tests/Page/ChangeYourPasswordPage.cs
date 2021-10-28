using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ChangeYourPasswordPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "Forgotten password";

        private By NewEmailAddress => By.CssSelector("#Email");

        private By Message => By.CssSelector("#main-content .govuk-body");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        public ChangeYourPasswordPage(ScenarioContext context) : base(context) => _context = context;

        public ChangeYourPasswordPage UpdatePassword()
        {
            formCompletionHelper.EnterText(NewEmailAddress, objectContext.GetApprenticeEmail());

            Continue();

            VerifyPage(Message, "we have sent an email with instructions to reset your password.");

            return new ChangeYourPasswordPage(_context);
        }
    }
}
