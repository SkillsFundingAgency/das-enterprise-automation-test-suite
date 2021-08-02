using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class TermsAndConditionsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Terms of use";

        public TermsAndConditionsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
