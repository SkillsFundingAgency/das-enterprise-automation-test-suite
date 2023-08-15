using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class AfterScenarioHooks
    {
        private readonly ScenarioContext context;
        private readonly ObjectContext _objectContext;
        private readonly TryCatchExceptionHelper _tryCatch;
        private readonly ApprenticeDataHelper _datahelper;
        private readonly ManageFundingEmployerStepsHelper _manageFundingEmployerStepsHelper;
        protected readonly string[] tags;

        public AfterScenarioHooks(ScenarioContext context)
        {
            this.context = context;
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
            context.TryGetValue(out _datahelper);
            context.TryGetValue(out _manageFundingEmployerStepsHelper);
            tags = context.ScenarioInfo.Tags;
        }

        [AfterScenario(Order = 11)]
        public void RemoveDynamicPauseGlobalRule() => _manageFundingEmployerStepsHelper.RemoveDynamicPauseGlobalRule();

        [AfterScenario(Order = 12)]
        [Scope(Tag = "rofjaadb")]
        public void ResetFJAARegister() => context.Get<RofjaaDbSqlHelper>().AddFJAAEmployerToRegister();
    }
}
