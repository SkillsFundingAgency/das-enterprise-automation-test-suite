using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    public class BaseSteps
    {
        protected readonly AppreticeCommitmentsStepsHelper appreticeCommitmentsStepsHelper;
        protected readonly ApprenticeCommitmentsConfig config;
        protected readonly TabHelper tabHelper;

        public BaseSteps(ScenarioContext context)
        {
            appreticeCommitmentsStepsHelper = new AppreticeCommitmentsStepsHelper(context);
            config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
            tabHelper = context.Get<TabHelper>();
        }
    }
}
