using AutoFixture;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    public class StepsBase
    {
        protected Fixture fixture;
        protected EIConfig config;
        protected EISqlHelper sqlHelper;
        protected LearnerMatchApiHelper learnerMatchApi;
        protected EILearnerMatchHelper learnerMatchService;
        protected BusinessCentralApiHelper businessCentralApiHelper;

        protected StepsBase(ScenarioContext context)
        {
            fixture = new Fixture();
            config = context.GetEIConfig<EIConfig>();
            sqlHelper = new EISqlHelper(config);

            learnerMatchApi = new LearnerMatchApiHelper(config);
            learnerMatchService = new EILearnerMatchHelper(config);

            businessCentralApiHelper = new BusinessCentralApiHelper(config);
        }

        protected async Task RunLearnerMatchOrchestrator()
        {
            await learnerMatchService.StartLearnerMatchOrchestrator();
            await learnerMatchService.WaitUntilComplete();
        }

        protected async Task SetActiveCollectionPeriod(byte periodNumber, short academicYear)
        {
            await sqlHelper.SetActiveCollectionPeriod(periodNumber, academicYear);
        }
    }
}
