using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ForgottenPasswordPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Forgotten password";

        private readonly ScenarioContext _context;

        private By Email => By.CssSelector("input#Email");

        public ForgottenPasswordPage(ScenarioContext context) : base(context) => _context = context;

        public ForgottenPasswordConfirmPage Submit()
        {
            formCompletionHelper.EnterText(Email, objectContext.GetApprenticeEmail());
            formCompletionHelper.ClickButtonByText(ContinueButton, "Submit");
            return new ForgottenPasswordConfirmPage(_context);
        }
    }
}
