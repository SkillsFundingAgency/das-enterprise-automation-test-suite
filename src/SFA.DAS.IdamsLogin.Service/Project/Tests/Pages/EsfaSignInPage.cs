using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public class EsfaSignInPage : SignInBasePage
    {
        protected override string PageTitle => "ESFA Sign in";

        public EsfaSignInPage(ScenarioContext context) : base(context) { }
    }
}
