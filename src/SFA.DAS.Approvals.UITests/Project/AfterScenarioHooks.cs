using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class AfterScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectcontext;
        private readonly TryCatchExceptionHelper _tryCatch;
        private readonly ApprenticeDataHelper _datahelper;
        private readonly ManageFundingEmployerStepsHelper _manageFundingEmployerStepsHelper;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _objectcontext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
            _context.TryGetValue(out _datahelper);
            _context.TryGetValue(out _manageFundingEmployerStepsHelper);
        }

        [AfterScenario(Order = 10)]
        public void AddUln() => _tryCatch.AfterScenarioException(() => _datahelper?.Ulns.ForEach((x) => _objectcontext.SetUln(x)));

        [AfterScenario(Order = 11)]
        public void RemoveDynamicPauseGlobalRule() => _manageFundingEmployerStepsHelper.RemoveDynamicPauseGlobalRule();
    }
}
