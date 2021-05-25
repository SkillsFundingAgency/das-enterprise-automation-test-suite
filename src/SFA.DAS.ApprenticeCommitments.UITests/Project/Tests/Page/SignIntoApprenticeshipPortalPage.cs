using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SignIntoApprenticeshipPortalPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Sign in to Apprenticeship portal";

        private readonly ScenarioContext _context;
        private By Username => By.CssSelector("#Username");
        private By Password => By.CssSelector("#Password");
        private By SignInButton => By.XPath("//button[contains(text(),'Sign in')]");

        public SignIntoApprenticeshipPortalPage(ScenarioContext context) : base(context) => _context = context;

        public ConfirmYourIdentityPage SignInToApprenticePortal()
        {
            SignIn();
            return new ConfirmYourIdentityPage(_context);
        }

        public SignedOutPage SignInAfterSignUp()
        {
            SignIn();
            return new SignedOutPage(_context);
        }

        public ForgottenPasswordPage Resetpassword()
        {
            formCompletionHelper.ClickLinkByText("I have forgotten my password");
            return new ForgottenPasswordPage(_context);
        }

        private void SignIn()
        {
            formCompletionHelper.EnterText(Username, objectContext.GetApprenticeEmail());
            formCompletionHelper.EnterText(Password, apprenticeCommitmentsConfig.AC_AccountPassword);
            formCompletionHelper.ClickButtonByText(SignInButton, "Sign in");
        }
    }
}
