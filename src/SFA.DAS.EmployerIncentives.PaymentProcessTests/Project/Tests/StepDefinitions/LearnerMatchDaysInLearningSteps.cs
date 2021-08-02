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
    public class LearnerMatchDaysInLearningSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private Learner _learner;
        private DateTime _stoppedDate;
        private DateTime _resumedDate;

        protected LearnerMatchDaysInLearningSteps(ScenarioContext context) : base(context)
        {
            testData.AccountId = 14326;
        }

        [Given(@"an existing Phase2 apprenticeship incentive")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            await helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, 2021);

            _initialStartDate = new DateTime(2021,5,5);
            _initialEndDate = DateTime.Today.AddMonths(12);

            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, _initialStartDate, 
                    _initialStartDate.AddYears(-24), Phase.Phase2)
                .Create();

            await helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            const byte period = 4;
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(testData.ApprenticeshipId, period)
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(-1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, submission);
        }

        [Given(@"an existing Phase1 apprenticeship incentive")]
        public async Task GivenAnExistingPhaseApprenticeshipIncentive()
        {
            await helper.CollectionCalendarHelper.SetActiveCollectionPeriod(3, 2021);
           
            _initialStartDate = new DateTime(2020, 9, 1);
            _initialEndDate = DateTime.Today.AddMonths(12);

            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, _initialStartDate,
                    _initialStartDate.AddYears(-24), Phase.Phase1)
                .Create();

            await helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            const byte period = 1;
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(testData.ApprenticeshipId, period)
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(-1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, submission);
        }


        [When(@"the Learner Match occurs")]
        public async Task WhenTheLearnerMatchOccurs()
        {
            await helper.LearnerMatchOrchestratorHelper.Run();

            _learner = helper.EISqlHelper.GetFromDatabase<Learner>(x =>
                x.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId);
            _learner.Should().NotBeNull();
        }

        [Given(@"a successful Learner Match in previous collection period")]
        public async Task GivenASuccessfulLearnerMatchInPreviousCollectionPeriod()
        {
            await WhenTheLearnerMatchOccurs();

            await helper.CollectionCalendarHelper.SetNextActiveCollectionPeriod();
        }

        [Given(@"ILR Learner Stopped Change of Circumstance has occurred")]
        public async Task GivenILRLearnerStoppedChangeOfCircumstanceHasOccurred()
        {
            _stoppedDate = _initialStartDate.AddDays(40);
            var priceEpisode = new PriceEpisodeDtoBuilder()
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
        public async Task GivenILRLearnerResumedChangeOfCircumstanceHasOccurredInTheCurrentPeriod()
        {
            var priceEpisode1 = new PriceEpisodeDtoBuilder()
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

            await WhenTheLearnerMatchOccurs();
        }

        [Then(@"the Number of days in learning is calculated and set as a total number of days spent in learning")]
        public void ThenTheNumberOfDaysInLearningIsCalculatedAndSetAsATotalNumberOfDaysSpentInLearning()
        {
            var daysInLearning = helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id)
                .OrderBy(x => x.NumberOfDaysInLearning).ToList();

            daysInLearning.Count.Should().Be(2);
            var activePeriod = helper.CollectionCalendarHelper.GetActiveCollectionPeriod();
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
            var daysInLearning = helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id)
                .OrderBy(x => x.NumberOfDaysInLearning).ToList();

            daysInLearning.Count.Should().Be(1);
            var activePeriod = helper.CollectionCalendarHelper.GetActiveCollectionPeriod();
            var expectedNoOfDays = (_stoppedDate - _initialStartDate).TotalDays + 1;
            daysInLearning.First().NumberOfDaysInLearning.Should().Be((int)expectedNoOfDays);
            daysInLearning.First().CollectionPeriodNumber.Should().Be(activePeriod.PeriodNumber);
            daysInLearning.First().CollectionPeriodYear.ToString().Should().Be(activePeriod.AcademicYear);
        }

        [Then(@"the Number of days in learning is calculated and set as number of days from ILRStart Date to Census date of the Active Period")]
        public void ThenTheNumberOfDaysInLearningIsCalculatedAndSetAsNumberOfDaysFromIlrStartDateToCensusDateOfTheActivePeriod()
        {
            var daysInLearning = helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id).ToList();

            daysInLearning.Count.Should().Be(1);
            var activePeriod = helper.CollectionCalendarHelper.GetActiveCollectionPeriod();
            var expectedNoOfDays = (activePeriod.CensusDate - _initialStartDate).TotalDays + 1;
            daysInLearning.First().NumberOfDaysInLearning.Should().Be((int) expectedNoOfDays);
            daysInLearning.First().CollectionPeriodNumber.Should().Be(activePeriod.PeriodNumber);
            daysInLearning.First().CollectionPeriodYear.ToString().Should().Be(activePeriod.AcademicYear);
        }

        [Then(@"the Number of days in learning is re-calculated and set as number of days from ILRStart Date to Census date of the Active Period")]
        public void ThenTheNumberOfDaysInLearningIsRe_CalculatedAndSetAsNumberOfDaysFromILRStartDateToCensusDateOfTheActivePeriod()
        {
            var daysInLearning = helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id)
                .OrderBy(x => x.NumberOfDaysInLearning).ToList();

            daysInLearning.Count.Should().Be(2);
            var activePeriod = helper.CollectionCalendarHelper.GetActiveCollectionPeriod();
            var expectedNoOfDays = (activePeriod.CensusDate - _initialStartDate).TotalDays + 1;
            daysInLearning.Last().NumberOfDaysInLearning.Should().Be((int)expectedNoOfDays);
            daysInLearning.Last().CollectionPeriodNumber.Should().Be(activePeriod.PeriodNumber);
            daysInLearning.Last().CollectionPeriodYear.ToString().Should().Be(activePeriod.AcademicYear);
        }

    }
}
