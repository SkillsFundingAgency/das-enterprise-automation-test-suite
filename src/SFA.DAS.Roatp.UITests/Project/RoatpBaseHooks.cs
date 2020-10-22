using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    public class RoatpBaseHooks
    {
        private readonly TabHelper _tabHelper;
        protected readonly RoatpConfig config;
        protected readonly ObjectContext objectContext;

        public RoatpBaseHooks(ScenarioContext context)
        {
            _tabHelper = context.Get<TabHelper>();
            objectContext = context.Get<ObjectContext>();
            config = context.GetRoatpConfig<RoatpConfig>();
        }

        protected void GoToUrl(string url) => _tabHelper.GoToUrl(url);
    }
}
