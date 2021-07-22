using System;
using System.Threading.Tasks;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "PaymentsProcess")]
    public class PaymentsProcessSteps : StepsBase
    {
        private readonly CollectionPeriodHelper _collectionPeriodHelper;
        private readonly PaymentsOrchestratorHelper _paymentsOrchestratorHelper;
        private readonly LearnerMatchOrchestratorHelper _learnerMatchOrchestratorHelper;

        public PaymentsProcessSteps(ScenarioContext context) : base(context) 
        {
            testData.AccountId = 14326;
            testData.ApprenticeshipId = 133217891;

            _collectionPeriodHelper = context.Get<CollectionPeriodHelper>();
            _paymentsOrchestratorHelper = context.Get<PaymentsOrchestratorHelper>();
            _learnerMatchOrchestratorHelper = context.Get<LearnerMatchOrchestratorHelper>();
        }

        [Given(@"there is a valid learner")]
        public async Task GivenThereIsAValidLearner()
        {
            await _collectionPeriodHelper.SetActiveCollectionPeriod(2, 2122);

            var startDate = DateTime.Parse("2021-6-12");
            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, startDate, startDate.AddYears(-24), Phase.Phase2)
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
            await _learnerMatchOrchestratorHelper.Run();
        }

        [When(@"the payment process is completed")]
        public async Task WhenThePaymentProcessIsCompleted()
        {
            await SetupBusinessCentralApiToAcceptAllPayments();
            await _paymentsOrchestratorHelper.Run();
            await _paymentsOrchestratorHelper.Approve();
        }

        [Then(@"payments exist")]
        public async Task ThenPaymentsExist()
        {
            await VerifyPaymentRecordsExist();
        }
    }
}
