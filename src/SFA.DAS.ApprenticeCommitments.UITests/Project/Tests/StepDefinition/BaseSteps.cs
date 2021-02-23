using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    public abstract class BaseSteps
    {
        protected readonly AppreticeCommitmentsStepsHelper appreticeCommitmentsStepsHelper;

        public BaseSteps(ScenarioContext context)
        {
            appreticeCommitmentsStepsHelper = new AppreticeCommitmentsStepsHelper(context);
        }
    }
}
