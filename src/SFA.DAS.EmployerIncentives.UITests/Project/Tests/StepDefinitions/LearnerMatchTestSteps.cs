using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using NUnit.Framework;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers.Requests;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LearnerMatchTestSteps
    {
        private EIConfig _config;
        private Fixture _fixture;

        public LearnerMatchTestSteps(ScenarioContext context)
        {
            _fixture = new Fixture();
            _config = context.GetEIConfig<EIConfig>();
        }

        [Given(@"there are some apprenticeship incentives")]
        public async Task GivenThereAreSomeApprenticeshipIncentives()
        {
            var accountApiHelper = new EIAccountApiHelper(_config);

            // Proper tests may not want to use autofixture, they may use known data instead.
            var accountId = _fixture.Create<long>();
            var legalEntity = _fixture.Create<AccountLegalEntityCreateRequest>();
            await accountApiHelper.UpsertLegalEntity(accountId, legalEntity);

            var application = new CreateIncentiveApplicationRequest();
            application.AccountId = accountId;
            application.AccountLegalEntityId = legalEntity.AccountLegalEntityId;
            application.IncentiveApplicationId = Guid.NewGuid();
            application.Apprenticeships = _fixture.CreateMany<IncentiveApplicationApprenticeshipDto>();

            var applicationApiHelper = new EIApplicationsApiHelper(_config);
            await applicationApiHelper.CreateApplication(application);

            var submitRequest = new SubmitIncentiveApplicationRequest
            {
                AccountId = accountId,
                DateSubmitted = DateTime.Now,
                IncentiveApplicationId = application.IncentiveApplicationId,
                SubmittedByEmail = _fixture.Create<string>(),
                SubmittedByName = _fixture.Create<string>()
            };
            await applicationApiHelper.SubmitApplication(submitRequest);

            // May need to wait a short while to allow earnings to be created
            Thread.Sleep(1);

            // Possibly need to mock the learner match API
        }

        [When(@"the learner match service is completed")]
        public async Task WhenTheLearnerMatchServiceIsCompleted()
        {
            var learnerMatchService = new EILearnerMatchHelper(_config);
            await learnerMatchService.StartLearnerMatchOrchestrator();
            await learnerMatchService.WaitUntilComplete(new TimeSpan(0, 5, 0));
        }

        [Then(@"we have some learner data")]
        public void ThenWeHaveSomeLearnerData()
        {
            var sqlHelper = new EISqlHelper(_config);
            var learnersExisting = sqlHelper.VerifyLearningRecordsExist();
            Assert.IsTrue(learnersExisting);
        }
    }
}
