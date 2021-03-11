using AutoFixture;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.UITests.Models;
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
        private const long ULN = 7229721937;
        private const long UKPRN = 10005310;
        private const long AccountId = 14326;
        private const long ApprenticeshipId = 133218;
        private readonly DateTime _plannedStartDate = new DateTime(2020, 8, 6);
        private readonly (byte Number, short Year) _paymentPeriod = (6, 2021);

        private PendingPayment _initialEarning;
        private Payment _payment;
        private List<PendingPayment> _newPendingPayments;

        public StartDateChangeOfCircumstanceBuildersSteps(ScenarioContext context) : base(context) { }

        [Given(@"an existing apprenticeship incentive with learning starting on 6-Aug-2020")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            await SetActiveCollectionPeriod(_paymentPeriod.Number, _paymentPeriod.Year);

            var dateOfBirth = _plannedStartDate.AddYears(-24).AddMonths(-10); // under 25 at the start of learning 

            incentiveApplication = incentiveApplicationBuilder.Build()
                .WithAccountId(AccountId)
                .WithApprenticeship(ApprenticeshipId, ULN, UKPRN, _plannedStartDate, dateOfBirth)
                .Create();

            apprenticeshipIncentiveId = await SubmitIncentiveApplication(incentiveApplication);

            var priceEpisode = new TrainingPriceEpisodeBuilder()
                .WithStartDate(DateTime.Parse("2020-08-06T00:00:00"))
                .WithEndDate(DateTime.Parse("2022-10-15T00:00:00"))
                .WithPeriod(ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionDataR7 = new LearnerSubmissionDataBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(DateTime.Parse("2020-12-10T09:11:46.82"))
                .WithIlrSubmissionWindowPeriod(4)
                .WithStartDate(_plannedStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionDataR7);
            await RunLearnerMatchOrchestrator();
        }

        [Given(@"a payment of £1000 sent in Period R07 2021")]
        public async Task GivenAPaymentOf1000SentInPeriodR072021()
        {
            await SetupBusinessCentralApiToAcceptAllPayments();
            await RunPaymentsOrchestrator(_paymentPeriod.Year, _paymentPeriod.Number);
            await RunApprovePaymentsOrchestrator();

            _initialEarning = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId ==
                apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarning.PaymentMadeDate.Should().NotBeNull();

            _payment = GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId ==
                apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarning.Id);
            _payment.Should().NotBeNull();
            _payment.PaidDate.Should().NotBeNull();
        }

        [Given(@"a start date change of circumstance occurs in Period R09 2021")]
        public async Task GivenAStartDateChangeOfCircumstanceOccursInPeriodR09()
        {
            await SetActiveCollectionPeriod(9, _paymentPeriod.Year);
        }

        [Given(@"learner data is updated with a new learning start date 1-Feb-2021 making the learner over twenty five at the start of learning")]
        public async Task GivenLearnerDataIsUpdatedWithANewValidStartDateMakingTheLearnerOverTwentyFiveAtTheStartOfLearning()
        {
            var priceEpisode = new TrainingPriceEpisodeBuilder()
                .WithStartDate(DateTime.Parse("2021-02-01T00:00:00"))
                .WithEndDate(DateTime.Parse("2023-10-15T00:00:00"))
                .WithPeriod(ApprenticeshipId, 8)
                .Create();

            var learnerSubmissionDataR8 = new LearnerSubmissionDataBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(DateTime.Parse("2021-01-10T09:11:46.82"))
                .WithIlrSubmissionWindowPeriod(4)
                .WithStartDate("2021-02-01T00:00:00")
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

        [When(@"the earnings are recalculated")]
        public void WhenTheEarningsAreRecalculated()
        {
            _newPendingPayments = GetAllFromDatabase<PendingPayment>();
        }

        [Then(@"the paid earning of £1000 is marked as requiring a clawback in the currently active Period R09 2021")]
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
            clawback.CollectionPeriod.Should().Be(9);
        }

        [Then(@"a new first pending payment of £750 is created for Period R09 2021")]
        public void ThenANewFirstPendingPaymentOfIsCreated()
        {
            var pp = _newPendingPayments.Single(x =>
                x.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                && x.EarningType == EarningType.FirstPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(9);
            pp.PaymentYear.Should().Be(2021);
        }

        [Then(@"a new second pending payment of £750 is created for Period R06 2122")]
        public void ThenANewSecondPendingPaymentOfIsCreated()
        {
            var pp = _newPendingPayments.Single(x =>
                 x.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                && x.EarningType == EarningType.SecondPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(6);
            pp.PaymentYear.Should().Be(2122);
        }
    }

    public class LearnerSubmissionDataBuilder
    {
        private readonly LearnerSubmissionDto _data;

        public LearnerSubmissionDataBuilder()
        {
            var fixture = new Fixture();
            _data = fixture.Create<LearnerSubmissionDto>();
            _data.Training = new List<TrainingDto>
            {
                new TrainingDto
                {
                    Reference = "ZPROG001",
                    PriceEpisodes = new List<PriceEpisodeDto>()
                }
            };
        }

        public LearnerSubmissionDto Create() => _data;

        public LearnerSubmissionDataBuilder WithStartDate(in DateTime value)
        {
            _data.StartDate = value;
            return this;
        }

        public LearnerSubmissionDataBuilder WithStartDate(in string value)
        {
            _data.StartDate = DateTime.Parse(value);
            return this;
        }


        public LearnerSubmissionDataBuilder WithIlrSubmissionDate(in DateTime value)
        {
            _data.IlrSubmissionDate = value;
            return this;
        }

        public LearnerSubmissionDataBuilder WithAcademicYear(in int value)
        {
            _data.AcademicYear = value;
            return this;
        }


        public LearnerSubmissionDataBuilder WithIlrSubmissionWindowPeriod(in int value)
        {
            _data.IlrSubmissionWindowPeriod = value;
            return this;
        }


        public LearnerSubmissionDataBuilder WithUkprn(in long value)
        {
            _data.Ukprn = value;
            return this;
        }

        public LearnerSubmissionDataBuilder WithUln(in long value)
        {
            _data.Uln = value;
            return this;
        }

        public LearnerSubmissionDataBuilder WithPriceEpisode(in PriceEpisodeDto value)
        {
            _data.Training[0].PriceEpisodes.Add(value);
            return this;
        }
    }

    public class TrainingPriceEpisodeBuilder
    {
        private readonly PriceEpisodeDto _data;

        public TrainingPriceEpisodeBuilder()
        {
            var fixture = new Fixture();
            _data = fixture.Create<PriceEpisodeDto>();
            _data.Periods = new List<PeriodDto>();
        }

        public PriceEpisodeDto Create() => _data;

        public TrainingPriceEpisodeBuilder WithStartDate(in DateTime startDate)
        {
            _data.StartDate = startDate;
            return this;
        }

        public TrainingPriceEpisodeBuilder WithEndDate(in DateTime endDate)
        {
            _data.EndDate = endDate;
            return this;
        }

        public TrainingPriceEpisodeBuilder WithPeriod(long apprenticeshipId, byte period, bool payable = true)
        {
            _data.Periods.Add(new PeriodDto
            {
                ApprenticeshipId = apprenticeshipId,
                IsPayable = payable,
                Period = period
            });
            return this;
        }
    }
}
