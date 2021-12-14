using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public abstract class ProviderLoginBasePage : VerifyBasePage
    {
        public ProviderLoginBasePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
