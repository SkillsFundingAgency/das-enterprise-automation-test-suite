using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpadmin"), Scope(Tag = "roatpassessoradmin")]
    public class RoatpAdminHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
        private readonly RoatpAdminSqlDbHelper _adminClearDownDataHelpers;
        private readonly RoatpApplySqlDbHelper _roatpApplyClearDownDataHelpers;

        public RoatpAdminHooks(ScenarioContext context) : base(context)
        {
            _context = context;
            _adminClearDownDataHelpers = new RoatpAdminSqlDbHelper(config);
            _roatpApplyClearDownDataHelpers = new RoatpApplySqlDbHelper(config);
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => SetUpAdminDataHelpers();

        [BeforeScenario(Order = 33)]
        public void GetRoatpAdminData()
        {
            if (!_context.ScenarioInfo.Tags.Contains("notestdata"))
            {
                // every scenario (admin) should only have one tag which starts with rpad, which is mapped to the test data.
                var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rpad"));
                var (providername, ukprn) = new RoatpAdminUkprnDataHelpers().GetRoatpAdminData(tag);

                objectContext.SetProviderName(providername);
                objectContext.SetUkprn(ukprn);
            }
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("deletetrainingprovider"))
                _adminClearDownDataHelpers.DeleteTrainingProvider(objectContext.GetUkprn());
        }

        [BeforeScenario(Order = 35)]
        public void ClearDownGateWayAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("resetApplicationToNew"))
                _roatpApplyClearDownDataHelpers.GateWayClearDownDataFromApply(objectContext.GetUkprn());
        }

        [BeforeScenario(Order = 36)]
        public void ClearDownFHAAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("resetFhaApplicationToNew"))
                _roatpApplyClearDownDataHelpers.FHAClearDownDataFromApply(objectContext.GetUkprn());
        }

        [BeforeScenario(Order = 37)]
        public void ClearDownAssessorAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("roatpassessoradmin"))
                _roatpApplyClearDownDataHelpers.AssessorClearDownDataFromApply(objectContext.GetUkprn());
        }

        [BeforeScenario(Order = 38)]
        public void ClearDownModeratorAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("roatpmoderator"))
                _roatpApplyClearDownDataHelpers.ModeratorClearDownDataFromApply(objectContext.GetUkprn());
        }
    }
}
