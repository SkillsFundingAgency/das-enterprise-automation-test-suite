using System;
using System.Threading.Tasks;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "PaymentValidation")]
    public class PaymentValidationSteps : StepsBase
    {
        private PendingPayment _pendingPayment;

        protected PaymentValidationSteps(ScenarioContext context) : base(context)
        {
            accountId = 14326;
            apprenticeshipId = 133218;
        }

        [Given(@"an existing apprenticeship incentive")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            var startDate = new DateTime(2021, 03, 03);

            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(accountId)
                .WithApprenticeship(apprenticeshipId, ULN, UKPRN, startDate, startDate.AddYears(-20))
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(apprenticeshipId, 11)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionData);
        }

        [When(@"the Payment Run occurs")]
        public async Task WhenThePaymentRunOccurs()
        {
            byte period = 10;
            short year = 2021;
            await SetActiveCollectionPeriod(period, year);
            await RunLearnerMatchOrchestrator();
            await RunPaymentsOrchestrator();
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
