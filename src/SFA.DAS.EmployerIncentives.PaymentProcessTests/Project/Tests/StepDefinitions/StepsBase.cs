using AutoFixture;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    public class StepsBase
    {
        protected TestData testData;
        protected Fixture fixture;
        protected Helper helper;

        protected StepsBase(ScenarioContext context)
        {
            helper = context.Get<Helper>();

            fixture = new Fixture();
            testData = context.Get<TestData>();
        }
    }
}
