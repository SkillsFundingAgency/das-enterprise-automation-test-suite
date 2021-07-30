using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "LearnerMatchTest")]
    public class LearnerMatchTestSteps : StepsBase
    {
        private readonly Helper _helper;

        public LearnerMatchTestSteps(ScenarioContext context) : base(context) 
        {
            testData.AccountId = 14326;
            testData.ApprenticeshipId = 133217890;

            _helper = context.Get<Helper>();
        }

        [Given(@"there are some apprenticeship incentives")]
        public async Task GivenThereAreSomeApprenticeshipIncentives()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(10, 2021);

            var startDate = DateTime.Parse("2021-06-12");
            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, startDate, startDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
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
                .WithPeriod(testData.ApprenticeshipId, 11)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-06-30T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
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
            learnerRecord.InLearning.Should().BeFalse();

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

        [When(@"the learner match service is completed")]
        public async Task WhenTheLearnerMatchServiceIsCompleted()
        {
            await _helper.LearnerMatchOrchestratorHelper.Run();
        }

        [Then(@"a learner match record is created for the apprenticeship id")]
        public async Task ThenWeHaveSomeLearnerData()
        {
            await _helper.LearnerDataHelper.VerifyLearningRecordsExist(testData.ApprenticeshipId);
        }


        [Given(@"an apprenticeship incentive for a learner")]
        public async Task GivenAnApprenticeshipIncentiveForALearner()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(10, 2021);

            var startDate = DateTime.Parse("2021-06-12");
            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, startDate, startDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is not found")]
        public async Task WhenTheLearnerIsNotFound()
        {
            await _helper.LearnerMatchApiHelper.SetupResponseHttpStatusCode(testData.ULN, testData.UKPRN, HttpStatusCode.NotFound);
        }

        [Then(@"a learner match record is not created for the apprenticeship id")]
        public async Task ThenALearnerMatchRecordIsNotCreated()
        {
            await _helper.LearnerDataHelper.VerifyLearningRecordsDoNotExist(testData.ApprenticeshipId);
        }

        [Given(@"an apprenticeship incentive for a learner submitted in the previous academic year")]
        public async Task GivenAnApprenticeshipIncentiveForALearnerSubmittedInThePreviousAY()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            var startDate = DateTime.Parse("2021-06-12");
            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, startDate, startDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);
        }

        [When(@"the learner is found in learning in the current academic year")]
        public async Task WhenTheLearnerIsFoundInTheCurrentAY()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is found in learning in the previous academic year")]
        public async Task WhenTheLearnerIsFoundInThePreviousAY()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is found in learning in the previous and current academic year")]
        public async Task WhenTheLearnerIsFoundInThePreviousAndCurrentAY()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisodePreviousAY = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();
            var priceEpisodeCurrentAY = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 1)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisodePreviousAY)
                .WithPriceEpisode(priceEpisodeCurrentAY)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [Then(@"the learner record has in learning set to true")]
        public async Task ThenTheLearnerRecordHasInLearningSetToTrue()
        {
            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);
            learnerRecord.InLearning.Should().BeTrue();
        }

        [When(@"the learner is found not in learning in the previous academic year")]
        public async Task WhenTheLearnerIsFoundNotInLearningInThePreviousAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(startDate)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is found not in learning in the current academic year")]
        public async Task WhenTheLearnerIsFoundNotInLearningInTheCurrentAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");

            var priceEpisodeFutureDate = new PriceEpisodeDtoBuilder()
                    .WithStartDate(startDate)
                    .WithEndDate(DateTime.Now.AddDays(1))
                    .WithPeriod(testData.ApprenticeshipId, 1)
                    .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisodeFutureDate)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [Then(@"the learner record has in learning set to false")]
        public async Task ThenTheLearnerRecordHasInLearningSetToFalse()
        {
            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);
            learnerRecord.InLearning.Should().BeFalse();
        }

        [Then(@"update the learner match record to reflect that no current data has been found")]
        public async Task ThenUpdateTheLearnerMatchToReflectThatNoCurrentDataHasBeenFound()
        {
            await _helper.LearnerDataHelper.VerifyLearningRecordsDoNotExist(testData.ApprenticeshipId);

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
