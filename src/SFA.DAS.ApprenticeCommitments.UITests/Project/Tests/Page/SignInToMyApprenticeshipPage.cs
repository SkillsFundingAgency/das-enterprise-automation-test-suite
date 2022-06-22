using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SignIntoMyApprenticeshipPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => $"Sign in to {ServiceName}";
        protected override By ServiceHeader => NonClickableServiceHeader;
        private By Username => By.CssSelector("#Username");
        private By SignInButton => By.XPath("//button[contains(text(),'Sign in')]");

        public SignIntoMyApprenticeshipPage(ScenarioContext context) : base(context)  { }

        public CreateMyApprenticeshipAccountPage SignInToApprenticePortalForPersonalDetailsUnVerifiedAccount()
        {
            VerifyElement(PrivacyLinkInTheBody);
            SignIn();
            return new CreateMyApprenticeshipAccountPage(context);
        }

        public ApprenticeHomePage GoToApprenticeHomePage()
        {
            SignIn();
            return new ApprenticeHomePage(context);
        }

        public ApprenticeOverviewPage GoToApprenticeOverviewPage(bool verifypage)
        {
            SignIn();
            return new ApprenticeOverviewPage(context, verifypage);
        }

        public ApprenticeOverviewPage CocSignInToApprenticePortal()
        {
            SignIn();
            return new ApprenticeOverviewPage(context);
        }

        public ForgottenPasswordPage ClickChangeYourPasswordLinkOnSignInPage()
        {
            formCompletionHelper.ClickLinkByText("change your password");
            return new ForgottenPasswordPage(context);
        }

        private void SignIn()
        {
            formCompletionHelper.EnterText(Username, objectContext.GetApprenticeEmail());
            formCompletionHelper.EnterText(Password, objectContext.GetApprenticePassword());
            formCompletionHelper.Click(SignInButton);
        }

        public CreateLoginDetailsPage ClickCreateAnAccountLinkOnSignInPage()
        {
            formCompletionHelper.ClickLinkByText("Create an account");
            return new CreateLoginDetailsPage(context);
        }
    }
}
