using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "oldroatpadmin")]
    public class OldRoatpAdminHooks : RoatpBaseHooks
    {
        private readonly string[] _tags;

        public OldRoatpAdminHooks(ScenarioContext context) : base(context) { _tags = context.ScenarioInfo.Tags; }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => SetUpAdminDataHelpers();

        [BeforeScenario(Order = 33)]
        public new void GetOldRoatpAdminData()
        {
            if (!_tags.Any( x => x == "oldroatpadmindownloadprovider" || x == "rpadoutcome01")) base.GetOldRoatpAdminData();
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownAdminData()
        {
            if (_tags.Any(x => x == "deletetrainingprovider")) DeleteTrainingProvider();
        }
    }
}
