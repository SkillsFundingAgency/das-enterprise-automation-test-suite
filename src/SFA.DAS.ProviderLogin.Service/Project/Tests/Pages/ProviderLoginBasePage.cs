using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public abstract class ProviderLoginBasePage : BasePage
    {
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;

        public ProviderLoginBasePage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
    }
}
