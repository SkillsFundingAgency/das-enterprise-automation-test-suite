using AutoFixture;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    public class StepsBase
    {
        protected TestData testData;
        protected Fixture fixture;
        private readonly Helper _helper;

        protected StepsBase(ScenarioContext context)
        {
            _helper = context.Get<Helper>();

            fixture = new Fixture();
            testData = context.Get<TestData>();
        }
    }
}
