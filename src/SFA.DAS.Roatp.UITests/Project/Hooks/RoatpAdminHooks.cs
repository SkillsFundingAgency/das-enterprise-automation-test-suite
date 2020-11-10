using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
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
        public new void GetRoatpAdminData() => base.GetRoatpAdminData();

        [BeforeScenario(Order = 34)]
        public void ClearDownAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("deletetrainingprovider"))
                _adminClearDownDataHelpers.DeleteTrainingProvider(GetUkprn());
        }

        [BeforeScenario(Order = 35)]
        public void ClearDownGateWayAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("resetApplicationToNew"))
                _roatpApplyClearDownDataHelpers.GateWayClearDownDataFromApply(GetUkprn());
        }

        [BeforeScenario(Order = 36)]
        public void ClearDownFHAAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("resetFhaApplicationToNew"))
                _roatpApplyClearDownDataHelpers.FHAClearDownDataFromApply(GetUkprn());
        }

        [BeforeScenario(Order = 37)]
        public void ClearDownAssessorAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("roatpassessoradmin"))
                _roatpApplyClearDownDataHelpers.AssessorClearDownDataFromApply(GetUkprn());
        }

        [BeforeScenario(Order = 38)]
        public void ClearDownModeratorAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("roatpmoderator"))
                _roatpApplyClearDownDataHelpers.ModeratorClearDownDataFromApply(GetUkprn());
        }

        [BeforeScenario(Order = 39)]
        public void ClearDownClarificationAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("roatpclarification"))
                _roatpApplyClearDownDataHelpers.ClarificationClearDownFromApply(GetUkprn());
        }
    }
}
