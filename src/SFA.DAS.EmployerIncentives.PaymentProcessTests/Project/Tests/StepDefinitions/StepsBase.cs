using AutoFixture;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using System;
using System.Threading.Tasks;
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

        [BeforeScenario()]
        public async Task InitialCleanup()
        {
            await _helper.IncentiveHelper.Delete(testData.AccountId, testData.ApprenticeshipId);
            await _helper.CollectionCalendarHelper.Reset();
        }

        [AfterScenario()]
        public async Task CleanUpIncentives()
        {
            if (testData.ApprenticeshipIncentiveId != Guid.Empty) await _helper.IncentiveHelper.Delete(testData.IncentiveApplication);
            if (testData.IncentiveApplication != null) await _helper.IncentiveApplicationHelper.Delete(testData.IncentiveApplication);
            await _helper.LearnerMatchApiHelper.DeleteMapping(testData.ULN, testData.UKPRN);
            await _helper.CollectionCalendarHelper.Reset();
        }
    }
}
