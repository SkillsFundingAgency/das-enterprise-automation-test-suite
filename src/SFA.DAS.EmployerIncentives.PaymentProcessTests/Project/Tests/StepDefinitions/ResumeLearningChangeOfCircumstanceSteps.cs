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
    [Scope(Feature = "ResumeLearningChangeOfCircumstance")]
    public class ResumeLearningChangeOfCircumstanceSteps : StepsBase
    {
        private Payment _payment;
        private PendingPayment _initialEarning;
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private DateTime _breakStart;
        private PriceEpisodeDto _priceEpisodeWithBreakInLearning;

        protected ResumeLearningChangeOfCircumstanceSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an existing apprenticeship incentive with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentiveWithLearningStartingIn_Oct(DateTime startDate, DateTime endDate)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(6, 2021);
           
            _initialStartDate = startDate;
            _initialEndDate = endDate;

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN,
                    startDate, startDate.AddYears(-20), Context.ScenarioInfo.Title, Phase.Phase1)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [Given(@"a payment of £(.*) sent in Period R(.*) (.*)")]
        public async Task GivenAPaymentOfSentInPeriodR(int amount, byte period, short year)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(TestData.ApprenticeshipId, 3)
                .WithPeriod(TestData.ApprenticeshipId, 4)
                .WithPeriod(TestData.ApprenticeshipId, 5)
                .WithPeriod(TestData.ApprenticeshipId, 6)
                .Create();

            var submissionDto = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(year)
                .WithIlrSubmissionDate("2021-02-11")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, submissionDto);
            await Helper.LearnerMatchOrchestratorHelper.Run();

            await Helper.BusinessCentralApiHelper.AcceptAllPayments();
            await Helper.PaymentsOrchestratorHelper.Run();
            await Helper.PaymentsOrchestratorHelper.Approve();

            _initialEarning = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarning.PaymentMadeDate.Should().NotBeNull();
            _initialEarning.PaymentMadeDate.Should().NotBeNull();
            _initialEarning.Amount.Should().Be(amount);

            _payment = Helper.EISqlHelper.GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarning.Id);
            _payment.Should().NotBeNull();
            _payment.PaidDate.Should().NotBeNull();
            _payment.Amount.Should().Be(amount);
        }

        [When(@"Learner data is updated with Price Episode End Date which is before the due date of the paid earning in Period R(.*) (.*)")]
        public async Task WhenLearnerDataIsUpdatedWithPeEndDateWhichIsBeforeTheDueDateOfThePaidEarning(byte period, short year)
        {
            _breakStart = _initialEarning.DueDate.AddDays(-4); // 6-Jan-2021
            _priceEpisodeWithBreakInLearning = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_breakStart)
                .WithPeriod(TestData.ApprenticeshipId, 3)
                .WithPeriod(TestData.ApprenticeshipId, 4)
                .WithPeriod(TestData.ApprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(_initialEarning.PaymentYear.Value)
                .WithIlrSubmissionDate(_initialStartDate.AddDays(1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(_priceEpisodeWithBreakInLearning)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the Learner Match is run in Period R(.*) (.*)")]
        public async Task WhenTheLearnerMatchIsRunInPeriodR(byte period, short year)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);
            await Helper.LearnerMatchOrchestratorHelper.Run();
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
                .WithEndDate(_breakStart)
                .WithPeriod(TestData.ApprenticeshipId, 3)
                .WithPeriod(TestData.ApprenticeshipId, 4)
                .WithPeriod(TestData.ApprenticeshipId, 5)
                .Create();

            var priceEpisode2 = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(DateTime.Parse("2021-03-22T00:00:00"))
                .WithEndDate(_initialEndDate)
                .WithPeriod(TestData.ApprenticeshipId, 3)
                .WithPeriod(TestData.ApprenticeshipId, 4)
                .WithPeriod(TestData.ApprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-02-28")
                .WithIlrSubmissionWindowPeriod(8)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode1)
                .WithPriceEpisode(priceEpisode2)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"Learner data is updated with Price Episode End Date which is on the due date of the paid earning in Period R(.*) (.*)")]
        public async Task WhenLearnerDataIsUpdatedWithPEEndDateWhichIsOnTheDueDateOfThePaidEarningInPeriodR(byte period, short year)
        {
            _breakStart = _initialEarning.DueDate;

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_breakStart) // "2021-01-29T00:00:00"
                .WithPeriod(TestData.ApprenticeshipId, 4)
                .WithPeriod(TestData.ApprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithAcademicYear(2021)
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-02-11")
                .WithIlrSubmissionWindowPeriod(8)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"Learner data is updated with Price Episode End Date which is one day after the due date of the paid earning in Period R(.*)")]
        public async Task WhenLearnerDataIsUpdatedWithPriceEpisodeEndDateWhichIsOneDayAfterTheDueDateOfThePaidEarningInPeriodR(string p0)
        {
            _breakStart = _initialEarning.DueDate.AddDays(1);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_breakStart) // "2021-01-29T00:00:00"
                .WithPeriod(TestData.ApprenticeshipId, 4)
                .WithPeriod(TestData.ApprenticeshipId, 5)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-02-11")
                .WithIlrSubmissionWindowPeriod(8)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }


        [When(@"the paid earnings of £(.*) is still available in the currently active Period")]
        public void WhenThePaidEarningsOfIsStillAvailableInTheCurrentlyActivePeriodR(int amount)
        {
            var earning = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);
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
            await Helper.PaymentsOrchestratorHelper.Run();
        }

        [When(@"the Unpaid Earnings are Archived")]
        public void ThenTheUnpaidEarningsAreArchived()
        {
            Helper.EISqlHelper.GetAllFromDatabase<ArchivedPendingPayment>()
                .Where(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId)
                .Should().HaveCount(1);
        }

        [When(@"the paid earnings of £(.*) is marked as required a clawback in the currently active collection period")]
        public void ThenThePaidEarningsOfIsMarkedAsRequiredAClawbackInTheCurrentlyActivePeriodR(int amount)
        {
            var pendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.Id == _initialEarning.Id);
            pendingPayment.PaymentMadeDate.Should().NotBeNull();
            pendingPayment.ClawedBack.Should().BeTrue();

            var clawback = Helper.EISqlHelper.GetFromDatabase<ClawbackPayment>(p => p.PendingPaymentId == _initialEarning.Id);
            clawback.Should().BeEquivalentTo(_payment, opt => opt.ExcludingMissingMembers()
                .Excluding(x => x.Id)
                .Excluding(x => x.Amount)
            );

            clawback.Amount.Should().Be(-amount);
            clawback.CollectionPeriodYear.Should().Be(Helper.CollectionCalendarHelper.ActivePeriod.Year);
            clawback.CollectionPeriod.Should().Be(Helper.CollectionCalendarHelper.ActivePeriod.Number);
        }

        [Then(@"a new first pending payment of £(.*) is created for Period R(.*) (.*)")]
        public void ThenANewFirstPendingPaymentOfIsCreatedForPeriodR(int amount, byte period, short year)
        {
            var pendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId
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
            var pendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId
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
            var pendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId
                & p.EarningType == EarningType.SecondPayment);

            pendingPayment.PeriodNumber.Should().Be(period);
            pendingPayment.PaymentYear.Should().Be(year);
            pendingPayment.Amount.Should().Be(amount);
            pendingPayment.PaymentMadeDate.Should().BeNull();
            pendingPayment.ClawedBack.Should().BeFalse();
        }
    }
}
