using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "StartDateChangeOfCircumstance")]
    public class StartDateChangeOfCircumstanceSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private Payment _payment;
        private PendingPayment _initialEarning;
        private List<PendingPayment> _newEarnings;

        public StartDateChangeOfCircumstanceSteps(ScenarioContext context) : base(context)
        {
            accountId = 14326;
            apprenticeshipId = 133217;
        }

        [Given(@"an existing apprenticeship incentive with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentiveWithLearningStartingIn_Oct(DateTime startDate,
            DateTime endDate)
        {
            _initialStartDate = startDate;
            _initialEndDate = endDate;
            await SetActiveCollectionPeriod(6, 2021);

            var dateOfBirth = _initialStartDate.AddYears(-24).AddMonths(-11); // under 25 at the start of learning 

            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(accountId)
                .WithApprenticeship(apprenticeshipId, ULN, UKPRN, _initialStartDate, dateOfBirth, Phase.Phase1)
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);
        }

        [Given(@"an existing phase 2 apprenticeship incentive for a learner under 25 years old")]
        public async Task GivenAPhase2IncentiveForLearnerUnder25()
        {
            _initialStartDate = new DateTime(2021, 04, 01);
            _initialEndDate = new DateTime(2023, 04, 01);
            await SetActiveCollectionPeriod(6, 2021);

            var dateOfBirth = _initialStartDate.AddYears(-24).AddMonths(-11); // under 25 at the start of learning 

            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(accountId)
                .WithApprenticeship(apprenticeshipId, ULN, UKPRN, _initialStartDate, dateOfBirth, Phase.Phase2)
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);
        }

        [Given(@"a payment of £(.*) sent in Period R(.*) (.*)")]
        public async Task GivenAPaymentOf1000SentInPeriodR072021(int amount, byte period, short year)
        {
            await SetActiveCollectionPeriod(period, year);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(apprenticeshipId, 7)
                .Create();

            var learnerSubmissionDataR7 = new LearnerSubmissionDtoBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionDataR7);
            await RunLearnerMatchOrchestrator();

            await SetupBusinessCentralApiToAcceptAllPayments();
            await RunPaymentsOrchestrator();
            await RunApprovePaymentsOrchestrator();

            _initialEarning = GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarning.PaymentMadeDate.Should().NotBeNull();

            _payment = GetFromDatabase<Payment>(p =>
                p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarning.Id);
            _payment.Should().NotBeNull();
            _payment.PaidDate.Should().NotBeNull();
            _payment.Amount.Should().Be(amount);
        }

        [Given(@"a start date change of circumstance occurs in Period R(.*) (.*)")]
        public async Task GivenAStartDateChangeOfCircumstanceOccursInPeriodR09(byte period, short year)
        {
            await SetActiveCollectionPeriod(period, year);
        }

        [Given(
            @"learner data is updated with a new learning start date (.*) making the learner over twenty five at the start of learning")]
        public async Task
            GivenLearnerDataIsUpdatedWithANewValidStartDateMakingTheLearnerOverTwentyFiveAtTheStartOfLearning(
                DateTime newStartDate)
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(newStartDate)
                .WithEndDate("2023-10-15T00:00:00")
                .WithPeriod(apprenticeshipId, 8)
                .Create();

            var learnerSubmissionDataR8 = new LearnerSubmissionDtoBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(DateTime.Parse("2021-01-10T09:11:46.82"))
                .WithIlrSubmissionWindowPeriod(4)
                .WithStartDate(newStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionDataR8);
            await RunLearnerMatchOrchestrator();
        }

        [When(@"the incentive learner data is refreshed")]
        public async Task WhenTheIncentiveLearnerDataIsRefreshed()
        {
            await RunLearnerMatchOrchestrator();
        }

        [When(@"the start date is changed making the learner 25 on the start date")]
        public async Task WhenTheStartDateIsChangedMakingTheLearner25OnTheStartDate()
        {
            var newStartDate = new DateTime(2021, 05, 31);
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(newStartDate)
                .WithEndDate("2023-10-15T00:00:00")
                .WithPeriod(apprenticeshipId, 8)
                .Create();

            var learnerSubmissionDataR8 = new LearnerSubmissionDtoBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(DateTime.Parse("2021-01-10T09:11:46.82"))
                .WithIlrSubmissionWindowPeriod(4)
                .WithStartDate(newStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionDataR8);

            await RunLearnerMatchOrchestrator();
        }

        [When(@"the earnings are recalculated")]
        public void WhenTheEarningsAreRecalculated()
        {
            _newEarnings = GetAllFromDatabase<PendingPayment>();
        }

        [Then(@"the paid earning of £(.*) is marked as requiring a clawback in the currently active Period R(.*) (.*)")]
        public void ThenThePaidEarningOfIsMarkedAsRequiringAClawbackInTheCurrentlyActivePeriodR(int amount, byte period,
            short year)
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
        public void ThenANewFirstPendingPaymentOfIsCreated(int amount, byte period, short year)
        {
            AssertPendingPayment(amount, period, year, EarningType.FirstPayment);
        }

        [Then(@"a new second pending payment of £(.*) is created for Period R(.*) (.*)")]
        public void ThenANewSecondPendingPaymentOfIsCreated(int amount, byte period, short year)
        {
            AssertPendingPayment(amount, period, year, EarningType.SecondPayment);
        }

        [Then(@"the first earning of £1500 is created")]
        public void ThenTheFirstEarningOf1500IsCreated()
        {
            AssertPendingPayment(1500, 1, 2122, EarningType.FirstPayment);
        }

        [Then(@"the second earning of £1500 is created")]
        public void ThenTheSecondEarningOf1500IsCreated()
        {
            AssertPendingPayment(1500, 10, 2122, EarningType.SecondPayment);
        }

        private void AssertPendingPayment(int amount, byte period, short year, EarningType earningType)
        {
            var pp = _newEarnings.Single(x =>
                x.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                && x.EarningType == earningType
                && !x.ClawedBack);

            pp.Amount.Should().Be(amount);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(period);
            pp.PaymentYear.Should().Be(year);
        }
}
}
