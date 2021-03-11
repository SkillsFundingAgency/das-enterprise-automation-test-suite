using FluentAssertions;
using SFA.DAS.EmployerIncentives.UITests.Models;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "StartDateChangeOfCircumstance-Builders")]
    public class StartDateChangeOfCircumstanceBuildersSteps : StepsBase
    {
        // from JSON
        private const long Uln = 7229721930;
        private const long Ukprn = 10005311;
        private const long AccountId = 14326;
        private const long ApprenticeshipId = 133217;
        private readonly DateTime _plannedStartDate = DateTime.Parse("2020-11-12T00:00:00");

        private Payment _payment;
        private PendingPayment _initialEarning;
        private List<PendingPayment> _newEarnings;

        public StartDateChangeOfCircumstanceBuildersSteps(ScenarioContext context) : base(context) { }

        [Given(@"an existing apprenticeship incentive with learning starting on 12-Nov-2020")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            await SetActiveCollectionPeriod(6, 2021);

            var dateOfBirth = _plannedStartDate.AddYears(-24).AddMonths(-11); // under 25 at the start of learning 

            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(AccountId)
                .WithApprenticeship(ApprenticeshipId, Uln, Ukprn, _plannedStartDate, dateOfBirth)
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);
        }

        [Given(@"a payment of £1000 sent in Period R07 2021")]
        public async Task GivenAPaymentOf1000SentInPeriodR072021()
        {
            await SetActiveCollectionPeriod(7, activePaymentPeriod.Year);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(_plannedStartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionDataR7 = new LearnerSubmissionDtoBuilder()
                .WithUkprn(Ukprn)
                .WithUln(Uln)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(_plannedStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(Uln, Ukprn, learnerSubmissionDataR7);
            await RunLearnerMatchOrchestrator();

            await SetupBusinessCentralApiToAcceptAllPayments();
            await RunPaymentsOrchestrator();
            await RunApprovePaymentsOrchestrator();

            _initialEarning = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarning.PaymentMadeDate.Should().NotBeNull();

            _payment = GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarning.Id);
            _payment.Should().NotBeNull();
            _payment.PaidDate.Should().NotBeNull();
        }

        [Given(@"a start date change of circumstance occurs in Period R08 2021")]
        public async Task GivenAStartDateChangeOfCircumstanceOccursInPeriodR09()
        {
            await SetActiveCollectionPeriod(8, activePaymentPeriod.Year);
        }

        [Given(@"learner data is updated with a new learning start date 13-Dec-2020 making the learner over twenty five at the start of learning")]
        public async Task GivenLearnerDataIsUpdatedWithANewValidStartDateMakingTheLearnerOverTwentyFiveAtTheStartOfLearning()
        {
            var newStartDate = DateTime.Parse("2020-12-13T00:00:00");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(newStartDate)
                .WithEndDate("2023-10-15T00:00:00")
                .WithPeriod(ApprenticeshipId, 8)
                .Create();

            var learnerSubmissionDataR8 = new LearnerSubmissionDtoBuilder()
                .WithUkprn(Ukprn)
                .WithUln(Uln)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(DateTime.Parse("2021-01-10T09:11:46.82"))
                .WithIlrSubmissionWindowPeriod(4)
                .WithStartDate(newStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(Uln, Ukprn, learnerSubmissionDataR8);
            await RunLearnerMatchOrchestrator();
        }

        [When(@"the incentive learner data is refreshed")]
        public async Task WhenTheIncentiveLearnerDataIsRefreshed()
        {
            await RunLearnerMatchOrchestrator();
        }

        [When(@"the earnings are recalculated")]
        public void WhenTheEarningsAreRecalculated()
        {
            _newEarnings = GetAllFromDatabase<PendingPayment>();
        }

        [Then(@"the paid earning of £1000 is marked as requiring a clawback in the currently active Period R08 2021")]
        public void ThenThePaidEarningOfIsMarkedAsRequiringAClawbackInTheCurrentlyActivePeriodR()
        {
            var pendingPayment = GetFromDatabase<PendingPayment>(p => p.Id == _initialEarning.Id);
            pendingPayment.PaymentMadeDate.Should().NotBeNull();
            pendingPayment.ClawedBack.Should().BeTrue();

            var clawback = GetFromDatabase<ClawbackPayment>(p => p.PendingPaymentId == _initialEarning.Id);
            clawback.Should().BeEquivalentTo(_payment, opt => opt.ExcludingMissingMembers()
                .Excluding(x => x.Id)
                .Excluding(x => x.Amount)
            );

            clawback.Amount.Should().Be(-1000);
            clawback.CollectionPeriodYear.Should().Be(2021);
            clawback.CollectionPeriod.Should().Be(8);
        }

        [Then(@"a new first pending payment of £750 is created for Period R08 2021")]
        public void ThenANewFirstPendingPaymentOfIsCreated()
        {
            var pp = _newEarnings.Single(x =>
                x.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                && x.EarningType == EarningType.FirstPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(8);
            pp.PaymentYear.Should().Be(2021);
        }

        [Then(@"a new second pending payment of £750 is created for Period R05 2122")]
        public void ThenANewSecondPendingPaymentOfIsCreated()
        {
            var pp = _newEarnings.Single(x =>
                 x.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                && x.EarningType == EarningType.SecondPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(5);
            pp.PaymentYear.Should().Be(2122);
        }
    }
}
