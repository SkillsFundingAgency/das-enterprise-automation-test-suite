using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Net;
using System.Threading.Tasks;
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

            testData.StartDate = DateTime.Parse("2021-06-12");
            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, testData.StartDate, testData.StartDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(testData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(testData.StartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [Given(@"an incentive application has a learner match record in previous academic year")]
        public async Task GivenAnIncentiveApplicationHasALearnerMatchrecordInPreviousAcademicYear()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, 2021);

            testData.StartDate = DateTime.Parse("2021-05-02");
            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, testData.StartDate, testData.StartDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            testData.LearnerSubmission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-06-30T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(testData.StartDate)
                .WithPriceEpisode(
                    new PriceEpisodeDtoBuilder()
                    .WithStartDate(testData.StartDate)
                    .WithEndDate("2021-07-31T00:00:00")
                    .WithPeriod(testData.ApprenticeshipId, 11)
                    .Create()
                )
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, testData.LearnerSubmission);

            await _helper.LearnerMatchOrchestratorHelper.Run();

            await _helper.LearnerDataHelper.VerifyLearningRecordsExist(testData.ApprenticeshipId);

            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);
            var learningPeriod = _helper.EISqlHelper.GetFromDatabase<LearningPeriod>(l => l.LearnerId == learnerRecord.Id);

            var activePeriod = _helper.EISqlHelper.GetFromDatabase<CollectionCalendar>(l => l.Active);

            learnerRecord.SubmissionFound.Should().BeTrue();
            learnerRecord.LearningFound.Should().BeTrue();
            learnerRecord.InLearning.Should().BeTrue();

            var expectedDaysInLearning = activePeriod.CensusDate - testData.StartDate;
            var daysInLearning = learningPeriod.EndDate.Value - learningPeriod.StartDate;

            expectedDaysInLearning.Days.Should().Be(daysInLearning.Days);
        }

        [Given(@"learner match does not have a matching apprenticeship ID in a price episode in the current academic year")]
        public async Task GivenLearnerMatchDoesNotHaveAMatchingApprenticeshipIdInAPriceEpisodeInTheCurrentAcademicYear()
        {
            // data not changed
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);
        }

        [Given(@"learner match finds a matching apprenticeship ID in a price episode in the current academic year")]
        public async Task GivenLearnerMatchFindsAMatchingApprenticeshipIdInAPriceEpisodeInTheCurrentAcademicYear()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            testData.LearnerSubmission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2022)
                .WithIlrSubmissionDate("2021-08-30T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(testData.StartDate)
                .WithPriceEpisode(
                    new PriceEpisodeDtoBuilder()
                    .WithStartDate("2021-08-01T00:00:00")
                    .WithEndDate("2022-07-31T00:00:00")
                    .WithPeriod(testData.ApprenticeshipId, 1)
                    .Create()
                )
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, testData.LearnerSubmission);
        }

        [When(@"a learner match request in the current academic year does not find the requested ULN and UKPRN")]
        public async Task WhenTheLearnerMatchRequestInTheCurrentAcademivYearDoesNotHaveAMatchingRecord()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            await _helper.LearnerMatchApiHelper.SetupResponseHttpStatusCode(testData.ULN, testData.UKPRN, System.Net.HttpStatusCode.NotFound);

            await _helper.LearnerMatchOrchestratorHelper.Run();
        }

        [Given(@"learner match does not find a matching apprenticeship ID in a price episode in the current academic year")]
        public async Task GivenLearnerDoesNotFindAMatchingApprenticeshipIdInAPriceEpisodeInTheCurrentAcademicYear()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            testData.LearnerSubmission  = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2022)
                .WithIlrSubmissionDate("2021-08-01T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(testData.StartDate)
                .WithPriceEpisode(
                    new PriceEpisodeDtoBuilder()
                    .WithStartDate("2021-08-01T00:00:00")
                    .WithEndDate("2022-07-31T00:00:00")
                    .WithPeriod(testData.ApprenticeshipId + 1, 1) // not found ApprenticeshipId
                    .Create()
                )
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, testData.LearnerSubmission);
        }

        [Given(@"learner match has a matching apprenticeship ID in a price episode in the previous academic year")]
        public void GivenLearnerMatchHasAMatchingApprenticeshipIdInAPriceEpisodeInThePreviousAcademicYear()
        {
            // data not changed         
        }

        [When(@"the learner match process has run")]
        public async Task WhenTheLearnerMatchProcessHasRun()
        {
            await _helper.LearnerMatchOrchestratorHelper.Run();
        }

        [Given(@"learner match does not have a matching apprenticeship ID in a price episode in the previous academic year")]
        public void GivenLearnerMatchDoesNotHaveAMatchingApprenticeshipIdInAPriceEpisodeInThePreviousAcademicYear()
        {
            // data not changed         
        }

        [When(@"the learner match service is completed")]
        public async Task WhenTheLearnerMatchServiceIsCompleted()
        {
            await _helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"a learner match record is created for the apprenticeship id")]
        [Then(@"a learner match record is created for the apprenticeship id")]
        public async Task ThenWeHaveSomeLearnerData()
        {
            await _helper.LearnerDataHelper.VerifyLearningRecordsExist(testData.ApprenticeshipId);
        }


        [Given(@"an apprenticeship incentive for a learner")]
        public async Task GivenAnApprenticeshipIncentiveForALearner()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(10, 2021);

            testData.StartDate = DateTime.Parse("2021-06-12");
            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, testData.StartDate, testData.StartDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(testData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(testData.StartDate)
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

            testData.StartDate = DateTime.Parse("2021-06-12");
            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, testData.StartDate, testData.StartDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);
        }

        [When(@"the learner is found in learning in the current academic year")]
        public async Task WhenTheLearnerIsFoundInTheCurrentAY()
        {
            testData.StartDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(testData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(testData.StartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is found in learning in the previous academic year")]
        public async Task WhenTheLearnerIsFoundInThePreviousAY()
        {
            testData.StartDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(testData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(testData.StartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is found in learning in the previous and current academic year")]
        public async Task WhenTheLearnerIsFoundInThePreviousAndCurrentAY()
        {
            testData.StartDate = DateTime.Parse("2021-06-12");
            var priceEpisodePreviousAY = new PriceEpisodeDtoBuilder()
                .WithStartDate(testData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7)
                .Create();
            var priceEpisodeCurrentAY = new PriceEpisodeDtoBuilder()
                .WithStartDate(testData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 1)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(testData.StartDate)
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
            testData.StartDate = DateTime.Parse("2021-06-12");

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(testData.StartDate)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is found not in learning in the current academic year")]
        public async Task WhenTheLearnerIsFoundNotInLearningInTheCurrentAcademicYear()
        {
            testData.StartDate = DateTime.Parse("2021-06-12");

            var priceEpisodeFutureDate = new PriceEpisodeDtoBuilder()
                    .WithStartDate(testData.StartDate)
                    .WithEndDate(DateTime.Now.AddDays(1))
                    .WithPeriod(testData.ApprenticeshipId, 1)
                    .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(testData.StartDate)
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

        [When(@"the learner has a data lock for a price episode in the previous academic year")]
        public async Task WhenTheLearnerHasADataLockForAPriceEpisodeInThePreviousAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 2, payable: false)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(2)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner has no data lock for a price episode in the current academic year")]
        public async Task WhenTheLearnerHasNoDataLockForAPriceEpisodeInTheCurrentAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7, payable: false)
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

        [Then(@"learner data is updated to reflect that learning has been found")]
        public async Task ThenLearnerDataIsUpdatedToReflectThatLearningHasBeenFound()
        {
            await _helper.LearnerDataHelper.VerifyLearningRecordsExist(testData.ApprenticeshipId);

            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);

            learnerRecord.SubmissionFound.Should().BeTrue();            
            learnerRecord.LearningFound.Should().BeTrue();
            learnerRecord.InLearning.Should().BeTrue();
            learnerRecord.SubmissionDate.Should().Be(testData.LearnerSubmission.IlrSubmissionDate);
        }

        [When(@"the learner has no data lock for a price episode in the previous academic year")]
        public async Task WhenTheLearnerHasNoDataLockForAPriceEpisodeInThePreviousAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 7, payable: true)
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

        [When(@"the learner has a data lock for a price episode in the current academic year")]
        public async Task WhenTheLearnerHasADataLockForAPriceEpisodeInTheCurrentAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 2, payable: false)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(2)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner record has data lock set to true")]
        [Then(@"the learner record has data lock set to true")]
        public void ThenTheLearnerRecordHasDataLockSetToTrue()
        {
            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);
            learnerRecord.HasDataLock.Should().BeTrue();
        }

        [When(@"the learner record has data lock set to false")]
        [Then(@"the learner record has data lock set to false")]
        public void ThenTheLearnerRecordHasDataLockSetToFalse()
        {
            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);
            learnerRecord.HasDataLock.Should().BeFalse();
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

        [Then(@"learner data is updated to reflect that learning has not been found")]
        public async Task ThenLearnerDataIsUpdatedToReflectThatLearningHasNotBeenFound()
        {
            await _helper.LearnerDataHelper.VerifyLearningRecordsDoNotExist(testData.ApprenticeshipId);

            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);

            learnerRecord.SubmissionFound.Should().BeTrue();
            learnerRecord.LearningFound.Should().BeFalse();
            learnerRecord.HasDataLock.Should().BeNull();
            learnerRecord.InLearning.Should().BeNull();
            learnerRecord.SubmissionDate.Should().Be(testData.LearnerSubmission.IlrSubmissionDate);
        }

        [Given(@"learner match finds a matching apprenticeship ID in a price episode with no end date in the previous academic year")]
        public async Task GivenLearnerMatchFindsAMatchingApprenticeshipIDInAPriceEpisodeWithNoEndDateInThePreviousAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate(null)
                .WithPeriod(testData.ApprenticeshipId, 2, payable: true)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(2)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [Then(@"the learner data is updated with the price episode end date of the end of the previous academic year")]
        public async Task ThenTheLearnerDataIsUpdatedWithThePriceEpisodeEndDateOfTheEndOfThePreviousAcademicYear()
        {
            await _helper.LearnerDataHelper.VerifyLearningRecordsExist(testData.ApprenticeshipId);

            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);

            var learningPeriod = _helper.EISqlHelper.GetFromDatabase<LearningPeriod>(l => l.LearnerId == learnerRecord.Id);

            var expectedEndDate = new DateTime(2021, 07, 31);
            learningPeriod.EndDate.Should().Be(expectedEndDate);
        }
        
        [Given(@"learner match finds a matching apprenticeship ID in a price episode with no end date in the current academic year")]
        public async Task GivenLearnerMatchFindsAMatchingApprenticeshipIDInAPriceEpisodeWithNoEndDateInTheCurrentAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate(null)
                .WithPeriod(testData.ApprenticeshipId, 2, payable: true)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(2)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [Then(@"the learner data is updated with the price episode end date of the end of the current academic year")]
        public async Task ThenTheLearnerDataIsUpdatedWithThePriceEpisodeEndDateOfTheEndOfTheCurrentAcademicYear()
        {
            await _helper.LearnerDataHelper.VerifyLearningRecordsExist(testData.ApprenticeshipId);

            var learnerRecord = _helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == testData.ApprenticeshipId);

            var learningPeriod = _helper.EISqlHelper.GetFromDatabase<LearningPeriod>(l => l.LearnerId == learnerRecord.Id);

            var expectedEndDate = new DateTime(2022, 07, 31);
            learningPeriod.EndDate.Should().Be(expectedEndDate);
        }

    }
}
