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
        protected ScenarioContext Context;

        protected StepsBase(ScenarioContext context)
        {
            Helper = context.Get<Helper>();
            Fixture = new Fixture();
            TestData = context.Get<TestData>();
            TestData.Account = (111222, 123123);
            TestData.ApprenticeshipId = Fixture.Create<long>();
            Context = context;
        }
    }
}
