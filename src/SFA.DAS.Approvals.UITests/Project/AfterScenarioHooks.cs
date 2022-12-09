using MongoDB.Driver;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport.Helper;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class AfterScenarioHooks
    {
        private readonly ObjectContext _objectContext;
        private readonly TryCatchExceptionHelper _tryCatch;
        private readonly ApprenticeDataHelper _datahelper;
        private readonly ManageFundingEmployerStepsHelper _manageFundingEmployerStepsHelper;
        private readonly RofjaaDbSqlHelper _rofjaaDbSqlHelper;
        protected readonly string[] tags;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
            context.TryGetValue(out _datahelper);
            context.TryGetValue(out _manageFundingEmployerStepsHelper);
            _rofjaaDbSqlHelper = new RofjaaDbSqlHelper(context.Get<DbConfig>());
            tags = context.ScenarioInfo.Tags;
        }

        [AfterScenario(Order = 10)]
        public void AddUln() => _tryCatch.AfterScenarioException(() => _datahelper?.Ulns.ForEach((x) => _objectContext.SetUln(x)));

        [AfterScenario(Order = 11)]
        public void RemoveDynamicPauseGlobalRule() => _manageFundingEmployerStepsHelper.RemoveDynamicPauseGlobalRule();

        [AfterScenario(Order = 12)]
        [Scope(Tag = "Flexi-job")]
        public void ResetFJAARegister()
        {
            _rofjaaDbSqlHelper.AddFJAAEmployerToRegister();
        }
    }
}
