using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ApplySignInPage : RoatpBasePage
    {
        protected override string PageTitle => "Is this your first time using the apprenticeship service (AS) sign in?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EnterUsername => By.Id("Username");
        private By EnterPassword => By.Id("Password");

        public ApplySignInPage(ScenarioContext context) : base(context)
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
