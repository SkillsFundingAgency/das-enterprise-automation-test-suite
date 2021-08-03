using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "ResumeLearningChangeOfCircumstance")]
    public class ResumeLearningChangeOfCircumstanceSteps : StepsBase
    {
        private Payment _payment;
        private PendingPayment _initialEarning;
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private DateTime _lastPriceEpisodeEndDate;

        private readonly Helper _helper;

        protected ResumeLearningChangeOfCircumstanceSteps(ScenarioContext context) : base(context)
        {
            testData.AccountId = 14326;
            testData.ApprenticeshipId = 133218;

            _helper = context.Get<Helper>();
        }

        [Given(@"an existing apprenticeship incentive with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentiveWithLearningStartingIn_Oct(DateTime startDate, DateTime endDate)
        {
            _initialStartDate = startDate;
            _initialEndDate = endDate;
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(6, 2021);

            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, startDate, startDate.AddYears(-20))
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);
        }

        [Given(@"a payment of £(.*) sent in Period R(.*) (.*)")]
        public async Task GivenAPaymentOfSentInPeriodR(int amount, byte period, short year)
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(testData.ApprenticeshipId, period)
                .Create();

            var submissionDto = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(year)
                .WithIlrSubmissionDate("2021-02-11")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, submissionDto);
            await _helper.LearnerMatchOrchestratorHelper.Run();

            await _helper.BusinessCentralApiHelper.AcceptAllPayments();
            await _helper.PaymentsOrchestratorHelper.Run();
            await _helper.PaymentsOrchestratorHelper.Approve();

            _initialEarning = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarning.PaymentMadeDate.Should().NotBeNull();
            _initialEarning.PaymentMadeDate.Should().NotBeNull();
            _initialEarning.Amount.Should().Be(amount);

            _payment = _helper.EISqlHelper.GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarning.Id);
            _payment.Should().NotBeNull();
            _payment.PaidDate.Should().NotBeNull();
            _payment.Amount.Should().Be(amount);
        }

        [When(@"Learner data is updated with Price Episode End Date which is before the due date of the paid earning in Period R(.*) (.*)")]
        public async Task WhenLearnerDataIsUpdatedWithPeEndDateWhichIsBeforeTheDueDateOfThePaidEarning(byte period, short year)
        {
            _lastPriceEpisodeEndDate = _initialEarning.DueDate.AddDays(-6);
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_lastPriceEpisodeEndDate)
                .WithPeriod(testData.ApprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate(_initialStartDate.AddDays(1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the Learner Match is run in Period R(.*) (.*)")]
        public async Task WhenTheLearnerMatchIsRunInPeriodR(byte period, short year)
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);
            await _helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"ILR Learner Stopped COC is occurred in Period R(.*) (.*)")]
        public async Task WhenIlrLearnerStoppedCocIsOccurredInPeriodR(byte period, short year)
        {
            await WhenTheLearnerMatchIsRunInPeriodR(period, year);
        }

        [When(@"Learner data is updated with Price Episode Start Date which is on or after Previous Price Episode start date AND on or before the Previous Price Episode end date")]
        public async Task WhenLearnerDataIsUpdatedWithPriceEpisodeStartDateWhichIsOnOrAfterPreviousPEStartDateANDOnOrBeforeThePreviousPEEndDate()
        {
            var priceEpisode1 = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate("2021-01-29T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 4)
                .WithPeriod(testData.ApprenticeshipId, 5)
                .Create();
            
            var priceEpisode2 = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate("2021-03-22T00:00:00")
                .WithEndDate("2021-07-31T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 8)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate("2021-02-11T14:06:18.673+00:00")
                .WithIlrSubmissionWindowPeriod(8)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode1)
                .WithPriceEpisode(priceEpisode2)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"Learner data is updated with Price Episode End Date which is on the due date of the paid earning in Period R(.*) (.*)")]
        public async Task WhenLearnerDataIsUpdatedWithPEEndDateWhichIsOnTheDueDateOfThePaidEarningInPeriodR(byte period, short year)
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate("2020-11-01T00:00:00")
                .WithEndDate(_initialEarning.DueDate) // "2021-01-29T00:00:00"
                .WithPeriod(testData.ApprenticeshipId, 4)
                .WithPeriod(testData.ApprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithAcademicYear(2021)
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate("2021-02-11T14:04:18.673+00:00")
                .WithIlrSubmissionWindowPeriod(8)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"Learner data is updated with Price Episode End Date which is one day after the due date of the paid earning in Period R(.*)")]
        public async Task WhenLearnerDataIsUpdatedWithPriceEpisodeEndDateWhichIsOneDayAfterTheDueDateOfThePaidEarningInPeriodR(string p0)
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate("2020-11-01T00:00:00")
                .WithEndDate(_initialEarning.DueDate.AddDays(1)) // "2021-01-29T00:00:00"
                .WithPeriod(testData.ApprenticeshipId, 4)
                .WithPeriod(testData.ApprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate("2021-02-11T14:04:18.673+00:00")
                .WithIlrSubmissionWindowPeriod(8)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }


        [When(@"the paid earnings of £(.*) is still available in the currently active Period")]
        public void WhenThePaidEarningsOfIsStillAvailableInTheCurrentlyActivePeriodR(int amount)
        {
            var earning = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId);
            earning.Should().BeEquivalentTo(_initialEarning, opts => opts.Excluding(
                x =>x.ClawedBack).Excluding(x => x.PaymentMadeDate));
            earning.Amount.Should().Be(amount);
        }

        [When(@"ILR Learner Resumed COC is occurred in Period R(.*) (.*)")]
        public void WhenIlrLearnerResumedCocIsOccurredInPeriodR(byte period, short year)
        {
        }

        [When(@"the earnings are recalculated")]
        public async Task WhenTheEarningsAreRecalculated()
        {
            await _helper.PaymentsOrchestratorHelper.Run();
        }

        [When(@"the Unpaid Earnings are Archived")]
        public void ThenTheUnpaidEarningsAreArchived()
        {
            _helper.EISqlHelper.GetAllFromDatabase<ArchivedPendingPayment>()
                .Where(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId)
                .Should().HaveCount(1);
        }

        [When(@"the paid earnings of £(.*) is marked as required a clawback in the currently active collection period")]
        public void ThenThePaidEarningsOfIsMarkedAsRequiredAClawbackInTheCurrentlyActivePeriodR(int amount)
        {
            var pendingPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.Id == _initialEarning.Id);
            pendingPayment.PaymentMadeDate.Should().NotBeNull();
            pendingPayment.ClawedBack.Should().BeTrue();

            var clawback = _helper.EISqlHelper.GetFromDatabase<ClawbackPayment>(p => p.PendingPaymentId == _initialEarning.Id);
            clawback.Should().BeEquivalentTo(_payment, opt => opt.ExcludingMissingMembers()
                .Excluding(x => x.Id)
                .Excluding(x => x.Amount)
            );

            clawback.Amount.Should().Be(-amount);
            clawback.CollectionPeriodYear.Should().Be(_helper.CollectionCalendarHelper.ActivePeriod.Year);
            clawback.CollectionPeriod.Should().Be(_helper.CollectionCalendarHelper.ActivePeriod.Number);
        }

        [Then(@"a new first pending payment of £(.*) is created for Period R(.*) (.*)")]
        public void ThenANewFirstPendingPaymentOfIsCreatedForPeriodR(int amount, byte period, short year)
        {
            var pendingPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId
                && p.EarningType == EarningType.FirstPayment && p.ClawedBack == false);

            pendingPayment.Amount.Should().Be(amount);
            pendingPayment.PaymentMadeDate.Should().BeNull();
            pendingPayment.ClawedBack.Should().BeFalse();
            pendingPayment.PeriodNumber.Should().Be(period);
            pendingPayment.PaymentYear.Should().Be(year);
        }

        [Then(@"the existing first pending payment of £(.*) paid in Period R(.*) (.*) is unchanged")]
        public void ThenTheExistingFirstPendingPaymentOfPaidInPeriodRIsUnchanged(int amount, byte period, short year)
        {
            var pendingPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId
                && p.EarningType == EarningType.FirstPayment);

            pendingPayment.PeriodNumber.Should().Be(period);
            pendingPayment.PaymentYear.Should().Be(year);
            pendingPayment.Amount.Should().Be(amount);
            pendingPayment.PaymentMadeDate.Should().NotBeNull();
            pendingPayment.ClawedBack.Should().BeFalse();
        }

        [Then(@"a new second pending payment of £(.*) is created for Period R(.*) (.*)")]
        public void ThenANewSecondPendingPaymentOfIsCreatedForPeriodR(int amount, byte period, short year)
        {
            var pendingPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId
                & p.EarningType == EarningType.SecondPayment);

            pendingPayment.PeriodNumber.Should().Be(period);
            pendingPayment.PaymentYear.Should().Be(year);
            pendingPayment.Amount.Should().Be(amount);
            pendingPayment.PaymentMadeDate.Should().BeNull();
            pendingPayment.ClawedBack.Should().BeFalse();
        }
    }
}
