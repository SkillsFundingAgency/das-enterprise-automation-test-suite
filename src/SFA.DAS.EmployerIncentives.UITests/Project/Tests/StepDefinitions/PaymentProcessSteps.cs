using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using NUnit.Framework;
using SFA.DAS.EmployerIncentives.UITests.Messages;
using SFA.DAS.EmployerIncentives.UITests.Models;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "PaymentsProcess")]
    public class PaymentsProcessSteps
    {
        private EIConfig _config;
        private Fixture _fixture;
        private IncentiveApplication _incentiveApplication;
        private IncentiveApplicationApprenticeship _apprenticeship;
        private Guid _apprenticeshipIncentiveId;
        private long _accountId;

        public PaymentsProcessSteps(ScenarioContext context)
        {
            _fixture = new Fixture();
            _config = context.GetEIConfig<EIConfig>();
        }

        [Given(@"there is a valid learner")]
        public async Task GivenThereIsAValidLearner()
        {
            var sqlHelper = new EISqlHelper(_config);
            await sqlHelper.SetActiveCollectionPeriod(6, 2021);

            _accountId = _fixture.Create<long>();
            var accountLegalEntityId = _fixture.Create<long>();
            await sqlHelper.CreateAccount(_accountId, accountLegalEntityId);

            // Proper tests may not want to use autofixture, they may use known data instead.
            _incentiveApplication = _fixture.Build<IncentiveApplication>().With(x => x.AccountId, _accountId).With(x => x.AccountLegalEntityId, accountLegalEntityId).Create();
            _apprenticeship = _fixture.Build<IncentiveApplicationApprenticeship>()
                .With(a => a.IncentiveApplicationId, _incentiveApplication.Id)
                .With(x => x.PlannedStartDate, new DateTime(2020, 8, 1))
                .With(x => x.WithdrawnByCompliance, false)
                .With(x => x.WithdrawnByEmployer, false)
                .Create();
            _incentiveApplication.Apprenticeships.Clear();
            _incentiveApplication.Apprenticeships.Add(_apprenticeship);
            
            await sqlHelper.CreateIncentiveApplication(_incentiveApplication);

            var serviceBusHelper = new EIServiceBusHelper(_config);
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
                _apprenticeship.CourseName
            );

            await serviceBusHelper.Publish(command);

            _apprenticeshipIncentiveId = await sqlHelper.GetApprenticeshipIncentiveIdWhenExists(_apprenticeship.Id, new TimeSpan(0, 0, 1, 0));
            await sqlHelper.WaitUntilEarningsExist(_apprenticeshipIncentiveId, new TimeSpan(0, 0, 1, 0));

            var learnerMatchApi = new LearnerMatchApiHelper(_config);
            var learnerMatchResponse = ValidLearnerSubmission();
            await learnerMatchApi.SetupResponse(_apprenticeship.ULN, _apprenticeship.UKPRN.Value, learnerMatchResponse);

            var learnerMatchService = new EILearnerMatchHelper(_config);
            await learnerMatchService.StartLearnerMatchOrchestrator();
            await learnerMatchService.WaitUntilComplete(new TimeSpan(0, 1, 0));
        }

        [When(@"the payment process is completed")]
        public async Task WhenThePaymentProcessIsCompleted()
        {
            var paymentService = new EIPaymentsProcessHelper(_config);
            await paymentService.StartPaymentProcessOrchestrator(2021, 6);
            await paymentService.WaitUntilWaitingForPaymentApproval(new TimeSpan(0, 1, 0));
        }

        [Then(@"payments exist")]
        public async Task ThenPaymentsExist()
        {
            var sqlHelper = new EISqlHelper(_config);
            var paymentsExist = await sqlHelper.VerifyPaymentRecordsExist(_apprenticeshipIncentiveId);
            Assert.IsTrue(paymentsExist);
        }

        [AfterScenario(Order = 1)]
        public async Task ClearUpData()
        {
            var sqlHelper = new EISqlHelper(_config);
            await sqlHelper.CleanUpAccount(_accountId);
            await sqlHelper.CleanUpApprenticeshipIncentive(_apprenticeshipIncentiveId);
            await sqlHelper.CleanUpIncentiveApplication(_incentiveApplication);
        }

        private LearnerSubmissionDto ValidLearnerSubmission()
        {
            return new LearnerSubmissionDto
            {
                StartDate = _apprenticeship.PlannedStartDate,
                AcademicYear = 2021,
                IlrSubmissionDate = DateTime.Now,
                IlrSubmissionWindowPeriod = 6,
                Ukprn = 123456,
                Uln = _apprenticeship.ULN,
                Training = new List<TrainingDto>(new[] { 
                    new TrainingDto
                    {
                        Reference = "ZPROG001",
                        PriceEpisodes = new List<PriceEpisodeDto>(new[]
                        {
                            new PriceEpisodeDto
                            {
                                StartDate = _apprenticeship.PlannedStartDate,
                                EndDate = _apprenticeship.PlannedStartDate.AddYears(1),
                                Periods = new List<PeriodDto>(new []
                                {
                                    new PeriodDto
                                    {
                                        ApprenticeshipId = _apprenticeship.ApprenticeshipId,
                                        IsPayable = true,
                                        Period = 6
                                    }
                                })
                            }
                        })
                    }
                })
            };
        }
    }
}
