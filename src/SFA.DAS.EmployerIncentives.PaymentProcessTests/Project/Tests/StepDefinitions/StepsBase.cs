using AutoFixture;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    public class StepsBase
    {
        protected TestData TestData;
        protected Fixture Fixture;
        protected Helper Helper;

        protected StepsBase(ScenarioContext context)
        {
            Helper = context.Get<Helper>();
            Fixture = new Fixture();
            TestData = context.Get<TestData>();
            TestData.Account = (Fixture.Create<long>(), Fixture.Create<long>());
            TestData.ApprenticeshipId = Fixture.Create<long>();
        }
    }
}
