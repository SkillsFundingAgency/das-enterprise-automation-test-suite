using AutoFixture;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly Fixture _fixture;
        private TestData _testData;
        private Helper _helper;
        private bool _hasRunInitialCleanup;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _fixture = new Fixture();
            _hasRunInitialCleanup = false;
        }

        [BeforeScenario(Order = 42)]
        public async Task SetUpHelpers()
        {
            _testData = _fixture.Create<TestData>();
            _context.Set(_testData);

            _helper = new Helper(_context);
            _context.Set(_helper);

            await _helper.CollectionCalendarHelper.Reset();
        }

        [BeforeScenarioBlock()]
        public async Task InitialCleanup()
        {
            if (!_hasRunInitialCleanup)
            {
                await _helper.IncentiveHelper.Delete(_testData.Account.AccountId, _testData.ApprenticeshipId);
            }
            _hasRunInitialCleanup = true;
        }

        [AfterScenario()]
        public async Task CleanUpIncentives()
        {
            if (_testData.ApprenticeshipIncentiveId != Guid.Empty) await _helper.IncentiveHelper.Delete(_testData.IncentiveApplication);
            if (_testData.IncentiveApplication != null) await _helper.IncentiveApplicationHelper.Delete(_testData.IncentiveApplication);
            if (_testData.Account != default) await _helper.IncentiveApplicationHelper.DeleteAccount(_testData.Account);
            await _helper.LearnerMatchApiHelper.DeleteMapping(_testData.ULN, _testData.UKPRN);
            await _helper.CollectionCalendarHelper.Reset();
        }
    }
}
