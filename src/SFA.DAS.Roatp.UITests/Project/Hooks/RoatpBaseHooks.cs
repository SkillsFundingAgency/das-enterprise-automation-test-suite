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
        protected readonly ObjectContext _objectContext;
        private readonly RoatpApplyAndQnASqlDbHelper _roatpApplyAndQnASqlDbHelper;
        private readonly RoatpAdminSqlDbHelper _adminClearDownDataHelpers;
        protected readonly RoatpConfig config;
        protected readonly DbConfig _dbConfig;

        private readonly RoatpApplyUkprnDataHelpers _roatpApplyUkprnDataHelpers;
        private readonly RoatpApplyTestDataPrepDataHelpers _roatpApplyTestDataPrepDataHelpers;
        private readonly RoatpApplyChangeUkprnDataHelpers _roatpApplyChangeUkprnDataHelpers;
        private readonly NewRoatpAdminUkprnDataHelpers _roatpAdminUkprnDataHelpers;
        private readonly OldRoatpAdminUkprnDataHelpers _roatpOldAdminUkprnDataHelpers;
        private readonly RoatpFullUkprnDataHelpers _roatpFullUkprnDataHelpers;

        public RoatpBaseHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
            config = context.GetRoatpConfig<RoatpConfig>();
            _dbConfig = context.Get<DbConfig>();
            _roatpApplyAndQnASqlDbHelper = new RoatpApplyAndQnASqlDbHelper(_objectContext, _dbConfig);
            _adminClearDownDataHelpers = new RoatpAdminSqlDbHelper(_dbConfig);
            _roatpApplyUkprnDataHelpers = new RoatpApplyUkprnDataHelpers();
            _roatpApplyTestDataPrepDataHelpers = new RoatpApplyTestDataPrepDataHelpers();
            _roatpApplyChangeUkprnDataHelpers = new RoatpApplyChangeUkprnDataHelpers();
            _roatpAdminUkprnDataHelpers = new NewRoatpAdminUkprnDataHelpers();
            _roatpOldAdminUkprnDataHelpers = new OldRoatpAdminUkprnDataHelpers();
            _roatpFullUkprnDataHelpers = new RoatpFullUkprnDataHelpers();
        }

        protected void GoToUrl(string url) => _tabHelper.GoToUrl(url);

        protected void SetUpAdminDataHelpers() => _context.Set(new RoatpAdminDataHelpers(_context.Get<RandomDataGenerator>()));

        protected void SetUpApplyDataHelpers() => _context.Set(new RoatpApplyDataHelpers(_context.Get<RandomDataGenerator>()));

        protected void SetUpCreateAccountApplyDataHelpers() => _context.Set(new RoatpApplyCreateUserDataHelpers(config));

        protected void ClearDownApplyData() => _roatpApplyAndQnASqlDbHelper.ClearDownDataFromQna(_roatpApplyAndQnASqlDbHelper.ClearDownDataFromApply());

        protected void ClearDownDataUkprnFromApply(string ukprn) => _roatpApplyAndQnASqlDbHelper.ClearDownDataFromQna(_roatpApplyAndQnASqlDbHelper.ClearDownDataUkprnFromApply(ukprn));

        protected void WhiteListProviders(string ukprn = null) => _roatpApplyAndQnASqlDbHelper.WhiteListProviders(ukprn);

        protected void DeleteTrainingProvider() => _adminClearDownDataHelpers.DeleteTrainingProvider(GetUkprn());

        protected void GetRoatpAppplyData() => SetDetails(_roatpApplyUkprnDataHelpers.GetRoatpAppplyData(GetTag("rp")));

        protected void GetRoatpApplyTestDataPrepData() => SetDetails(_roatpApplyTestDataPrepDataHelpers.GetRoatpAppplyData(GetTag("rptestdata")));

        protected void GetRoatpChangeUkprnAppplyData()
        {
            // every scenario (apply) should only have one tag which starts with rp, which is mapped to the test data.
            var (email, ukprn, newukprn) = _roatpApplyChangeUkprnDataHelpers.GetRoatpChangeUkprnAppplyData(GetTag("rpchangeukprn"));

            SetEmail(email);
            SetUkprn(ukprn);
            SetNewUkprn(newukprn);
        }

        protected void GetOldRoatpAdminData()
        {
            // every scenario (admin) should only have one tag which starts with rpad, which is mapped to the test data.
            var (providername, ukprn) = _roatpOldAdminUkprnDataHelpers.GetOldRoatpAdminData(GetTag("rpad"));

            SetProviderName(providername);
            SetUkprn(ukprn);
        }

        protected void GetNewRoatpAdminData() => SetDetails(_roatpAdminUkprnDataHelpers.GetNewRoatpAdminData(GetTag("rpad")));

        protected void GetRoatpFullData() => SetDetails(_roatpFullUkprnDataHelpers.GetRoatpE2EData(GetTag("rp")));

        protected string GetUkprn() => _objectContext.GetUkprn();

        private void SetEmail(string email)
        { 
            _objectContext.SetEmail(email);

            if (_context.ScenarioInfo.Tags.Contains("perftestroatpapplye2e"))
            {
                _objectContext.SetPassword("RoatpAutomation123");
            }
            else
            {
                _objectContext.SetPassword(config.ApplyPassword);
            }
        }

        private void SetDetails((string email, string providername, string ukprn) p)
        {
            SetEmail(p.email);
            SetProviderName(p.providername);
            SetUkprn(p.ukprn);
        }

        private void SetDetails((string email, string ukprn) p)
        {
            SetEmail(p.email);
            SetUkprn(p.ukprn);
        }

        private void SetProviderName(string providername) => _objectContext.SetProviderName(providername);
        private void SetUkprn(string ukprn) => _objectContext.SetUkprn(ukprn);
        private void SetNewUkprn(string ukprn) => _objectContext.SetNewUkprn(ukprn);

        private string GetTag(string tag) => _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith(tag));
    }
}
