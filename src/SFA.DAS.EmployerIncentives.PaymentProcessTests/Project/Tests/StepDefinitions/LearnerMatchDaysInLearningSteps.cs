using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LearnerMatchDaysInLearningSteps : StepsBase
    {
        private readonly Helper _helper;
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private Learner _learner;

        protected LearnerMatchDaysInLearningSteps(ScenarioContext context) : base(context)
        {
            _helper = context.Get<Helper>();
            testData.AccountId = 14326;
        }

        [Given(@"an existing apprenticeship incentive")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            _initialStartDate = new DateTime(2021,5,5);
            _initialEndDate = DateTime.Today.AddMonths(12);

            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, 2021);

            var dateOfBirth = _initialStartDate.AddYears(-24);

            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, _initialStartDate, dateOfBirth, Phase.Phase1)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);
        }
        
        [When(@"the Learner Match occurs")]
        public async Task WhenTheLearnerMatchOccurs()
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(testData.ApprenticeshipId, 4)
                .Create();

            var learnerSubmissionDataR7 = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(4)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionDataR7);
            await _helper.LearnerMatchOrchestratorHelper.Run();

            _learner = _helper.EISqlHelper.GetFromDatabase<Learner>(x =>
                x.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId);
            _learner.Should().NotBeNull();
        }

        [Given(@"a successful Learner Match in previous collection period")]
        public async Task GivenASuccessfulLearnerMatchInPreviousCollectionPeriod()
        {
            await WhenTheLearnerMatchOccurs();
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(1, 2122);
        }

        [Then(@"Submission Found is set against the Learner")]
        public void ThenSubmissionFoundIsSetAgainstTheLearner()
        {
            _learner.SubmissionFound.Should().BeTrue();
        }
        
        [Then(@"Learning Found is set against the Learner")]
        public void ThenLearningFoundIsSetAgainstTheLearner()
        {
            _learner.LearningFound.Should().BeTrue();
        }

        [Then(@"In Learning is set against the Learner")]
        public void ThenInLearningIsSetAgainstTheLearner()
        {
            _learner.InLearning.Should().BeTrue();
        }

        [Then(@"the Number of days in learning is calculated and set as number of days from ILRStart Date to Census date of the Active Period")]
        public void ThenTheNumberOfDaysInLearningIsCalculatedAndSetAsNumberOfDaysFromIlrStartDateToCensusDateOfTheActivePeriod()
        {
            var daysInLearning = _helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id).ToList();

            daysInLearning.Count.Should().Be(1);
            var census = new DateTime(2021, 07, 31); // Period 12/2021
            var expectedNoOfDays = (census - _initialStartDate).TotalDays + 1;
            daysInLearning.First().NumberOfDaysInLearning.Should().Be((int) expectedNoOfDays);
            daysInLearning.First().CollectionPeriodNumber.Should().Be(12);
            daysInLearning.First().CollectionPeriodYear.Should().Be(2021);
        }

        [Then(@"the Number of days in learning is re-calculated and set as number of days from ILRStart Date to Census date of the Active Period")]
        public void ThenTheNumberOfDaysInLearningIsRe_CalculatedAndSetAsNumberOfDaysFromILRStartDateToCensusDateOfTheActivePeriod()
        {
            var daysInLearning = _helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Where(x => x.LearnerId == _learner.Id)
                .OrderBy(x => x.NumberOfDaysInLearning).ToList();

            daysInLearning.Count.Should().Be(2);
            var census = new DateTime(2021, 08, 31); // Period 1/2122
            var expectedNoOfDays = (census - _initialStartDate).TotalDays + 1;
            daysInLearning.Last().NumberOfDaysInLearning.Should().Be((int)expectedNoOfDays);
            daysInLearning.Last().CollectionPeriodNumber.Should().Be(1);
            daysInLearning.Last().CollectionPeriodYear.Should().Be(2122);
        }

    }
}
