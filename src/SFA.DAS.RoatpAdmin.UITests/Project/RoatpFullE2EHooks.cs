using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Hooks;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project
{
    [Binding, Scope(Tag = "roatpfulle2e")]
    public class RoatpFullE2EHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;

        public RoatpFullE2EHooks(ScenarioContext context) : base(context) => _context = context;

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            SetUpApplyDataHelpers();
            SetUpAdminDataHelpers();
        }

        [BeforeScenario(Order = 33)]
        public void GetRoatpE2EData()
        {
            // every scenario should only have one tag which starts with rp, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rp"));

            (string email, string providername, string ukprn) = new RoatpFullE2EUkprnDataHelpers().GetRoatpE2EData(tag);

            objectContext.SetEmail(email);
            objectContext.SetProviderName(providername);
            objectContext.SetUkprn(ukprn);
        }

        [BeforeScenario(Order = 34)]
        public new void ClearDownApplyData() => base.ClearDownApplyData();

        [BeforeScenario(Order = 35)]
        public new void WhiteListProviders() => base.WhiteListProviders();
    }
}
