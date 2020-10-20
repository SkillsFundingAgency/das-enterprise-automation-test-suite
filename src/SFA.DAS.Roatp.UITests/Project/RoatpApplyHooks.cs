using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding, Scope(Tag = "roatpapply")]
    public class RoatpApplyHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
        private readonly RoatpApplyAndQnASqlDbHelper _roatpApplyAndQnASqlDbHelper;
        private RoatpApplyUkprnDataHelpers _applyUkprnDataHelpers;

        public RoatpApplyHooks(ScenarioContext context) : base(context)
        {
            _context = context;
            _roatpApplyAndQnASqlDbHelper = new RoatpApplyAndQnASqlDbHelper(objectContext, config);
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _applyUkprnDataHelpers = new RoatpApplyUkprnDataHelpers();
            _context.Set(_applyUkprnDataHelpers);

            _context.Set(new RoatpApplyDataHelpers(_context.Get<RandomDataGenerator>()));
        }

        [BeforeScenario(Order = 33)]
        public void GetRoatpAppplyData()
        {
            // every scenario (apply) should only have one tag which starts with rp, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rp"));
            var (email, ukprn) = _applyUkprnDataHelpers.GetRoatpAppplyData(tag);

            objectContext.SetEmail(email);
            objectContext.SetUkprn(ukprn);
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownApplyData() => _roatpApplyAndQnASqlDbHelper.ClearDownDataFromQna(_roatpApplyAndQnASqlDbHelper.ClearDownDataFromApply());

        [BeforeScenario(Order = 35)]
        public void WhiteListProviders() => _roatpApplyAndQnASqlDbHelper.WhiteListProviders();
    }
}
