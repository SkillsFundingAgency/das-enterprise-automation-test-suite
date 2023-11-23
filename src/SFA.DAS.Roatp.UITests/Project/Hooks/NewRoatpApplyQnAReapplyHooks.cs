using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "rpadgatewayrejectreapplications01")]
    public class NewRoatpApplyQnAReapplyHooks : RoatpBaseHooks
    {
        private readonly RoatpApplySqlDbHelper _roatpApplyClearDownDataHelpers;

        private readonly TryCatchExceptionHelper _tryCatch;

        public NewRoatpApplyQnAReapplyHooks(ScenarioContext context) : base(context)
        {
            _tryCatch = context.Get<TryCatchExceptionHelper>();
            _roatpApplyClearDownDataHelpers = new RoatpApplySqlDbHelper(_objectContext, _dbConfig);
        }

        [BeforeScenario(Order = 33)]
        public void OversightReviewClearDownFromApply() => _roatpApplyClearDownDataHelpers.OversightReviewClearDownFromApply_GatewayReject(GetUkprn());

        [AfterScenario(Order = 34)]
        public void ClearDownTrainingProviderFromRegister() => _tryCatch.AfterScenarioException(DeleteTrainingProvider);

        [AfterScenario(Order = 35)]
        public void ClearDownReappliedTrainingProviderData_Apply()
        {
            _tryCatch.AfterScenarioException(() => { ClearDownQnAData_ReappliedApplication(GetUkprn()); ClearDownApplyData_ReappliedApplication(GetUkprn()); });
        }
    }
}
