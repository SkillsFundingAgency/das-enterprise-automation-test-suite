using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ForgottenPasswordPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Forgotten password";
        protected override By ServiceHeader => NonClickableServiceHeader;
        private By Email => By.CssSelector("input#Email");

        public ForgottenPasswordPage(ScenarioContext context) : base(context) => _context = context;

        public ForgottenPasswordConfirmPage SubmitEmailOnForgottenPasswordPage()
        {
            formCompletionHelper.EnterText(Email, objectContext.GetApprenticeEmail());
            formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
            return new ForgottenPasswordConfirmPage(_context);
        }
    }
}
