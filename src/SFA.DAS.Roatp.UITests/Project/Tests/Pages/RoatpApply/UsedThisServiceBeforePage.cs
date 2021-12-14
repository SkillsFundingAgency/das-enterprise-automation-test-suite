using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class UsedThisServiceBeforePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Do you have an apprenticeship service (AS) sign in account?";
        
        public UsedThisServiceBeforePage(ScenarioContext context) : base(context) => VerifyPage();

        public SignInToRegisterPage SelectOptionToSignInToASAccountAndContinue()
        {
            SelectRadioOptionByForAttribute("FirstTimeSignin");
            Continue();
            return new SignInToRegisterPage(context);
        }

        public CreateAnAccountPage SelectNoCreateAccountAndContinue()
        {
            SelectRadioOptionByForAttribute("FirstTimeSignin-Yes");
            Continue();
            return new CreateAnAccountPage(context);
        }
    }
}
