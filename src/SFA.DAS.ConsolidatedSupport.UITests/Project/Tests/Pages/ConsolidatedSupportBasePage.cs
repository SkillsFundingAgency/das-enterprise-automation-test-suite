using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public abstract class ConsolidatedSupportBasePage : BasePage
    {
        protected readonly IFrameHelper frameHelper;
        protected readonly ConsolidatedSupportConfig config;
        protected readonly FormCompletionHelper _formCompletionHelper;
        protected readonly PageInteractionHelper _pageInteractionHelper;

        public ConsolidatedSupportBasePage(ScenarioContext context) : base(context)
        {
            frameHelper = context.Get<IFrameHelper>();
            config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }
    }
}
