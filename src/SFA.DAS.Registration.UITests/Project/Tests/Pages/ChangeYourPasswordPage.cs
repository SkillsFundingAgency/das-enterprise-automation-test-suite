using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangeYourPasswordPage : RegistrationBasePage
    {
        protected override string PageTitle => "Change your password";

        public ChangeYourPasswordPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}