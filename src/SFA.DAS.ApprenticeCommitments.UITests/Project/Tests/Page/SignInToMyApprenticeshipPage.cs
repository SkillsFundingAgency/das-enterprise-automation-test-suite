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
            VerifyPage(PrivacyLinkInTheBody);
            SignIn();
            return new CreateMyApprenticeshipAccountPage(context);
        }

        public ApprenticeHomePage GoToApprenticeHomePage()
        {
            SignIn();
            return new ApprenticeHomePage(context);
        }

        public ApprenticeOverviewPage CocSignInToApprenticePortal()
        {
            SignIn();
            return new ApprenticeOverviewPage(context);
        }

        public ForgottenPasswordPage ClickForgottenMyPasswordLinkOnSignInPage()
        {
            formCompletionHelper.ClickLinkByText("I have forgotten my password");
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
            formCompletionHelper.ClickLinkByText("create an account");
            return new CreateLoginDetailsPage(context);
        }
    }
}
