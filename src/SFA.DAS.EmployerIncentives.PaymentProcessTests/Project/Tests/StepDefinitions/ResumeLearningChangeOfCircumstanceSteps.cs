using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ResumeLearningChangeOfCircumstanceSteps : StepsBase
    {
        private const long Uln = 7229721931;
        private const long Ukprn = 10005312;
        private const long AccountId = 14326;
        private const long ApprenticeshipId = 133218;

        private Payment _payment;
        private PendingPayment _initialEarning;
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private DateTime _lastPriceEpisodeEndDate;

        [Given(@"an existing apprenticeship incentive with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentiveWithLearningStartingIn_Oct(DateTime startDate, DateTime endDate)
        {
            _initialStartDate = startDate;
            _initialEndDate = endDate;

            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(AccountId)
                .WithApprenticeship(ApprenticeshipId, Uln, Ukprn, startDate, startDate.AddYears(-20))
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);
        }

        [Given(@"a payment of £(.*) sent in Period R(.*) (.*)")]
        public async Task GivenAPaymentOfSentInPeriodR(int amount, byte period, short year)
        {
            await SetActiveCollectionPeriod(period, year);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(ApprenticeshipId, period)
                .Create();

            var submissionDto = new LearnerSubmissionDtoBuilder()
                .WithUkprn(Ukprn)
                .WithUln(Uln)
                .WithAcademicYear(year)
                .WithIlrSubmissionDate(_initialStartDate)
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(Uln, Ukprn, submissionDto);
            await RunLearnerMatchOrchestrator();

            await SetupBusinessCentralApiToAcceptAllPayments();
            await RunPaymentsOrchestrator();
            await RunApprovePaymentsOrchestrator();

            _initialEarning = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarning.PaymentMadeDate.Should().NotBeNull();
            _initialEarning.PaymentMadeDate.Should().NotBeNull();
            _initialEarning.Amount.Should().Be(amount);

            _payment = GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarning.Id);
            _payment.Should().NotBeNull();
            _payment.PaidDate.Should().NotBeNull();
            _payment.Amount.Should().Be(amount);
        }

        [When(@"Learner data is updated with PE End Date which is before the due date of the paid earning in Period R(.*) (.*)")]
        public async Task WhenLearnerDataIsUpdatedWithPEEndDateWhichIsBeforeTheDueDateOfThePaidEarning(byte period, short year)
        {
            _lastPriceEpisodeEndDate = _initialEarning.DueDate.AddDays(-6);
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(_initialStartDate)
                .WithEndDate(_lastPriceEpisodeEndDate)
                .WithPeriod(ApprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(Ukprn)
                .WithUln(Uln)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate(_initialStartDate.AddDays(1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(Uln, Ukprn, learnerSubmissionData);
        }

        [When(@"the Learner Match is run in Period R(.*) (.*)")]
        public async Task WhenTheLearnerMatchIsRunInPeriodR(byte period, short year)
        {
            await SetActiveCollectionPeriod(period, year);
            await RunLearnerMatchOrchestrator();
        }

        [When(@"ILR Learner Stopped COC is occurred in Period R(.*) (.*)")]
        public async Task WhenILRLearnerStoppedCOCIsOccurredInPeriodR(byte period, short year)
        {
            await WhenTheLearnerMatchIsRunInPeriodR(period, year);
        }

        [When(@"Learner data is updated with PriceEpisode Start Date which is on or after Previous PE start date AND on or before the Previous PE end date")]
        public async Task WhenLearnerDataIsUpdatedWithPriceEpisodeStartDateWhichIsOnOrAfterPreviousPEStartDateANDOnOrBeforeThePreviousPEEndDate()
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(_lastPriceEpisodeEndDate.AddDays(49))
                .WithEndDate(_initialEndDate)
                .WithPeriod(ApprenticeshipId, (byte)(activePaymentPeriod.Number - 1))
                .WithPeriod(ApprenticeshipId, activePaymentPeriod.Number)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(Ukprn)
                .WithUln(Uln)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate(_initialStartDate.AddDays(33))
                .WithIlrSubmissionWindowPeriod(activePaymentPeriod.Number)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(Uln, Ukprn, learnerSubmissionData);
        }

        [When(@"ILR Learner Resumed COC is occurred in Period R(.*) (.*)")]
        public async Task WhenILRLearnerResumedCOCIsOccurredInPeriodR(byte period, short year)
        {
        }

        [When(@"the earnings are recalculated")]
        public async Task WhenTheEarningsAreRecalculated()
        {
            await RunPaymentsOrchestrator();
        }

        [When(@"the Unpaid Earnings are Archived")]
        public void ThenTheUnpaidEarningsAreArchived()
        {
            // todo
        }

        [When(@"the paid earnings of £(.*) is marked as required a clawback in the currently active Period R(.*) (.*)")]
        public void ThenThePaidEarningsOfIsMarkedAsRequiredAClawbackInTheCurrentlyActivePeriodR(int amount, byte period, short year)
        {
            var pendingPayment = GetFromDatabase<PendingPayment>(p => p.Id == _initialEarning.Id);
            pendingPayment.PaymentMadeDate.Should().NotBeNull();
            pendingPayment.ClawedBack.Should().BeTrue();

            var clawback = GetFromDatabase<ClawbackPayment>(p => p.PendingPaymentId == _initialEarning.Id);
            clawback.Should().BeEquivalentTo(_payment, opt => opt.ExcludingMissingMembers()
                .Excluding(x => x.Id)
                .Excluding(x => x.Amount)
            );

            clawback.Amount.Should().Be(-amount);
            clawback.CollectionPeriodYear.Should().Be(year);
            clawback.CollectionPeriod.Should().Be(period);
        }

        [Then(@"a new first pending payment of £(.*) is created for Period R(.*) (.*)")]
        public void ThenANewFirstPendingPaymentOfIsCreatedForPeriodR(int amount, byte period, short year)
        {
            var pendingPayment = GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                && p.EarningType == EarningType.FirstPayment && p.ClawedBack == false);

            pendingPayment.PeriodNumber.Should().Be(period);
            pendingPayment.PaymentYear.Should().Be(year);
            pendingPayment.Amount.Should().Be(amount);
            pendingPayment.PaymentMadeDate.Should().BeNull();
            pendingPayment.ClawedBack.Should().BeFalse();
        }

        [Then(@"a new second pending payment of £(.*) is created for Period R(.*) (.*)")]
        public void ThenANewSecondPendingPaymentOfIsCreatedForPeriodR(int amount, byte period, short year)
        {
            var pendingPayment = GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                && p.PeriodNumber == period && p.PaymentYear == year && p.EarningType == EarningType.SecondPayment);
            pendingPayment.Amount.Should().Be(amount);
            pendingPayment.PaymentMadeDate.Should().BeNull();
            pendingPayment.ClawedBack.Should().BeFalse();
        }

        protected ResumeLearningChangeOfCircumstanceSteps(ScenarioContext context) : base(context)
        {
        }
    }
}
