using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AccountUnavailablePage : RegistrationBasePage
    {
        protected override string PageTitle => "This account is unavailable";

        public AccountUnavailablePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
