using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class UsedThisServiceBeforePage : RoatpBasePage
    {
        protected override string PageTitle => "Is this your first time using the apprenticeship service (AS) sign in?";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FirstTimeSignInNoOption => By.Id("FirstTimeSignin-No");
        
        public UsedThisServiceBeforePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplySignInPage SelectingNoOptionForFirstTimeSignInAndContinue()
        {
            formCompletionHelper.ClickElement(FirstTimeSignInNoOption);
            Continue();
            return new ApplySignInPage(_context);
        }
    }

}
