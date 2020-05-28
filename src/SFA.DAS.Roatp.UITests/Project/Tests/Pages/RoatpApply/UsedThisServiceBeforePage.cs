using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class UsedThisServiceBeforePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Do you have an apprenticeship service (AS) sign in account?";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UsedThisServiceBeforePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SignInToRegisterPage SelectingYesOptionForASSignInAccountAndContinue()
        {
            SelectRadioOptionByForAttribute("FirstTimeSignin-No");
            Continue();
            return new SignInToRegisterPage(_context);
        }
    }
}
