using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    public abstract class RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        protected readonly RoatpConfig config;
        protected readonly ObjectContext objectContext;
        protected readonly RoatpApplyAndQnASqlDbHelper roatpApplyAndQnASqlDbHelper;

        public RoatpBaseHooks(ScenarioContext context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            config = context.GetRoatpConfig<RoatpConfig>();
            _tabHelper = context.Get<TabHelper>();
            roatpApplyAndQnASqlDbHelper = new RoatpApplyAndQnASqlDbHelper(objectContext, config);
        }

        protected void GoToUrl(string url) => _tabHelper.GoToUrl(url);

        protected void SetUpAdminDataHelpers() => _context.Set(new RoatpAdminDataHelpers(_context.Get<RandomDataGenerator>()));

        protected void SetUpApplyDataHelpers() => _context.Set(new RoatpApplyDataHelpers(_context.Get<RandomDataGenerator>()));

        protected void ClearDownApplyData() => roatpApplyAndQnASqlDbHelper.ClearDownDataFromQna(roatpApplyAndQnASqlDbHelper.ClearDownDataFromApply());

        protected void WhiteListProviders() => roatpApplyAndQnASqlDbHelper.WhiteListProviders();
    }
}
