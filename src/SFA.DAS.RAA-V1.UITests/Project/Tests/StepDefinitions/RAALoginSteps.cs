using NUnit.Framework;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RAALoginSteps
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly RAAV1Config _config;

        public RAALoginSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _tabHelper = context.Get<TabHelper>();
        }

        [Then(@"the provider is not be able to log in with Invalid credentials")]
        public void ThenTheProviderIsNotBeAbleToLogInWithInvalidCredentials()
        {
            GoToRecruitBaseUrl();

            GotoSignInPage()
                .SubmitRecruitmentInvalidLoginDetails();
        }

        [Then(@"the provider should be able to submit the userId for password reset")]
        public void ThenTheProviderShouldBeAbleToSubmitTheUserIdForPasswordReset()
        {
            GoToRecruitBaseUrl();

            var text = GotoSignInPage()
              .ForgotMyPassword()
              .ResetPassword()
              .FormInfoText();

            StringAssert.Contains("We have sent you an email containing a password reset link.", text);
        }

        [Then(@"the provider should be able to register the account")]
        public void ThenTheProviderShouldBeAbleToRegisterTheAccount()
        {
            GoToRecruitBaseUrl();

            var text = GotoSignInPage()
              .CreateNewAccount()
              .Register()
              .FormInfoText();

            StringAssert.Contains("We have sent you an email for verification.", text);
        }

        private void GoToRecruitBaseUrl()
        {
            _tabHelper.GoToUrl(_config.RecruitBaseUrl);
        }

        private SignInPage GotoSignInPage()
        {
            return new RAA_IndexPage(_context)
             .ClickOnSignInButton()
             .RecruitStaffIdams();
        }
    }
}
