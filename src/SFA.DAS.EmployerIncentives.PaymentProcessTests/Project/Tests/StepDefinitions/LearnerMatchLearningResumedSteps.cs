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
    [Scope(Feature = "LearnerMatchLearningResumed")]
    public class LearnerMatchLearningResumedSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private DateTime _stoppedDate;
        private DateTime _resumedDate;
        private Phase _phase;
        private Learner _learner;

        protected LearnerMatchLearningResumedSteps(ScenarioContext context) : base(context)
        {
            testData.AccountId = 14326;
        }

        [Given(@"an existing (.*) apprenticeship incentive submitted in Academic Year (.*)")]
        public async Task GivenAnExistingPhaseApprenticeshipIncentiveSubmittedInAcademicYear(string phase, short year)
        {
            _phase = Enum.Parse<Phase>(phase);
            if (_phase == Phase.Phase1)
            {
                await helper.CollectionCalendarHelper.SetActiveCollectionPeriod(3, year);
                _initialStartDate = new DateTime(2020, 9, 1);
            }
            else
            {
                await helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, year);
                _initialStartDate = new DateTime(2021, 5, 5);
            }

            _initialEndDate = DateTime.Today.AddMonths(12);

            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, _initialStartDate,
                    _initialStartDate.AddYears(-24), _phase)
                .Create();

            await helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            const byte period = 4;
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(testData.ApprenticeshipId, period)
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(year)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(-1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, submission);
        }

        [Given(@"ILR Learner Stopped Change of Circumstance has occurred")]
        public async Task GivenIlrLearnerStoppedChangeOfCircumstanceHasOccurred()
        {
            _stoppedDate = _initialStartDate.AddDays(40);
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_stoppedDate)
                .WithPeriod(testData.ApprenticeshipId, helper.CollectionCalendarHelper.ActivePeriod.Number)
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(1))
                .WithIlrSubmissionWindowPeriod(helper.CollectionCalendarHelper.ActivePeriod.Number)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, submission);
        }

        [Given(@"ILR Learner Resumed Change of Circumstance has occurred in the current period")]
        public async Task GivenIlrLearnerResumedChangeOfCircumstanceHasOccurredInTheCurrentPeriod()
        {
            var priceEpisode1 = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_stoppedDate)
                .WithPeriod(testData.ApprenticeshipId, helper.CollectionCalendarHelper.ActivePeriod.Number)
                .Create();

            _resumedDate = _stoppedDate.AddDays(14);
            var priceEpisode2 = new PriceEpisodeDtoBuilder()
                .WithStartDate(_resumedDate)
                .WithEndDate(DateTime.Today.AddMonths(1))
                .WithPeriod(testData.ApprenticeshipId, (byte)(helper.CollectionCalendarHelper.ActivePeriod.Number + 1))
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(2))
                .WithIlrSubmissionWindowPeriod(helper.CollectionCalendarHelper.ActivePeriod.Number)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode1)
                .WithPriceEpisode(priceEpisode2)
                .Create();

            await helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, submission);

            await WhenTheLearnerMatchOccursInPeriodR(helper.CollectionCalendarHelper.ActivePeriod.Number,
                helper.CollectionCalendarHelper.ActivePeriod.Year);
        }

        [When(@"the Learner Match occurs in Period R(.*) (.*)")]
        public async Task WhenTheLearnerMatchOccursInPeriodR(byte period, short year)
        {
            await helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);
            await helper.LearnerMatchOrchestratorHelper.Run();

            _learner = helper.EISqlHelper.GetFromDatabase<Learner>(x => x.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId);
            _learner.Should().NotBeNull();
        }

        [Given(@"a successful Learner Match in previous collection period")]
        public async Task GivenASuccessfulLearnerMatchInPreviousCollectionPeriod()
        {
            await WhenTheLearnerMatchOccursInPeriodR(helper.CollectionCalendarHelper.ActivePeriod.Number,
                helper.CollectionCalendarHelper.ActivePeriod.Year);

            await helper.CollectionCalendarHelper.SetNextActiveCollectionPeriod();
        }

        [Then(@"earnings are re-calculated")]
        public void ThenEarningsAreRe_Calculated()
        {
            var earnings = helper.EISqlHelper.GetAllFromDatabase<PendingPayment>()
                .Where(x => x.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId)
                .OrderBy(x => x.DueDate).ToList();

            earnings.Should().HaveCount(2);
            var first = earnings.First();
            first.DueDate.Should().Be(_initialStartDate.AddDays(90+11));

            var second = earnings.Last();
            second.DueDate.Should().Be(_initialStartDate.AddDays(365+11));
        }
        
        [Then(@"a Learning Resumed change of circumstance is recorded")]
        public void ThenALearningResumedChangeOfCircumstanceIsRecorded()
        {
            var coc = helper.EISqlHelper.GetAllFromDatabase<ChangeOfCircumstance>()
                .Where(x => x.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId)
                .ToList();

            coc.Should().HaveCount(2);
            var stop = coc.Single(x => x.ChangeType == ChangeOfCircumstanceType.LearningStopped);
            DateTime.Parse(stop.NewValue).Should().Be(_stoppedDate.AddDays(1));
           
            var resume = coc.Single(x => x.ChangeType == ChangeOfCircumstanceType.LearningResumed);
            DateTime.Parse(resume.NewValue).Should().Be(_resumedDate);
        }
    }
}
