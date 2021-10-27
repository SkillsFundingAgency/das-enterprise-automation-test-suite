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
    [Scope(Feature = "RetrospectiveBreakInLearning")]
    public class RetrospectiveBreakInLearningSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private List<PendingPayment> _newEarnings;
        private DateTime _breakStart;
        private DateTime _breakEnd;
        private DateTime _initialEndDate;
        private int _expectedPaymentAmount;
        private Phase _phase;
        private DateTime _submittedOn;

        protected RetrospectiveBreakInLearningSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an existing (.*) apprenticeship incentive with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentive(string phase, DateTime startDate, DateTime endDate)
        {
            _phase = Enum.Parse<Phase>(phase);
            _initialStartDate = startDate;
            _initialEndDate = endDate;
            _submittedOn = _phase == Phase.Phase1 ? new DateTime(2020, 11, 1) : new DateTime(2021, 4, 1);

            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(6, 2021);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithDateSubmitted(_submittedOn)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN,
                    _initialStartDate, _initialStartDate.AddYears(-20),
                    _phase)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [Given(@"a payment of £(.*) is not sent in Period R(.*)")]
        public void GivenAPaymentOfIsNotSentInPeriodR(int amount, string p1)
        {
            _expectedPaymentAmount = amount;
        }

        [Given(@"a payment of £(.*) is sent in Period R(.*)")]
        public void GivenAPaymentOfIsSentInPeriodR(int amount, string p1)
        {
            _expectedPaymentAmount = amount;
        }

        [Given(@"Learner data is updated with a Break in Learning of 28 days after the first payment due date")]
        public async Task GivenLearnerDataIsUpdatedWithABreakInLearningOfDaysAfterTheFirstPaymentDueDate()
        {
            _breakStart = _initialStartDate.AddDays(89);
            _breakEnd = _breakStart.AddDays(27);
            await SetupBreakInLearning();
        }

        [Given(@"Learner data is updated with a Break in Learning of 28 days before the first payment due date")]
        public async Task GivenABreakInLearningBeforeTheFirstPayment() // WORKS
        {
            _breakStart = _initialStartDate.AddDays(88);
            _breakEnd = _breakStart.AddDays(27);
            await SetupBreakInLearning();
        }

        [Given(@"Learner data is updated with a Break in Learning of less than 28 days before the first payment due date")]
        public async Task GivenAShortBreakInLearningBeforeTheFirstPayment()
        {
            _breakStart = _initialStartDate.AddDays(88);
            _breakEnd = _breakStart.AddDays(26);
            await SetupBreakInLearning();
        }

        private async Task SetupBreakInLearning()
        {
            var academicYear = _phase == Phase.Phase1 ? 2021 : 2122;
            var priceEpisode1 = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_breakStart.AddDays(-1))
                .WithPeriod(TestData.ApprenticeshipId, 11)
                .Create();

            var priceEpisode2 = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(academicYear)
                .WithStartDate(_breakEnd.AddDays(1))
                .WithEndDate(_initialEndDate)
                .WithPeriod(TestData.ApprenticeshipId, 1)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(academicYear)
                .WithIlrSubmissionDate(_submittedOn.AddMonths(1))
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode1)
                .WithPriceEpisode(priceEpisode2)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the Learner Match is run in Period R(.*) (.*)")]
        public async Task WhenTheLearnerMatchIsRunInPeriodR(byte period, short year)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"the earnings are recalculated")]
        public void WhenTheEarningsAreRecalculated()
        {
            _newEarnings = Helper.EISqlHelper.GetAllFromDatabase<PendingPayment>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId).ToList();
        }

        [Then(@"the Break in Learning is recorded")]
        public void ThenTheBreakInLearningIsRecorded()
        {
            var breaksInLearning = Helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipBreakInLearning>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId)
                .OrderBy(x => x.StartDate)
                .ToList();

            breaksInLearning.Count.Should().BeGreaterOrEqualTo(1);
            breaksInLearning.First().StartDate.Should().Be(_breakStart);
            breaksInLearning.First().EndDate.Should().Be(_breakEnd);
        }

        [Then(@"no Break in Learning is recorded")]
        public void ThenNoBreakInLearningIsRecorded()
        {
            var breaksInLearning = Helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipBreakInLearning>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId).ToList();

            breaksInLearning.Count.Should().Be(0);
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

        [Then(@"the pending payments are not changed")]
        public void ThenThePendingPaymentsAreNotChanged()
        {
            AssertPendingPayment(_expectedPaymentAmount, 7, 2021, EarningType.FirstPayment);
            AssertPendingPayment(_expectedPaymentAmount, 4, 2122, EarningType.SecondPayment);
        }

        [Then(@"the Learner is In Learning")]
        public void ThenTheLearnerIsInLearning()
        {
            var learner = Helper.EISqlHelper.GetFromDatabase<Learner>(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);
            learner.InLearning.Should().BeTrue();
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
