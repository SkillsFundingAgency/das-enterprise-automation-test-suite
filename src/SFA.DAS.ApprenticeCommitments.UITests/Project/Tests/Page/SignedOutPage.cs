using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SignedOutPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "You have successfully signed out";
        private readonly ScenarioContext _context;

        public SignedOutPage(ScenarioContext context) : base(context) => _context = context;

        public SignIntoApprenticeshipPortalPage SignBackInFromSignOutPage()
        {
            formCompletionHelper.ClickLinkByText("sign back in");
            return new SignIntoApprenticeshipPortalPage(_context);
        }
    }
}
