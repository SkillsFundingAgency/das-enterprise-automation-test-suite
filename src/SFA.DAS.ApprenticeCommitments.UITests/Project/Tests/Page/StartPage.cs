using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class StartPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Confirm my apprenticeship details";
        private By StartNowButton => By.CssSelector(".govuk-button");

        public StartPage(ScenarioContext context) : base(context) => _context = context;

        public SignIntoMyApprenticeshipPage CTAOnStartPageToSignIn()
        {
            formCompletionHelper.ClickButtonByText(StartNowButton, "Start now");
            return new SignIntoMyApprenticeshipPage(_context);
        }
    }
}
