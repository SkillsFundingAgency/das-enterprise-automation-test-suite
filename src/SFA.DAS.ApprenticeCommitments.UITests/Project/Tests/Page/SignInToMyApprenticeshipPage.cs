using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SignIntoMyApprenticeshipPage(ScenarioContext context) : ApprenticeCommitmentsBasePage(context)
    {
        protected override string PageTitle => StubSignInApprenticeAccountsPage.StubSignInPageTitle;
        private static By Username => By.CssSelector("#Username");
        private static By SignInButton => By.XPath("//button[contains(text(),'Sign in')]");

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

        public FullyConfirmedOverviewPage SignInWithUpdatedEmail()
        {
            formCompletionHelper.EnterText(Username, objectContext.GetApprenticeChangedEmail());
            formCompletionHelper.EnterText(Password, objectContext.GetApprenticePassword());
            formCompletionHelper.Click(SignInButton);
            return new FullyConfirmedOverviewPage(context);
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
            new StubSignInApprenticeAccountsPage(context).SubmitValidUserDetails(objectContext.GetApprenticeEmail(), objectContext.GetApprenticePassword()).Continue();
        }

        public CreateLoginDetailsPage ClickCreateAnAccountLinkOnSignInPage()
        {
            formCompletionHelper.ClickLinkByText("Create an account");
            return new CreateLoginDetailsPage(context);
        }
    }
}
