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
    [Scope(Feature = "RollOverAndYearEnd")]
    public class RollOverAndYearEndSteps : StepsBase
    {
        private readonly Helper _helper;

        public RollOverAndYearEndSteps(ScenarioContext context) : base(context) 
        {
            testData.AccountId = 14326;
            testData.ApprenticeshipId = 133217890;

            _helper = context.Get<Helper>();
        }

        [Given(@"an incentive application has a learner match record in previous academic year")]
        public async Task GivenAnIncentiveApplicationHasALearnerMatchrecordInPreviousAcademicYear()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, 2021);

            var startDate = DateTime.Parse("2021-05-05");
            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, startDate, startDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2021-07-31T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 12)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(12)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);

            await _helper.LearnerMatchOrchestratorHelper.Run();

            await _helper.LearnerDataHelper.VerifyLearningRecordsExist(testData.ApprenticeshipId);

            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);
            var learningPeriod = _helper.EISqlHelper.GetFromDatabase<LearningPeriod>(l => l.LearnerId == learnerRecord.Id);
            
            var activePeriod = _helper.EISqlHelper.GetFromDatabase<CollectionCalendar>(l => l.Active);

            learnerRecord.SubmissionFound.Should().BeTrue();
            learnerRecord.LearningFound.Should().BeTrue();
            learnerRecord.InLearning.Should().BeTrue();
           
            var expectedDaysInLearning = activePeriod.CensusDate - startDate;
            var daysInLearning = learningPeriod.EndDate.Value - learningPeriod.StartDate;

            expectedDaysInLearning.Days.Should().Be(daysInLearning.Days);
        }

        [When(@"a learner match request in the current academic year does not find the requested ULN and UKPRN")]
        public async Task WhenTheLearnerMatchRequestInTheCurrentAcademivYearDoesNotHaveAMatchingRecord()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            await _helper.LearnerMatchApiHelper.SetupResponseHttpStatusCode(testData.ULN, testData.UKPRN, System.Net.HttpStatusCode.NotFound);

            await _helper.LearnerMatchOrchestratorHelper.Run();
        }

        [Then(@"update the learner match record to reflect that no current data has been found")]
        public async Task ThenUpdateTheLearnerMatchToreflectThatNoCurrentDataHasBeenFound()
        {
            await _helper.LearnerDataHelper.VerifyLearningRecordsExist(testData.ApprenticeshipId);

            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);
            var learningPeriods = _helper.EISqlHelper.GetAllFromDatabase<LearningPeriod>();

            learnerRecord.SubmissionFound.Should().BeFalse();
            learnerRecord.SubmissionDate.Should().BeNull();
            learnerRecord.LearningFound.Should().BeFalse();
            learnerRecord.StartDate.Should().BeNull();
            learnerRecord.InLearning.Should().BeNull();
            learningPeriods.Count.Should().Be(0);
        }
    }
}
