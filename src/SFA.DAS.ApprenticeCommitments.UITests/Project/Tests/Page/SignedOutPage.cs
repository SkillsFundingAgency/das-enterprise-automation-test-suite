using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SignedOutPage(ScenarioContext context) : ApprenticeCommitmentsBasePage(context)
    {
        protected override string PageTitle => "You have successfully signed out";

        public SignIntoMyApprenticeshipPage ClickSignBackInLinkFromSignOutPage()
        {
            formCompletionHelper.ClickLinkByText("sign back in");
            return new SignIntoMyApprenticeshipPage(context);
        }
    }
}
