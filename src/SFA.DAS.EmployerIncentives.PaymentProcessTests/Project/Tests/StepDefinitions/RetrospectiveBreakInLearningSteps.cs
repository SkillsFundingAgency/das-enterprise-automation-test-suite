using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "RetrospectiveBreakInLearning")]
    public class RetrospectiveBreakInLearningSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private List<PendingPayment> _newEarnings;

        protected RetrospectiveBreakInLearningSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an existing apprenticeship incentive with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentiveWithLearningStartingIn_Oct(DateTime startDate, DateTime endDate)
        {
            _initialStartDate = startDate;
            _initialEndDate = endDate;
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(6, 2021);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN,
                    startDate, startDate.AddYears(-20), Phase.Phase1)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [Given(@"a payment of £1000 is not sent in Period R07 2021")]
        public void GivenAPaymentIsNotSent()
        {
        }

        [Given(@"Learner data is updated with a Break in Learning of 28 days before the first payment due date")]
        public async Task GivenABreakInLearningBeforeTheFirstPayment()
        {
            await SetupBreakInLearning("2021-02-27T00:00:00", "2021-03-28T00:00:00");
        }

        [Given(@"Learner data is updated with a Break in Learning of less than 28 days before the first payment due date")]
        public async Task GivenAShortBreakInLearningBeforeTheFirstPayment()
        {
            await SetupBreakInLearning("2021-02-27T00:00:00", "2021-03-26T00:00:00");
        }

        private async Task SetupBreakInLearning(string breakStart, string breakEnd)
        {
            var priceEpisode1 = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(breakStart)
                .WithPeriod(TestData.ApprenticeshipId, 7)
                .Create();

            var priceEpisode2 = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(breakEnd)
                .WithEndDate("2021-07-31T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 8)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-02-11T14:06:18.673+00:00")
                .WithIlrSubmissionWindowPeriod(8)
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
        public async Task ThenTheBreakInLearningIsRecorded()
        {
            var breaksInLearning = Helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipBreakInLearning>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId).ToList();

            breaksInLearning.Count.Should().Be(1);
            breaksInLearning.Single().StartDate.Should().Be(new DateTime(2021, 02, 28));
            breaksInLearning.Single().EndDate.Should().Be(new DateTime(2021, 03, 28));
        }

        [Then(@"no Break in Learning is recorded")]
        public async Task ThenNoBreakInLearningIsRecorded()
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
            AssertPendingPayment(1000, 7, 2021, EarningType.FirstPayment);
            AssertPendingPayment(1000, 4, 2122, EarningType.SecondPayment);
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
