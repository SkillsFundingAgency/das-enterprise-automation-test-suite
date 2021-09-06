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
    public class AcademicYearRolloverSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private DateTime _endDate;
        private LearnerSubmissionDto _submission;

        protected AcademicYearRolloverSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an existing Phase1 apprenticeship incentive")]
        public async Task GivenAnExistingPhase1ApprenticeshipIncentive()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(11, 2021);

            _initialStartDate = new DateTime(2021, 1, 5);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _initialStartDate,
                    _initialStartDate.AddYears(-24), Phase.Phase1)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }


        [Given(@"the end date of the most recent price episode is before the census date of the active collection period")]
        public async Task GivenTheEndDateOfTheMostRecentPriceEpisodeIsBeforeTheCensusDateOfTheActiveCollectionPeriod()
        {
            var census = Helper.CollectionCalendarHelper.GetActiveCollectionPeriod().CensusDate;
            _endDate = census.AddDays(-1);
            await SetupIlrDataAndRunLearnerMatch();
        }

        [When(@"a call to the learner match service is made for an incentive application after the census date for R12 of the previous academic year")]
        public async Task GivenACallToTheLearnerMatchServiceIsMadeForAnIncentiveApplicationAfterTheCensusDateForROfThePreviousAcademicYear()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(1, 2122);
            await Helper.LearnerMatchOrchestratorHelper.Run();

        }

        [Given(@"the end date of the most recent price episode is the census date of the previous Academic Year")]
        public async Task GivenTheEndDateOfTheMostRecentPriceEpisodeIsTheCensusDateOfThePreviousAcademicYear()
        {
            _endDate = new DateTime(2021, 7, 31);
            await SetupIlrDataAndRunLearnerMatch();
        }

        [Given(@"the end date of the most recent price episode is before the census date of the previous Academic Year")]
        public async Task GivenTheEndDateOfTheMostRecentPriceEpisodeIsBeforeTheCensusDateOfThePreviousAcademicYear()
        {
            _endDate = new DateTime(2021, 6, 19);
            await SetupIlrDataAndRunLearnerMatch();
        }

        [Then(@"trigger a Learning stopped CoC event")]
        public void ThenTriggerALearningStoppedCoCEvent()
        {
            var coc = Helper.EISqlHelper.GetFromDatabase<ChangeOfCircumstance>(
                x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId
                && x.ChangeType == ChangeOfCircumstanceType.LearningStopped);

            DateTime.Parse(coc.NewValue).Should().Be(_endDate.AddDays(1));
            coc.PreviousValue.Should().BeNullOrEmpty();
            coc.ChangedDate.Should().BeCloseTo(DateTime.Today);
        }

        [Then(@"do not trigger a learning stopped CoC event")]
        public void ThenDoNotTriggerALearningStoppedCoCEvent()
        {
            Helper.EISqlHelper.GetAllFromDatabase<ChangeOfCircumstance>()
                .Any(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId)
                .Should().BeFalse();
        }

        [When(@"in period R01 of the new academic year the most recent price episode has no periods")]
        public async Task WhenInPeriodROfTheNewAcademicYearTheMostRecentPriceEpisodeHasNoPeriods()
        {
            _endDate = DateTime.Parse("2021-08-10T00:00:00");

            var episode = new PriceEpisodeDtoBuilder() // price episode with no periods
                .WithAcademicYear(2122)
                .WithStartDate(DateTime.Parse("2021-08-01T00:00:00"))
                .WithEndDate(_endDate)
                .Create();

            _submission.Training.First().PriceEpisodes.Add(episode);

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, _submission);
        }


        private async Task SetupIlrDataAndRunLearnerMatch()
        {
            const byte period = 4;
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_endDate)
                .WithPeriod(TestData.ApprenticeshipId, period)
                .Create();

            _submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(-1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, _submission);
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }
    }
}
