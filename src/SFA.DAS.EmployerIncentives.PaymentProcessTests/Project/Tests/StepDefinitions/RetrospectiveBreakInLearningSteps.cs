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
        private DateTime _initialEndDate;
        private int _expectedPaymentAmount;
        private Phase _phase;
        private DateTime _submittedOn;
        private List<Tuple<DateTime, DateTime>> _breaksInLearning = new List<Tuple<DateTime, DateTime>>();

        protected RetrospectiveBreakInLearningSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(
            @"an existing (.*) apprenticeship incentive with learning starting on (.*) and ending on (.*) submitted on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentive(string phase, DateTime startDate, DateTime endDate, DateTime submittedOn)
        {
            _phase = Enum.Parse<Phase>(phase);
            _initialStartDate = startDate;
            _initialEndDate = endDate;
            _submittedOn = submittedOn;

            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(6, 2021);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithDateSubmitted(_submittedOn)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN,
                    _initialStartDate, _initialStartDate.AddYears(-20),
                    Context.ScenarioInfo.Title, _phase)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);

            await SetupSubmissionWithNoBreakInLearning();
        }

        [Given(@"an existing (.*) apprenticeship incentive with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentive(string phase, DateTime startDate, DateTime endDate)
        {
            _phase = Enum.Parse<Phase>(phase);
            var submittedOn = _phase == Phase.Phase1 ? new DateTime(2020, 11, 1) : new DateTime(2021, 4, 1);
            await GivenAnExistingApprenticeshipIncentive(phase, startDate, endDate, submittedOn);
        }

        [Given(@"a payment of £(.*) is not sent in Period R(.*)")]
        public void GivenAPaymentOfIsNotSentInPeriodR(int amount, string p1)
        {
            _expectedPaymentAmount = amount;
        }

        [Given(@"a payment of £(.*) is sent in Period R(.*) (.*)")]
        public async Task GivenAPaymentOfIsSentInPeriodR(int amount, byte period, short academicYear)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, academicYear);

            await Helper.LearnerMatchOrchestratorHelper.Run();

            await Helper.BusinessCentralApiHelper.AcceptAllPayments();
            await Helper.EmploymentCheckHelper.CompleteEmploymentCheck(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedAtStartOfApprenticeship, true);
            await Helper.EmploymentCheckHelper.CompleteEmploymentCheck(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedBeforeSchemeStarted, false);
            await Helper.PaymentsOrchestratorHelper.Run();
            await Helper.PaymentsOrchestratorHelper.Approve();

            var payments = Helper.EISqlHelper.GetAllFromDatabase<Payment>()
               .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId)
               .ToList();

            payments.Count.Should().Be(1);            

            _expectedPaymentAmount = amount;
        }

        [Given(@"Learner data is updated with a Break in Learning of 28 days after the first payment due date")]
        public async Task GivenLearnerDataIsUpdatedWithABreakInLearningOfDaysAfterTheFirstPaymentDueDate()
        {
            var breakStart = _initialStartDate.AddDays(89);
            var breakEnd = breakStart.AddDays(27);

            _breaksInLearning.Add(new Tuple<DateTime, DateTime>(breakStart, breakEnd));
            await SetupBreakInLearning();
        }

        [Given(@"Learner data is updated with a Break in Learning of 56 days after the first payment due date")]
        public async Task GivenLearnerDataIsUpdatedWithAnUpdatedBreakInLearningOfDaysAfterTheFirstPaymentDueDate()
        {
            _breaksInLearning.Clear();
            var breakStart = _initialStartDate.AddDays(89);
            var breakEnd = breakStart.AddDays(55);

            _breaksInLearning.Add(new Tuple<DateTime, DateTime>(breakStart, breakEnd));
            await SetupBreakInLearning();
        }

        [Given(@"Learner data is updated with a Break in Learning of 28 days before the first payment due date")]
        public async Task GivenABreakInLearningBeforeTheFirstPayment() // WORKS
        {
            var breakStart = _initialStartDate.AddDays(88);
            var breakEnd = breakStart.AddDays(27);
            _breaksInLearning.Add(new Tuple<DateTime, DateTime>(breakStart, breakEnd));
            await SetupBreakInLearning();
        }

        [Given(@"Learner data is updated with a Break in Learning of 28 days before the first payment due date starting (.*)")]
        public async Task GivenABreakInLearningBeforeTheFirstPaymentStarting(DateTime startDate)
        {
            var breakStart = startDate;
            var breakEnd = breakStart.AddDays(27);
            _breaksInLearning.Add(new Tuple<DateTime, DateTime>(breakStart, breakEnd));
            await SetupBreakInLearning();
        }

        [Given(@"Learner data is updated with a Break in Learning of less than 28 days before the first payment due date")]
        public async Task GivenAShortBreakInLearningBeforeTheFirstPayment()
        {
            var breakStart = _initialStartDate.AddDays(88);
            var breakEnd = breakStart.AddDays(26);
            _breaksInLearning.Add(new Tuple<DateTime, DateTime>(breakStart, breakEnd));
            await SetupBreakInLearning();
        }

        [Given(@"Learner data is updated with a Break in Learning of 28 days starting 1 month after the first break resume")]
        public async Task GivenASecondBreakInLearning()
        {
            var breakStart = _breaksInLearning.First().Item2.AddMonths(1);
            var breakEnd = breakStart.AddDays(27);
            _breaksInLearning.Add(new Tuple<DateTime, DateTime>(breakStart, breakEnd));
            await SetupBreakInLearning();
        }

        [Given(@"Learner data is updated with learning starting on (.*) and ending on (.*)")]
        public async Task GivenLearningStartDateIsUpdated(DateTime startDate, DateTime endDate)
        {
            _initialStartDate = startDate;
            _initialEndDate = endDate;

            _breaksInLearning.Clear();
            
            await SetupSubmissionWithNoBreakInLearning();
        }

        private async Task SetupBreakInLearning()
        {
            var academicYear = _phase == Phase.Phase1 ? 2021 : 2122;

            var learnerSubmissionBuilder = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(academicYear)
                .WithIlrSubmissionDate(_submittedOn.AddMonths(1))
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(_initialStartDate);

            for (int i = 0; i < _breaksInLearning.Count; i++)
            {
                var priceEpisode = new PriceEpisodeDtoBuilder()
                    .WithAcademicYear(academicYear)
                    .WithStartDate(i == 0 ? _initialStartDate : _breaksInLearning[i-1].Item2.AddDays(1))
                    .WithEndDate(_breaksInLearning[i].Item1.AddDays(-1))
                    .WithPeriod(TestData.ApprenticeshipId, 11)
                    .Create();

                learnerSubmissionBuilder.WithPriceEpisode(priceEpisode);
            }

            var lastPriceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(academicYear)
                .WithStartDate(_breaksInLearning[_breaksInLearning.Count - 1].Item2.AddDays(1))
                .WithEndDate(_initialEndDate)
                .WithPeriod(TestData.ApprenticeshipId, 1)
                .Create();

            var learnerSubmissionData = learnerSubmissionBuilder.WithPriceEpisode(lastPriceEpisode).Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        private async Task SetupSubmissionWithNoBreakInLearning()
        {
            var academicYear = _phase == Phase.Phase1 ? 2021 : 2122;

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(academicYear)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(TestData.ApprenticeshipId, 11)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(academicYear)
                .WithIlrSubmissionDate(_submittedOn.AddMonths(1))
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [Given(@"the Learner Match is run in Period R(.*) (.*)")]
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

        [Given(@"the Payment Run occurs")]
        [When(@"the Payment Run occurs")]
        public async Task WhenThePaymentRunOccurs()
        {
            await Helper.LearnerMatchOrchestratorHelper.Run();
            await Helper.EmploymentCheckHelper.CompleteEmploymentCheck(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedAtStartOfApprenticeship, true);
            await Helper.EmploymentCheckHelper.CompleteEmploymentCheck(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedBeforeSchemeStarted, false);
            await Helper.PaymentsOrchestratorHelper.Run();
            await Helper.CollectionCalendarHelper.Reset();
        }

        [Then(@"the Break in Learning is recorded")]
        [Then(@"the Break in Learning is amended")]
        [Then(@"the Break in Learning is Removed")]
        public void ThenTheBreakInLearningIsRecorded()
        {
            var breaksInLearning = Helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipBreakInLearning>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId)
                .OrderBy(x => x.StartDate)
                .ToList();

            breaksInLearning.Count.Should().Be(_breaksInLearning.Count);
            foreach (var expectedBreak in _breaksInLearning)
            {
                breaksInLearning.Should().Contain(x => x.StartDate == expectedBreak.Item1);
                breaksInLearning.Should().Contain(x => x.EndDate == expectedBreak.Item2);
            }
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

        [Then(@"the first payment is still in Period R(.*) (.*)")]
        public void ThenTheFirstPaymentIsNotChanged(byte period, short year)
        {
            AssertPendingPayment(1500, period, year, EarningType.FirstPayment);
        }

        [Then(@"the Learner is In Learning")]
        public void ThenTheLearnerIsInLearning()
        {
            var learner = Helper.EISqlHelper.GetFromDatabase<Learner>(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);
            learner.InLearning.Should().BeTrue();
        }

        [Then(@"the paid earning of £(.*) is marked as requiring a clawback in Period R(.*) (.*)")]        
        public void ThenAClawbackIsRecorded(int amount, byte period, short year)
        {
            var clawbacks = Helper.EISqlHelper.GetAllFromDatabase<ClawbackPayment>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId).ToList();

            clawbacks.Count.Should().Be(1);
            var clawback = clawbacks.Single();
            clawback.Amount.Should().Be(amount * -1);
            clawback.CollectionPeriod.Should().Be(period);
            clawback.CollectionPeriodYear.Should().Be(year);
        }

        [Then(@"the Days In Learning validation succeeds")]
        public void ThenDaysInLearningValidationSucceeds()
        {
            var pendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && x.EarningType == EarningType.FirstPayment);

            var validationStep = Helper.EISqlHelper.GetFromDatabase<PendingPaymentValidationResult>(x =>
                x.PendingPaymentId == pendingPayment.Id
                && x.Step == "HasDaysInLearning");

            validationStep.Should().NotBeNull();
            validationStep.Result.Should().BeTrue();
        }

        [Then(@"the payment record for the first earnings is created")]
        public void ThenThePaymentRecordIsCreated()
        {
            var payment = Helper.EISqlHelper.GetSingleOrDefaultFromDatabase<Payment>(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);
            payment.Should().NotBeNull();
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
