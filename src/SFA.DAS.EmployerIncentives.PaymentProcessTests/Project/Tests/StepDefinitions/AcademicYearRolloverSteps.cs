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
        private DateTime _initialEndDate;
        private Learner _learner;

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
            _initialEndDate = census.AddDays(-1);
            await SetupIlrDataAndRunLearnerMatch();
        }

        [When(@"a call to the learner match service is made for an incentive application after the census date for R12 of the previous academic year")]
        public async Task GivenACallToTheLearnerMatchServiceIsMadeForAnIncentiveApplicationAfterTheCensusDateForROfThePreviousAcademicYear()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(1, 2122);
            await Helper.LearnerMatchOrchestratorHelper.Run();
            _learner = Helper.EISqlHelper.GetFromDatabase<Learner>(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);
            _learner.Should().NotBeNull();
        }

        [Given(@"the end date of the most recent price episode is the census date of the previous Academic Year")]
        public async Task GivenTheEndDateOfTheMostRecentPriceEpisodeIsTheCensusDateOfThePreviousAcademicYear()
        {
            _initialEndDate = new DateTime(2021, 7, 31);
            await SetupIlrDataAndRunLearnerMatch();
        }

        [Given(@"the end date of the most recent price episode is before the census date of the previous Academic Year")]
        public async Task GivenTheEndDateOfTheMostRecentPriceEpisodeIsBeforeTheCensusDateOfThePreviousAcademicYear()
        {
            _initialEndDate = new DateTime(2021, 6, 19);
            await SetupIlrDataAndRunLearnerMatch();
        }

        [Then(@"trigger a Learning stopped CoC event")]
        public void ThenTriggerALearningStoppedCoCEvent()
        {
            var coc = Helper.EISqlHelper.GetFromDatabase<ChangeOfCircumstance>(
                x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId
                && x.ChangeType == ChangeOfCircumstanceType.LearningStopped);

            DateTime.Parse(coc.NewValue).Should().Be(_initialEndDate.AddDays(1));
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

        private async Task SetupIlrDataAndRunLearnerMatch()
        {
            const byte period = 4;
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(TestData.ApprenticeshipId, period)
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(-1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, submission);
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }
    }
}
