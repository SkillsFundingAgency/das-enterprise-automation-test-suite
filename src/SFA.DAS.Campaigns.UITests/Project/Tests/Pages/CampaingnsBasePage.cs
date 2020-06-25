using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public abstract class CampaingnsBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly CampaignsDataHelper campaignsDataHelper;
        protected readonly TabHelper tabHelper;
        #endregion

        public CampaingnsBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            campaignsDataHelper = context.Get<CampaignsDataHelper>();
            tabHelper = context.Get<TabHelper>();

            if (verifypage) { VerifyPage(); }
        }
    }
}
