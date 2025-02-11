using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public abstract class CampaingnsBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly CampaignsDataHelper campaignsDataHelper;
        #endregion

        public CampaingnsBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            campaignsDataHelper = context.Get<CampaignsDataHelper>();
            if (verifypage) { VerifyPage(); }
        }
    }
}
