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
        private readonly ObjectContext _objectContext;
        private readonly RoatpApplyAndQnASqlDbHelper _roatpApplyAndQnASqlDbHelper;
        protected readonly RoatpConfig config;

        public RoatpBaseHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
            config = context.GetRoatpConfig<RoatpConfig>();
            _roatpApplyAndQnASqlDbHelper = new RoatpApplyAndQnASqlDbHelper(_objectContext, config);
        }

        protected void GoToUrl(string url) => _tabHelper.GoToUrl(url);

        protected void SetUpAdminDataHelpers() => _context.Set(new RoatpAdminDataHelpers(_context.Get<RandomDataGenerator>()));

        protected void SetUpApplyDataHelpers() => _context.Set(new RoatpApplyDataHelpers(_context.Get<RandomDataGenerator>()));

        protected void ClearDownApplyData() => _roatpApplyAndQnASqlDbHelper.ClearDownDataFromQna(_roatpApplyAndQnASqlDbHelper.ClearDownDataFromApply());

        protected void WhiteListProviders() => _roatpApplyAndQnASqlDbHelper.WhiteListProviders();

        protected void GetRoatpAppplyData()
        {
            // every scenario (apply) should only have one tag which starts with rp, which is mapped to the test data.
            var (email, ukprn) = new RoatpApplyUkprnDataHelpers().GetRoatpAppplyData(GetTag("rp"));

            SetEmail(email);
            SetUkprn(ukprn);
        }

        public void GetRoatpAdminData()
        {
            // every scenario (admin) should only have one tag which starts with rpad, which is mapped to the test data.
            var (providername, ukprn) = new RoatpAdminUkprnDataHelpers().GetRoatpAdminData(GetTag("rpad"));

            SetProviderName(providername);
            SetUkprn(ukprn);
        }

        public void GetRoatpFullData()
        {
            // every scenario should only have one tag which starts with rp, which is mapped to the test data.
            (string email, string providername, string ukprn) = new RoatpFullUkprnDataHelpers().GetRoatpE2EData(GetTag("rp"));

            SetEmail(email);
            SetProviderName(providername);
            SetUkprn(ukprn);
        }

        protected string GetUkprn() => _objectContext.GetUkprn();

        private void SetEmail(string email) => _objectContext.SetEmail(email);
        private void SetProviderName(string providername) => _objectContext.SetProviderName(providername);
        private void SetUkprn(string ukprn) => _objectContext.SetUkprn(ukprn);

        private string GetTag(string tag) => _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith(tag));
    }
}
