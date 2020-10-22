using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public abstract class ConsolidatedSupportBasePage : BasePage
    {
        protected readonly IFrameHelper frameHelper;
        protected readonly ConsolidatedSupportConfig config;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly ConsolidateSupportDataHelper dataHelper;

        public ConsolidatedSupportBasePage(ScenarioContext context) : base(context)
        {
            frameHelper = context.Get<IFrameHelper>();
            config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            dataHelper = context.Get<ConsolidateSupportDataHelper>();
        }
    }
}
