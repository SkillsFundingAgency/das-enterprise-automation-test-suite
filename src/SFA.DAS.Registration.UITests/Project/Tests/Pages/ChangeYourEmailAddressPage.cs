using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangeYourEmailAddressPage : RegistrationBasePage
    {
        protected override string PageTitle => "Change your email address";

        public ChangeYourEmailAddressPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}