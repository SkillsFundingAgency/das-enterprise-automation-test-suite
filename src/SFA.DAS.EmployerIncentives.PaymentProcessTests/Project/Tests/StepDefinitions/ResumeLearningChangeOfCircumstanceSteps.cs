using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ResumeLearningChangeOfCircumstanceSteps : StepsBase
    {
        private long _uln;
        private const long Ukprn = 10005312;
        private Payment _payment;
        private PendingPayment _initialEarning;
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private DateTime _lastPriceEpisodeEndDate;
        
        protected ResumeLearningChangeOfCircumstanceSteps(ScenarioContext context) : base(context)
        {
            accountId = 14326;
            apprenticeshipId = 133218;
        }

        [Given(@"an existing apprenticeship incentive \(ULN (.*)\) with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentiveWithLearningStartingIn_Oct(long uln, DateTime startDate, DateTime endDate)
        {
            _uln = uln;
            _initialStartDate = startDate;
            _initialEndDate = endDate;

            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(accountId)
                .WithApprenticeship(apprenticeshipId, _uln, Ukprn, startDate, startDate.AddYears(-20))
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
                .WithPeriod(apprenticeshipId, period)
                .Create();

            var submissionDto = new LearnerSubmissionDtoBuilder()
                .WithUkprn(Ukprn)
                .WithUln(_uln)
                .WithAcademicYear(year)
                .WithIlrSubmissionDate("2021-02-11")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(_uln, Ukprn, submissionDto);
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
                .WithPeriod(apprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(Ukprn)
                .WithUln(_uln)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate(_initialStartDate.AddDays(1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(_uln, Ukprn, learnerSubmissionData);
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

        [When(@"Learner data is updated with Price Episode Start Date which is on or after Previous PE start date AND on or before the Previous PE end date")]
        public async Task WhenLearnerDataIsUpdatedWithPriceEpisodeStartDateWhichIsOnOrAfterPreviousPEStartDateANDOnOrBeforeThePreviousPEEndDate()
        {
            var priceEpisode1 = new PriceEpisodeDtoBuilder()
                .WithStartDate(_initialStartDate)
                .WithEndDate("2021-01-29T00:00:00")
                .WithPeriod(apprenticeshipId, 4)
                .WithPeriod(apprenticeshipId, 5)
                .Create();
            
            var priceEpisode2 = new PriceEpisodeDtoBuilder()
                .WithStartDate("2021-03-22T00:00:00")
                .WithEndDate("2021-07-31T00:00:00")
                .WithPeriod(apprenticeshipId, 8)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(Ukprn)
                .WithUln(_uln)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate("2021-02-11T14:06:18.673+00:00")
                .WithIlrSubmissionWindowPeriod(8)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode1)
                .WithPriceEpisode(priceEpisode2)
                .Create();

            await SetupLearnerMatchApiResponse(_uln, Ukprn, learnerSubmissionData);
        }

        [When(@"Learner data is updated with Price Episode End Date which is on the due date of the paid earning in Period R(.*) (.*)")]
        public async Task WhenLearnerDataIsUpdatedWithPEEndDateWhichIsOnTheDueDateOfThePaidEarningInPeriodR(byte period, short year)
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate("2020-11-01T00:00:00")
                .WithEndDate(_initialEarning.DueDate) // "2021-01-29T00:00:00"
                .WithPeriod(apprenticeshipId, 4)
                .WithPeriod(apprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(Ukprn)
                .WithUln(_uln)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate("2021-02-11T14:04:18.673+00:00")
                .WithIlrSubmissionWindowPeriod(8)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(_uln, Ukprn, learnerSubmissionData);
        }

        [When(@"the paid earnings of £(.*) is still available in the currently active Period")]
        public void WhenThePaidEarningsOfIsStillAvailableInTheCurrentlyActivePeriodR(int amount)
        {
            var earning = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId);
            earning.Should().BeEquivalentTo(_initialEarning, opts => opts.Excluding(
                x =>x.ClawedBack).Excluding(x => x.PaymentMadeDate));
            earning.Amount.Should().Be(amount);
        }

        [When(@"ILR Learner Resumed COC is occurred in Period R(.*) (.*)")]
        public void WhenILRLearnerResumedCOCIsOccurredInPeriodR(byte period, short year)
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
            GetAllFromDatabase<ArchivedPendingPayment>()
                .Where(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId)
                .Should().HaveCount(1);
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
                & p.EarningType == EarningType.SecondPayment);

            pendingPayment.PeriodNumber.Should().Be(period);
            pendingPayment.PaymentYear.Should().Be(year);
            pendingPayment.Amount.Should().Be(amount);
            pendingPayment.PaymentMadeDate.Should().BeNull();
            pendingPayment.ClawedBack.Should().BeFalse();
        }
    }
}
