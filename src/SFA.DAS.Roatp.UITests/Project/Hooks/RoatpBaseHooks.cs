using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
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

        protected void GetRoatpAppplyData()
        {
            // every scenario (apply) should only have one tag which starts with rp, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rp"));

            var (email, ukprn) = new RoatpApplyUkprnDataHelpers().GetRoatpAppplyData(tag);

            objectContext.SetEmail(email);
            objectContext.SetUkprn(ukprn);
        }

        public void GetRoatpAdminData()
        {
            // every scenario (admin) should only have one tag which starts with rpad, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rpad"));
            var (providername, ukprn) = new RoatpAdminUkprnDataHelpers().GetRoatpAdminData(tag);

            objectContext.SetProviderName(providername);
            objectContext.SetUkprn(ukprn);
        }

        public void GetRoatpFullData()
        {
            // every scenario should only have one tag which starts with rp, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rp"));

            (string email, string providername, string ukprn) = new RoatpFullUkprnDataHelpers().GetRoatpE2EData(tag);

            objectContext.SetEmail(email);
            objectContext.SetProviderName(providername);
            objectContext.SetUkprn(ukprn);
        }
    }
}
