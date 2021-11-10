using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SignedOutPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "You have successfully signed out";
        protected override By ServiceHeader => NonClickableServiceHeader;

        public SignedOutPage(ScenarioContext context) : base(context) => _context = context;

        public SignIntoMyApprenticeshipPage ClickSignBackInLinkFromSignOutPage()
        {
            formCompletionHelper.ClickLinkByText("sign back in");
            return new SignIntoMyApprenticeshipPage(_context);
        }
    }
}
