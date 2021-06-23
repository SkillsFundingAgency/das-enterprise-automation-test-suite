using System;
using System.Threading.Tasks;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "PaymentsProcess")]
    public class PaymentsProcessSteps : StepsBase
    {
        private const long AccountId = 14326;
        private const long ApprenticeshipId = 133217891;

        public PaymentsProcessSteps(ScenarioContext context) : base(context) { }

        [Given(@"there is a valid learner")]
        public async Task GivenThereIsAValidLearner()
        {
            await SetActiveCollectionPeriod(2, 2122);

            var startDate = DateTime.Parse("2021-6-12");
            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(AccountId)
                .WithApprenticeship(ApprenticeshipId, ULN, UKPRN, startDate, startDate.AddYears(-24), Phase.Phase2)
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionData);
            await RunLearnerMatchOrchestrator();
        }

        [When(@"the payment process is completed")]
        public async Task WhenThePaymentProcessIsCompleted()
        {
            await SetupBusinessCentralApiToAcceptAllPayments();
            await RunPaymentsOrchestrator();
            await RunApprovePaymentsOrchestrator();
        }

        [Then(@"payments exist")]
        public async Task ThenPaymentsExist()
        {
            await VerifyPaymentRecordsExist(paymentsSent: true);
        }
    }
}
