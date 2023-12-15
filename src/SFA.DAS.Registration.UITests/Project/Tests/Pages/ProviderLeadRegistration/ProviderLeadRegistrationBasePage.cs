using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public abstract class ProviderLeadRegistrationBasePage : RegistrationBasePage
    {

        protected ProviderLeadRegistrationBasePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
