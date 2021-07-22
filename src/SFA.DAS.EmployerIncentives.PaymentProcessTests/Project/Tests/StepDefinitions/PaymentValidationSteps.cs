using System;
using System.Threading.Tasks;
using FluentAssertions;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "PaymentValidation")]
    public class PaymentValidationSteps : StepsBase
    {
        private PendingPayment _pendingPayment;

        private readonly CollectionPeriodHelper _collectionPeriodHelper;
        private readonly PaymentsOrchestratorHelper _paymentsOrchestratorHelper;
        private readonly LearnerMatchOrchestratorHelper _learnerMatchOrchestratorHelper;

        protected PaymentValidationSteps(ScenarioContext context) : base(context)
        {
            testData.AccountId = 14326;
            testData.ApprenticeshipId = 133218;

            _collectionPeriodHelper = context.Get<CollectionPeriodHelper>();
            _paymentsOrchestratorHelper = context.Get<PaymentsOrchestratorHelper>();
            _learnerMatchOrchestratorHelper = context.Get<LearnerMatchOrchestratorHelper>();           
        }

        [Given(@"an existing apprenticeship incentive")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            var startDate = new DateTime(2021, 03, 03);

            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, startDate, startDate.AddYears(-20))
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 11)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the Payment Run occurs")]
        public async Task WhenThePaymentRunOccurs()
        {
            byte period = 10;
            short year = 2021;
            await _collectionPeriodHelper.SetActiveCollectionPeriod(period, year);
            await _learnerMatchOrchestratorHelper.Run();
            await _paymentsOrchestratorHelper.Run();
            await ResetCalendar();
        }

        [Then(@"the (.*) Step in PendingPaymentValidationResult table for the (.*) is set to (.*)")]
        public void ThenHasPendingPaymentValidationStepSetToValue(string stepName, EarningType earningType, bool stepValue)
        {
            _pendingPayment = GetFromDatabase<PendingPayment>(x => x.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                                                                  && x.EarningType == earningType);

            var validationStep = GetFromDatabase<PendingPaymentValidationResult>(x =>
                x.PendingPaymentId == _pendingPayment.Id
                && x.Step == stepName);
            
            validationStep.Should().NotBeNull();
            validationStep.Result.Should().Be(stepValue);
        }

        [Then(@"the payment record for the first earnings is created")]
        public void ThenThePaymentRecordForTheFirstEarningsIsCreated()
        {
            var payment = GetFromDatabase<Payment>(x => x.PendingPaymentId == _pendingPayment.Id);
            payment.Should().NotBeNull();
            payment.PaymentPeriod.Should().Be(10);
            payment.PaymentYear.Should().Be(2021);
        }
    }
}
