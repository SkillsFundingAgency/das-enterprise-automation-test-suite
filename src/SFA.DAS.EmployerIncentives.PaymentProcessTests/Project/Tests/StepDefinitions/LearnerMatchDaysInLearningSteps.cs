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
    [Scope(Feature = "LearnerMatchDaysInLearning")]
    public class LearnerMatchDaysInLearningSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private DateTime _stoppedDate;
        private DateTime _resumedDate;
        private Phase _phase;
        private Learner _learner;

        protected LearnerMatchDaysInLearningSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an existing (.*) apprenticeship incentive submitted in Academic Year (.*)")]
        public async Task GivenAnExistingPhaseApprenticeshipIncentiveSubmittedInAcademicYear(string phase, short year)
        {
            _phase = Enum.Parse<Phase>(phase);
            if (_phase == Phase.Phase1)
            {
                await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(3, year);
                _initialStartDate = new DateTime(2020, 9, 1);
            }
            else
            {
                await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, year);
                _initialStartDate = new DateTime(2021, 5, 5);
            }

            _initialEndDate = DateTime.Today.AddMonths(12);


            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
				.WithDateSubmitted(_initialStartDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _initialStartDate,
                    _initialStartDate.AddYears(-24), _phase)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);

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
                .WithAcademicYear(year)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(-1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, submission);
        }

        [When(@"the Learner Match occurs in Period R(.*) (.*)")]
        public async Task WhenTheLearnerMatchOccursInPeriodR(byte period, short year)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);
            await Helper.LearnerMatchOrchestratorHelper.Run();

            _learner = Helper.EISqlHelper.GetFromDatabase<Learner>(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);
            _learner.Should().NotBeNull();
        }
      

        [Given(@"a successful Learner Match in previous collection period")]
        public async Task GivenASuccessfulLearnerMatchInPreviousCollectionPeriod()
        {
            await WhenTheLearnerMatchOccursInPeriodR(Helper.CollectionCalendarHelper.ActivePeriod.Number,
                Helper.CollectionCalendarHelper.ActivePeriod.Year);

            await Helper.CollectionCalendarHelper.SetNextActiveCollectionPeriod();
        }

        [Given(@"ILR Learner Stopped Change of Circumstance has occurred")]
        public async Task GivenIlrLearnerStoppedChangeOfCircumstanceHasOccurred()
        {
            _stoppedDate = _initialStartDate.AddDays(40);
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_stoppedDate)
                .WithPeriod(TestData.ApprenticeshipId, Helper.CollectionCalendarHelper.ActivePeriod.Number)
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(1))
                .WithIlrSubmissionWindowPeriod(Helper.CollectionCalendarHelper.ActivePeriod.Number)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, submission);
        }

        [Given(@"ILR Learner Resumed Change of Circumstance has occurred in the current period")]
        public async Task GivenIlrLearnerResumedChangeOfCircumstanceHasOccurredInTheCurrentPeriod()
        {
            var priceEpisode1 = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_stoppedDate)
                .WithPeriod(TestData.ApprenticeshipId, Helper.CollectionCalendarHelper.ActivePeriod.Number)
                .Create();

            _resumedDate = _stoppedDate.AddDays(14);
            var priceEpisode2 = new PriceEpisodeDtoBuilder()
                .WithStartDate(_resumedDate)
                .WithEndDate(DateTime.Today.AddMonths(1))
                .WithPeriod(TestData.ApprenticeshipId, (byte)(Helper.CollectionCalendarHelper.ActivePeriod.Number + 1))
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(2))
                .WithIlrSubmissionWindowPeriod(Helper.CollectionCalendarHelper.ActivePeriod.Number)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode1)
                .WithPriceEpisode(priceEpisode2)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, submission);

            await WhenTheLearnerMatchOccursInPeriodR(Helper.CollectionCalendarHelper.ActivePeriod.Number,
                Helper.CollectionCalendarHelper.ActivePeriod.Year);
        }

        [Then(@"the Number of days in learning is calculated and set as a total number of days spent in learning")]
        public void ThenTheNumberOfDaysInLearningIsCalculatedAndSetAsATotalNumberOfDaysSpentInLearning()
        {
            var daysInLearning = Helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id)
                .OrderBy(x => x.NumberOfDaysInLearning).ToList();

            daysInLearning.Count.Should().Be(2);
            var activePeriod = Helper.CollectionCalendarHelper.GetActiveCollectionPeriod();
            var expectedNoOfDays = (_stoppedDate - _initialStartDate).TotalDays + 1 + (activePeriod.CensusDate - _resumedDate).TotalDays + 1;
            daysInLearning.Last().NumberOfDaysInLearning.Should().Be((int)expectedNoOfDays);
            daysInLearning.Last().CollectionPeriodNumber.Should().Be(activePeriod.PeriodNumber);
            daysInLearning.Last().CollectionPeriodYear.ToString().Should().Be(activePeriod.AcademicYear);
        }

        [Then(@"the SubmissionFound Column in Learner table is set to (.*)")]
        public void ThenTheSubmissionFoundColumnInLearnerTableIsSetTo(bool value)
        {
            _learner.SubmissionFound.Should().Be(value); 
        }

        [Then(@"the LearningFound Column in Learner table is set to (.*)")]
        public void ThenTheLearningFoundColumnInLearnerTableIsSetTo(bool value)
        {
            _learner.LearningFound.Should().Be(value);
        }

        [Then(@"the InLearning Column in Learner table is set to (.*)")]
        public void ThenTheInLearningColumnInLearnerTableIsSetTo(bool value)
        {
            _learner.InLearning.Should().Be(value);
        }

        [Then(@"the Number of days in learning is calculated and set as ILRStart Date to LearningStoppedDate in the Learner table")]
        public void ThenTheNumberOfDaysInLearningIsCalculatedAndSetAsIlrStartDateToLearningStoppedDateInTheLearnerTable()
        {
            var daysInLearning = Helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id)
                .OrderBy(x => x.NumberOfDaysInLearning).ToList();

            daysInLearning.Count.Should().Be(1);
            var activePeriod = Helper.CollectionCalendarHelper.GetActiveCollectionPeriod();
            var expectedNoOfDays = (_stoppedDate - _initialStartDate).TotalDays + 1;
            daysInLearning.First().NumberOfDaysInLearning.Should().Be((int)expectedNoOfDays);
            daysInLearning.First().CollectionPeriodNumber.Should().Be(activePeriod.PeriodNumber);
            daysInLearning.First().CollectionPeriodYear.ToString().Should().Be(activePeriod.AcademicYear);
        }

        [Then(@"the Number of days in learning is calculated and set as number of days from ILRStart Date to Census date of the Active Period")]
        public void ThenTheNumberOfDaysInLearningIsCalculatedAndSetAsNumberOfDaysFromIlrStartDateToCensusDateOfTheActivePeriod()
        {
            var daysInLearning = Helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id).ToList();

            daysInLearning.Count.Should().Be(1);
            var activePeriod = Helper.CollectionCalendarHelper.GetActiveCollectionPeriod();
            var expectedNoOfDays = (activePeriod.CensusDate - _initialStartDate).TotalDays + 1;
            daysInLearning.First().NumberOfDaysInLearning.Should().Be((int) expectedNoOfDays);
            daysInLearning.First().CollectionPeriodNumber.Should().Be(activePeriod.PeriodNumber);
            daysInLearning.First().CollectionPeriodYear.ToString().Should().Be(activePeriod.AcademicYear);
        }

        [Then(@"the Number of days in learning is re-calculated and set as number of days from ILRStart Date to Census date of the Active Period")]
        public void ThenTheNumberOfDaysInLearningIsRe_CalculatedAndSetAsNumberOfDaysFromILRStartDateToCensusDateOfTheActivePeriod()
        {
            var daysInLearning = Helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id)
                .OrderBy(x => x.NumberOfDaysInLearning).ToList();

            daysInLearning.Count.Should().Be(2);
            var activePeriod = Helper.CollectionCalendarHelper.GetActiveCollectionPeriod();
            var expectedNoOfDays = (activePeriod.CensusDate - _initialStartDate).TotalDays + 1;
            daysInLearning.Last().NumberOfDaysInLearning.Should().Be((int)expectedNoOfDays);
            daysInLearning.Last().CollectionPeriodNumber.Should().Be(activePeriod.PeriodNumber);
            daysInLearning.Last().CollectionPeriodYear.ToString().Should().Be(activePeriod.AcademicYear);
        }
    }
}
