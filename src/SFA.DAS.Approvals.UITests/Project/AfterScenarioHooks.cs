using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class AfterScenarioHooks
    {
        private readonly ScenarioContext context;
        private readonly ManageFundingEmployerStepsHelper _manageFundingEmployerStepsHelper;
        protected readonly string[] tags;

        public AfterScenarioHooks(ScenarioContext context)
        {
            this.context = context;
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
