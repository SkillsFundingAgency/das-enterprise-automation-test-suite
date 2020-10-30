using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    public class RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        protected readonly RoatpConfig config;
        protected readonly ObjectContext objectContext;
        private readonly RoatpApplyAndQnASqlDbHelper _roatpApplyAndQnASqlDbHelper;

        public RoatpBaseHooks(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            objectContext = context.Get<ObjectContext>();
            config = context.GetRoatpConfig<RoatpConfig>();
            _roatpApplyAndQnASqlDbHelper = new RoatpApplyAndQnASqlDbHelper(objectContext, config);
        }

        protected void GoToUrl(string url) => _tabHelper.GoToUrl(url);

        protected void SetUpApplyDataHelpers() => _context.Set(new RoatpApplyDataHelpers(_context.Get<RandomDataGenerator>()));

        protected void SetUpAdminDataHelpers() => _context.Set(new RoatpAdminDataHelpers(_context.Get<RandomDataGenerator>()));

        public void ClearDownApplyData() => _roatpApplyAndQnASqlDbHelper.ClearDownDataFromQna(_roatpApplyAndQnASqlDbHelper.ClearDownDataFromApply());

        public void WhiteListProviders() => _roatpApplyAndQnASqlDbHelper.WhiteListProviders();
    }
}
