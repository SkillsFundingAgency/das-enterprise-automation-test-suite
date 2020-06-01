using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public abstract class ProviderLeadRegistrationBasePage : RegistrationBasePage
    {

        protected ProviderLeadRegistrationBasePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
