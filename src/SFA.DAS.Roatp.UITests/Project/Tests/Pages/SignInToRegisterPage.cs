using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class SignInToRegisterPage : RoatpBasePage
    {
        protected override string PageTitle => "Sign in to Register of apprenticeship training providers service";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EnterUsername => By.Id("Username");

        private By EnterPassword => By.Id("Password");

        public SignInToRegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TermsConditionsMakingApplicationPage SubmitValidUserDetails()
        {
            formCompletionHelper.EnterText(EnterUsername, objectContext.GetEmail());
            formCompletionHelper.EnterText(EnterPassword, roatpConfig.ApplyPassword);
            Continue();
            return new TermsConditionsMakingApplicationPage(_context);
        }
    }
}
