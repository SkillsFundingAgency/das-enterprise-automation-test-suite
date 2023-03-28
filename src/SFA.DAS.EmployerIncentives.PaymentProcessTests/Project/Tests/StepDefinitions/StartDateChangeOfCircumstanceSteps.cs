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
        }

        [Given(@"an existing apprenticeship incentive with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentiveWithLearningStartingIn_Oct(
            DateTime startDate,
            DateTime endDate)
        {
            _initialStartDate = startDate;
            _initialEndDate = endDate;
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(6, 2021);

            var dateOfBirth = _initialStartDate.AddYears(-24).AddMonths(-11); // under 25 at the start of learning 

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(111222, 123123)
				.WithDateSubmitted(_initialStartDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _initialStartDate, dateOfBirth, Context.ScenarioInfo.Title, Phase.Phase1)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [Given(@"an existing phase 2 apprenticeship incentive for a learner under 25 years old")]
        public async Task GivenAPhase2IncentiveForLearnerUnder25()
        {
            _initialStartDate = new DateTime(2021, 04, 01);
            _initialEndDate = new DateTime(2023, 04, 01);
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(6, 2021);

            var dateOfBirth = _initialStartDate.AddYears(-24).AddMonths(-11); // under 25 at the start of learning 

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(111222, 123123)
				.WithDateSubmitted(_initialStartDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _initialStartDate, dateOfBirth, Context.ScenarioInfo.Title, Phase.Phase2)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [Given(@"an existing phase 3 apprenticeship incentive for a learner under 25 years old")]
        public async Task GivenAPhase3IncentiveForLearnerUnder25()
        {
            _initialStartDate = new DateTime(2021, 10, 01);
            _initialEndDate = new DateTime(2023, 04, 01);
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(3, 2122);

            var dateOfBirth = _initialStartDate.AddYears(-24).AddMonths(-11); // under 25 at the start of learning 

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(111222, 123123)
                .WithDateSubmitted(_initialStartDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _initialStartDate, dateOfBirth, Context.ScenarioInfo.Title, Phase.Phase3)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [Given(@"an existing phase 2 apprenticeship incentive")]
        public async Task GivenAPhase2Incentive()
        {
            await GivenAPhase2IncentiveForLearnerUnder25();
        }

        [Given(@"an existing phase 3 apprenticeship incentive")]
        public async Task GivenAPhase3Incentive()
        {
            await GivenAPhase3IncentiveForLearnerUnder25();
        }

        [Given(@"a payment of £(.*) sent in Period R(.*) (.*)")]
        public async Task GivenAPaymentOf1000SentInPeriodR072021(int amount, byte period, short year)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(TestData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionDataR7 = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionDataR7);
            await Helper.LearnerMatchOrchestratorHelper.Run();

            await Helper.BusinessCentralApiHelper.AcceptAllPayments();
            await Helper.EmploymentCheckHelper.CompleteEmploymentCheck(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedAtStartOfApprenticeship, true);
            await Helper.EmploymentCheckHelper.CompleteEmploymentCheck(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedBeforeSchemeStarted, false);
            await Helper.PaymentsOrchestratorHelper.Run();
            await Helper.PaymentsOrchestratorHelper.Approve();

            _initialEarning = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p =>
                p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarning.PaymentMadeDate.Should().NotBeNull();

            _payment = Helper.EISqlHelper.GetFromDatabase<Payment>(p =>
                p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarning.Id);
            _payment.Should().NotBeNull();
            _payment.PaidDate.Should().NotBeNull();
            _payment.Amount.Should().Be(amount);
        }

        [Given(@"a start date change of circumstance occurs in Period R(.*) (.*)")]
        public async Task GivenAStartDateChangeOfCircumstanceOccursInPeriod(byte period, short year)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);
        }

        [Given(
            @"learner data is updated with a new learning start date (.*) making the learner over twenty five at the start of learning")]
        public async Task
            GivenLearnerDataIsUpdatedWithANewValidStartDateMakingTheLearnerOverTwentyFiveAtTheStartOfLearning(
                DateTime newStartDate)
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(newStartDate)
                .WithEndDate("2023-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 8)
                .Create();

            var learnerSubmissionDataR8 = CreateLearnerSubmissionDto(newStartDate, priceEpisode, 2021);

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionDataR8);
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"the incentive learner data is refreshed")]
        public async Task WhenTheIncentiveLearnerDataIsRefreshed()
        {
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"the start date is changed making the learner 25 on the start date")]
        public async Task WhenTheStartDateIsChangedMakingTheLearner25OnTheStartDate()
        {
            var newStartDate = new DateTime(2021, 05, 31);
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(newStartDate)
                .WithEndDate("2023-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 8)
                .Create();

            var learnerSubmissionData = CreateLearnerSubmissionDto(newStartDate, priceEpisode, 2021);

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);

            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"the start date is changed to before the start of the eligibility period in period (.*) AY (.*)")]
        public async Task WhenTheStartDateIsBeforeTheEligibilityPeriod(byte period, short academicYear)
        {       
            var apprenticeshipIncentive = TestData.IncentiveApplication.Apprenticeships.Single();
            PriceEpisodeDto priceEpisode;
            DateTime newStartDate = new DateTime(2021, 03, 31);

            if (apprenticeshipIncentive.Phase == Phase.Phase3)
            {
                await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, academicYear);
                var activePeriod = Helper.CollectionCalendarHelper.GetActiveCollectionPeriod();

                newStartDate = activePeriod.EIScheduledOpenDateUTC.AddDays(-1);
                priceEpisode = new PriceEpisodeDtoBuilder()
                    .WithAcademicYear(academicYear)
                    .WithStartDate(newStartDate)
                    .WithEndDate("2023-10-15T00:00:00")
                    .WithPeriod(TestData.ApprenticeshipId, period)
                    .Create();
            }
            else
            {
                await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(1, 2122);

                priceEpisode = new PriceEpisodeDtoBuilder()
                    .WithAcademicYear(2021)
                    .WithStartDate(newStartDate)
                    .WithEndDate("2023-10-15T00:00:00")
                    .WithPeriod(TestData.ApprenticeshipId, period)
                    .Create();
            }

            var learnerSubmissionData = CreateLearnerSubmissionDto(newStartDate, priceEpisode, academicYear);

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);

            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"the start date is changed to be in the eligibility period (.*) AY (.*)")]
        public async Task WhenTheStartDateIsInTheEligibilityPeriod(byte period, short academicYear)
        {
            var apprenticeshipIncentive = TestData.IncentiveApplication.Apprenticeships.Single();
            PriceEpisodeDto priceEpisode = null;
            DateTime newStartDate = new DateTime(2021, 03, 31);

            if (apprenticeshipIncentive.Phase == Phase.Phase3)
            {
                await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, academicYear);

                var activePeriod = Helper.CollectionCalendarHelper.GetActiveCollectionPeriod();
                newStartDate = activePeriod.EIScheduledOpenDateUTC.AddDays(1);

                priceEpisode = new PriceEpisodeDtoBuilder()
                    .WithAcademicYear(academicYear)
                    .WithStartDate(newStartDate)
                    .WithEndDate("2023-10-15T00:00:00")
                    .WithPeriod(TestData.ApprenticeshipId, period)
                    .Create();
            }
            var learnerSubmissionData = CreateLearnerSubmissionDto(newStartDate, priceEpisode, academicYear);

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);

            await Helper.LearnerMatchOrchestratorHelper.Run();
        }


        [When(@"the start date is changed to a date after the start of the eligibility period in period (.*) AY (.*)")]
        public async Task WhenTheStartDateIsChangedToADateAfterTheStartOfTheEligibilityPeriodInPeriodAcademicYear(byte period, short academicYear)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(1, 2122);

            var newStartDate = new DateTime(2021, 04, 01);
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(newStartDate)
                .WithEndDate("2023-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, period)
                .Create();

            var learnerSubmissionData = CreateLearnerSubmissionDto(newStartDate, priceEpisode, academicYear);

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);

            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        private LearnerSubmissionDto CreateLearnerSubmissionDto(DateTime newStartDate, PriceEpisodeDto priceEpisode, short academicYear)
        {
            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithAcademicYear(2021)
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(academicYear)
                .WithIlrSubmissionDate(DateTime.Now)
                .WithIlrSubmissionWindowPeriod(4)
                .WithStartDate(newStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            return learnerSubmissionData;
        }

        [When(@"the earnings are recalculated")]
        public void WhenTheEarningsAreRecalculated()
        {
            _newEarnings = Helper.EISqlHelper.GetAllFromDatabase<PendingPayment>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId).ToList();
        }

        [Then(@"the paid earning of £(.*) is marked as requiring a clawback in the currently active Period R(.*) (.*)")]
        public void ThenThePaidEarningOfIsMarkedAsRequiringAClawbackInTheCurrentlyActivePeriodR(int amount, byte period,
            short year)
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

        [Then(@"the first earning is removed")]
        public void ThenTheFirstEarningIsRemoved()
        {
            _newEarnings.Any(x => x.EarningType == EarningType.FirstPayment).Should().BeFalse();
        }

        [Then(@"the second earning is removed")]
        public void ThenTheSecondEarningIsRemoved()
        {
            _newEarnings.Any(x => x.EarningType == EarningType.SecondPayment).Should().BeFalse();
        }

        [Then(@"a new first pending payment of £(.*) is created")]
        public void ThenANewFirstPendingPaymentOfIsCreated(int amount)
        {
            var pp = _newEarnings.Single(x =>
                x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId
                && x.EarningType == EarningType.FirstPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(amount);
            pp.PaymentMadeDate.Should().BeNull();
        }

        [Then(@"a new second pending payment of £(.*) is created")]
        public void ThenANewSecondPendingPaymentOfIsCreated(int amount)
        {
            var pp = _newEarnings.Single(x =>
                x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId
                && x.EarningType == EarningType.SecondPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(amount);
            pp.PaymentMadeDate.Should().BeNull();
        }

        private void AssertPendingPayment(int amount, byte period, short year, EarningType earningType)
        {
            var pp = _newEarnings.Single(x =>
                x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId
                && x.EarningType == earningType
                && !x.ClawedBack);

            pp.Amount.Should().Be(amount);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(period);
            pp.PaymentYear.Should().Be(year);
        }
    }
}
