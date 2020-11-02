using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpapply")]
    public class RoatpApplyHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;

        public RoatpApplyHooks(ScenarioContext context) : base(context) => _context = context;

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => SetUpApplyDataHelpers();

        [BeforeScenario(Order = 33)]
        public void GetRoatpAppplyData()
        {
            // every scenario (apply) should only have one tag which starts with rp, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rp"));

            var (email, ukprn) = new RoatpApplyUkprnDataHelpers().GetRoatpAppplyData(tag);

            objectContext.SetEmail(email);
            objectContext.SetUkprn(ukprn);
        }

        [BeforeScenario(Order = 34)]
        public new void ClearDownApplyData() => base.ClearDownApplyData();

        [BeforeScenario(Order = 35)]
        public new void WhiteListProviders() => base.WhiteListProviders();
    }
}
