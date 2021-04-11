using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    public class BaseSteps
    {
        protected readonly AppreticeCommitmentsStepsHelper appreticeCommitmentsStepsHelper;
        protected readonly ApprenticeCommitmentsConfig config;

        public BaseSteps(ScenarioContext context)
        {
            appreticeCommitmentsStepsHelper = new AppreticeCommitmentsStepsHelper(context);
            config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
        }
    }
}
