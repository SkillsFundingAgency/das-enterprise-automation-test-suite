using AutoFixture;
using NUnit.Framework;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Messages;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "LearnerMatchTest")]
    public class LearnerMatchTestSteps
    {
        private EIConfig _config;
        private Fixture _fixture;
        private IncentiveApplication _incentiveApplication;
        private IncentiveApplicationApprenticeship _apprenticeship;
        private Guid _apprenticeshipIncentiveId;
        private EIServiceBusHelper _serviceBusHelper;

        public LearnerMatchTestSteps(ScenarioContext context)
        {
            _fixture = new Fixture();
            _config = context.GetEIConfig<EIConfig>();
            var config = context.Get<FrameworkConfig>();
            _serviceBusHelper = new EIServiceBusHelper(config.NServiceBusConfig);
        }

        [Given(@"there are some apprenticeship incentives")]
        public async Task GivenThereAreSomeApprenticeshipIncentives()
        {
            var sqlHelper = new EISqlHelper(_config);
            await sqlHelper.SetActiveCollectionPeriod(6, 2021);

            // Proper tests may not want to use autofixture, they may use known data instead.
            _incentiveApplication = _fixture.Create<IncentiveApplication>();
            _apprenticeship = _fixture.Build<IncentiveApplicationApprenticeship>()
                .With(a => a.IncentiveApplicationId, _incentiveApplication.Id)
                .With(x => x.PlannedStartDate, new DateTime(2021, 1, 1))
                .With(x => x.WithdrawnByCompliance, false)
                .With(x => x.WithdrawnByEmployer, false)
                .With(x => x.Phase, Phase.Phase1)
                .Create();
            _incentiveApplication.Apprenticeships.Clear();
            _incentiveApplication.Apprenticeships.Add(_apprenticeship);

            await sqlHelper.CreateIncentiveApplication(_incentiveApplication);

            var command = new CreateIncentiveCommand(
                _incentiveApplication.AccountId,
                _incentiveApplication.AccountLegalEntityId,
                _apprenticeship.Id,
                _apprenticeship.ApprenticeshipId,
                _apprenticeship.FirstName,
                _apprenticeship.LastName,
                _apprenticeship.DateOfBirth,
                _apprenticeship.ULN,
                _apprenticeship.PlannedStartDate,
                _apprenticeship.ApprenticeshipEmployerTypeOnApproval,
                _apprenticeship.UKPRN,
                _incentiveApplication.DateSubmitted.Value,
                _incentiveApplication.SubmittedByEmail,
                _apprenticeship.CourseName,
                _apprenticeship.EmploymentStartDate.Value,
                _apprenticeship.Phase
            );

            await _serviceBusHelper.Publish(command);

            _apprenticeshipIncentiveId = await sqlHelper.GetApprenticeshipIncentiveIdWhenExists(_apprenticeship.Id, new TimeSpan(0, 0, 10, 0));
            await sqlHelper.WaitUntilEarningsExist(_apprenticeshipIncentiveId, new TimeSpan(0, 0, 10, 0));

            var learnerMatchApi = new LearnerMatchApiHelper(_config);
            var learnerMatchResponse = _fixture.Create<LearnerSubmissionDto>();
            await learnerMatchApi.SetupResponse(_apprenticeship.ULN, _apprenticeship.UKPRN.Value, learnerMatchResponse);
        }

        [When(@"the learner match service is completed")]
        public async Task WhenTheLearnerMatchServiceIsCompleted()
        {
            var learnerMatchService = new EILearnerMatchHelper(_config);
            await learnerMatchService.StartLearnerMatchOrchestrator();
            await learnerMatchService.WaitUntilComplete(new TimeSpan(0, 1, 0));
        }

        [Then(@"we have some learner data")]
        public async Task ThenWeHaveSomeLearnerData()
        {
            var sqlHelper = new EISqlHelper(_config);
            var learnersExisting = await sqlHelper.VerifyLearningRecordsExist(_apprenticeshipIncentiveId);
            Assert.IsTrue(learnersExisting);
        }

        [AfterScenario(Order = 1)]
        public async Task ClearUpData()
        {
            var sqlHelper = new EISqlHelper(_config);
            await sqlHelper.CleanUpApprenticeshipIncentive(_apprenticeshipIncentiveId);
            await sqlHelper.CleanUpIncentiveApplication(_incentiveApplication);
        }
    }
}
