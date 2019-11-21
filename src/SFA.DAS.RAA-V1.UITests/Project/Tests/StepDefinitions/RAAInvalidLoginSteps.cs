using NUnit.Framework;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RAAInvalidLoginSteps
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly RAAV1Config _config;

        public RAAInvalidLoginSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _tabHelper = context.Get<TabHelper>();
        }

        [Then(@"the provider is not be able to log in with Invalid credentials")]
        public void ThenTheProviderIsNotBeAbleToLogInWithInvalidCredentials()
        {
            _tabHelper.GoToUrl(_config.RecruitBaseUrl);

            new RAA_IndexPage(_context)
               .ClickOnSignInButton()
               .RecruitStaffIdams()
               .SubmitRecruitmentInvalidLoginDetails();
        }

        [Then(@"the provider should be able to submit the userId for password reset")]
        public void ThenTheProviderShouldBeAbleToSubmitTheUserIdForPasswordReset()
        {
            _tabHelper.GoToUrl(_config.RecruitBaseUrl);

            var text = new RAA_IndexPage(_context)
              .ClickOnSignInButton()
              .RecruitStaffIdams()
              .ForgotMyPassword()
              .ResetPassword()
              .FormInfoText();

            Assert.AreEqual("We have sent you an email containing a password reset link.", text);
        }
    }
}
