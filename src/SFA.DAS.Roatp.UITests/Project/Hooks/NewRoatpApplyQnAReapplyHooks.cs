using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "rpadgatewayrejectreapplications01")]
    public class NewRoatpApplyQnAReapplyHooks : RoatpBaseHooks
    {
        private readonly RoatpApplySqlDbHelper _roatpApplyClearDownDataHelpers;

        public NewRoatpApplyQnAReapplyHooks (ScenarioContext context) : base(context) => _roatpApplyClearDownDataHelpers = new RoatpApplySqlDbHelper(_dbConfig);

        [BeforeScenario(Order = 33)]
        public void OversightReviewClearDownFromApply() => _roatpApplyClearDownDataHelpers.OversightReviewClearDownFromApply_GatewayReject(GetUkprn());

        [AfterScenario(Order = 34)]
        public void ClearDownTrainingProviderFromRegister() => DeleteTrainingProvider();        
           
        [AfterScenario(Order = 35)]
        public void ClearDownReappliedTrainingProviderData_Apply() 
        {
                ClearDownQnAData_ReappliedApplication(GetUkprn());
                ClearDownApplyData_ReappliedApplication(GetUkprn());
        }
    } 
}
