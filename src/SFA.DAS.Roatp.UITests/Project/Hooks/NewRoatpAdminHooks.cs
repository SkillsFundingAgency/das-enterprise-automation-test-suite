using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "newroatpadmin")]
    public class NewRoatpAdminHooks : RoatpBaseHooks
    {
        private readonly string[] _tags;
        private readonly RoatpApplySqlDbHelper _roatpApplyClearDownDataHelpers;

        public NewRoatpAdminHooks(ScenarioContext context) : base(context)
        {
            _tags = context.ScenarioInfo.Tags;
            _roatpApplyClearDownDataHelpers = new RoatpApplySqlDbHelper(_dbConfig);
        }

        [BeforeScenario(Order = 33)]
        public new void GetNewRoatpAdminData() { if (!_tags.Contains("newroatpadminreporting")) base.GetNewRoatpAdminData(); }

        [BeforeScenario(Order = 35)]
        public void ClearDownGateWayAdminData()
        {
            if (_tags.Contains("resetApplicationToNew"))
                _roatpApplyClearDownDataHelpers.GateWayClearDownDataFromApply(GetUkprn());
        }

        [BeforeScenario(Order = 36)]
        public void ClearDownFHAAdminData()
        {
            if (_tags.Contains("resetFhaApplicationToNew"))
                _roatpApplyClearDownDataHelpers.FHAClearDownDataFromApply(GetUkprn());
        }

        [BeforeScenario(Order = 37)]
        public void ClearDownAssessorAdminData()
        {
            if (_tags.Contains("roatpassessoradmin"))
                _roatpApplyClearDownDataHelpers.AssessorClearDownDataFromApply(GetUkprn());
        }

        [BeforeScenario(Order = 38)]
        public void ClearDownModeratorAdminData()
        {
            if (_tags.Contains("roatpmoderator"))
                _roatpApplyClearDownDataHelpers.ModeratorClearDownDataFromApply(GetUkprn());
        }

        [BeforeScenario(Order = 39)]
        public void ClearDownClarificationAdminData()
        {
            if (_tags.Contains("roatpclarification"))
                _roatpApplyClearDownDataHelpers.ClarificationClearDownFromApply(GetUkprn());
        }
        [BeforeScenario(Order = 40)]
        public void ClearDown_UKPRN_Allowlisttable()
        {
            if (_tags.Contains("rpallowlist"))
                _roatpApplyClearDownDataHelpers.Delete_AllowListProviders(GetUkprn());
        }
    }
}
