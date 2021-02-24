using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "newroatpadmin")]
    public class NewRoatpAdminHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
        private readonly RoatpApplySqlDbHelper _roatpApplyClearDownDataHelpers;

        public NewRoatpAdminHooks(ScenarioContext context) : base(context)
        {
            _context = context;
            _roatpApplyClearDownDataHelpers = new RoatpApplySqlDbHelper(config);
        }


        [BeforeScenario(Order = 33)]
        public new void GetNewRoatpAdminData() => base.GetNewRoatpAdminData();

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

        [BeforeScenario(Order = 39)]
        public void ClearDownOutcomeAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("roatpoutcome"))
            {
                _roatpApplyClearDownDataHelpers.OutcomeClearDownFromApply(GetUkprn());

                DeleteTrainingProvider();
            }
        }
    }
}
