using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "LearnerMatchTest")]
    public class LearnerMatchTestSteps : StepsBase
    {
        public LearnerMatchTestSteps(ScenarioContext context) : base(context) 
        {
        }

        [Given(@"there are some apprenticeship incentives")]
        public async Task GivenThereAreSomeApprenticeshipIncentives()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(10, 2021);

            TestData.StartDate = DateTime.Parse("2021-06-12");
            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
				.WithDateSubmitted(testData.StartDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, TestData.StartDate, TestData.StartDate.AddYears(-24), Phase.Phase2)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(TestData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [Given(@"an incentive application has a learner match record in previous academic year")]
        public async Task GivenAnIncentiveApplicationHasALearnerMatchrecordInPreviousAcademicYear()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, 2021);

            TestData.StartDate = DateTime.Parse("2021-05-02");
            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
				.WithDateSubmitted(testData.StartDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, TestData.StartDate, TestData.StartDate.AddYears(-24), Phase.Phase2)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);

            TestData.LearnerSubmission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-06-30T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(
                    new PriceEpisodeDtoBuilder()
                    .WithAcademicYear(2021)
                    .WithStartDate(TestData.StartDate)
                    .WithEndDate("2021-07-31T00:00:00")
                    .WithPeriod(TestData.ApprenticeshipId, 11)
                    .Create()
                )
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, TestData.LearnerSubmission);

            await Helper.LearnerMatchOrchestratorHelper.Run();

            await Helper.LearnerDataHelper.VerifyLearningRecordsExist(TestData.ApprenticeshipId);

            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);
            var learningPeriod = Helper.EISqlHelper.GetFromDatabase<LearningPeriod>(l => l.LearnerId == learnerRecord.Id);

            var activePeriod = Helper.EISqlHelper.GetFromDatabase<CollectionCalendar>(l => l.Active);

            learnerRecord.SubmissionFound.Should().BeTrue();
            learnerRecord.LearningFound.Should().BeTrue();
            learnerRecord.InLearning.Should().BeTrue();

            var expectedDaysInLearning = activePeriod.CensusDate - TestData.StartDate;
            var daysInLearning = learningPeriod.EndDate.Value - learningPeriod.StartDate;

            expectedDaysInLearning.Days.Should().Be(daysInLearning.Days);
        }

        [Given(@"the provider has not submitted an ILR in the current academic year")]
        public async Task GiventheProviderHasNotSubmittedAnIlrInTheCurrentAcademicYear()
        {
            // data not changed
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);
        }

        [Given(@"learner match finds a matching apprenticeship ID in a price episode in the current academic year")]
        public async Task GivenLearnerMatchFindsAMatchingApprenticeshipIdInAPriceEpisodeInTheCurrentAcademicYear()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            TestData.LearnerSubmission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-30T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(
                    new PriceEpisodeDtoBuilder()
                    .WithAcademicYear(2122)
                    .WithStartDate("2021-08-01T00:00:00")
                    .WithEndDate("2022-07-31T00:00:00")
                    .WithPeriod(TestData.ApprenticeshipId, 1)
                    .Create()
                )
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, TestData.LearnerSubmission);
        }

        [When(@"a learner match request in the current academic year does not find the requested ULN and UKPRN")]
        public async Task WhenTheLearnerMatchRequestInTheCurrentAcademicYearDoesNotHaveAMatchingRecord()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            await Helper.LearnerMatchApiHelper.SetupResponseHttpStatusCode(TestData.ULN, TestData.UKPRN, System.Net.HttpStatusCode.NotFound);

            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [Given(@"learner match does not find a matching apprenticeship ID in a price episode in the current academic year")]
        public async Task GivenLearnerDoesNotFindAMatchingApprenticeshipIdInAPriceEpisodeInTheCurrentAcademicYear()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            TestData.LearnerSubmission  = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2022)
                .WithIlrSubmissionDate("2021-08-01T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(
                    new PriceEpisodeDtoBuilder()
                    .WithAcademicYear(2022)
                    .WithStartDate("2021-08-01T00:00:00")
                    .WithEndDate("2022-07-31T00:00:00")
                    .WithPeriod(TestData.ApprenticeshipId + 1, 1) // not found ApprenticeshipId
                    .Create()
                )
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, TestData.LearnerSubmission);
        }

        [Given(@"learner match has a matching apprenticeship ID in a price episode in the previous academic year but not the current academic year")]
        public async Task GivenLearnerHasAMatchingApprenticeshipIdInAPriceEpisodeInThePreviousAcademicYearButNotTheCurrentAcademicYear()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            TestData.LearnerSubmission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-30T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(
                    new PriceEpisodeDtoBuilder()
                    .WithAcademicYear(2021)
                    .WithStartDate(TestData.StartDate)
                    .WithEndDate("2021-07-31T00:00:00")
                    .WithPeriod(TestData.ApprenticeshipId, 12)
                    .Create()
                )
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, TestData.LearnerSubmission);
        }

        [Given(@"learner match has a matching apprenticeship ID in a price episode in the previous academic year")]
        public void GivenLearnerMatchHasAMatchingApprenticeshipIdInAPriceEpisodeInThePreviousAcademicYear()
        {
            // data not changed         
        }

        [When(@"the learner match process has run")]
        public async Task WhenTheLearnerMatchProcessHasRun()
        {
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [Given(@"learner match does not have a matching apprenticeship ID in a price episode in the previous academic year")]
        public void GivenLearnerMatchDoesNotHaveAMatchingApprenticeshipIdInAPriceEpisodeInThePreviousAcademicYear()
        {
            // data not changed         
        }

        [When(@"the learner match service is completed")]
        public async Task WhenTheLearnerMatchServiceIsCompleted()
        {
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"a learner match record is created for the apprenticeship id")]
        [Then(@"a learner match record is created for the apprenticeship id")]
        public async Task ThenWeHaveSomeLearnerData()
        {
            await Helper.LearnerDataHelper.VerifyLearningRecordsExist(TestData.ApprenticeshipId);
        }


        [Given(@"an apprenticeship incentive for a learner")]
        public async Task GivenAnApprenticeshipIncentiveForALearner()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(10, 2021);

            TestData.StartDate = DateTime.Parse("2021-06-12");
            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
				.WithDateSubmitted(testData.StartDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, TestData.StartDate, TestData.StartDate.AddYears(-24), Phase.Phase2)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(TestData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is not found")]
        public async Task WhenTheLearnerIsNotFound()
        {
            await Helper.LearnerMatchApiHelper.SetupResponseHttpStatusCode(TestData.ULN, TestData.UKPRN, HttpStatusCode.NotFound);
        }
        
        [Then(@"a learner match record is not created for the apprenticeship id")]
        public async Task ThenALearnerMatchRecordIsNotCreated()
        {
            await Helper.LearnerDataHelper.VerifyLearningRecordsDoNotExist(TestData.ApprenticeshipId);
        }

        [Given(@"an apprenticeship incentive for a learner submitted in the previous academic year")]
        public async Task GivenAnApprenticeshipIncentiveForALearnerSubmittedInThePreviousAY()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(01, 2122);

            TestData.StartDate = DateTime.Parse("2021-06-12");
            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
				.WithDateSubmitted(testData.StartDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, TestData.StartDate, TestData.StartDate.AddYears(-24), Phase.Phase2)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [When(@"the learner is found in learning in the current academic year")]
        public async Task WhenTheLearnerIsFoundInTheCurrentAY()
        {
            TestData.StartDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(TestData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is found in learning in the previous academic year")]
        public async Task WhenTheLearnerIsFoundInThePreviousAY()
        {
            TestData.StartDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(TestData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is found in learning in the previous and current academic year")]
        public async Task WhenTheLearnerIsFoundInThePreviousAndCurrentAY()
        {
            TestData.StartDate = DateTime.Parse("2021-06-12");
            var priceEpisodePreviousAY = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(TestData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 7)
                .Create();
            var priceEpisodeCurrentAY = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(TestData.StartDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 1)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(priceEpisodePreviousAY)
                .WithPriceEpisode(priceEpisodeCurrentAY)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [Then(@"the learner record has in learning set to true")]
        public void ThenTheLearnerRecordHasInLearningSetToTrue()
        {
            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);
            learnerRecord.InLearning.Should().BeTrue();
        }

        [When(@"the learner is found not in learning in the previous academic year")]
        public async Task WhenTheLearnerIsFoundNotInLearningInThePreviousAcademicYear()
        {
            TestData.StartDate = DateTime.Parse("2021-06-12");

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithAcademicYear(2021)
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(TestData.StartDate)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner is found not in learning in the current academic year")]
        public async Task WhenTheLearnerIsFoundNotInLearningInTheCurrentAcademicYear()
        {
            TestData.StartDate = DateTime.Parse("2021-06-12");

            var priceEpisodeFutureDate = new PriceEpisodeDtoBuilder()
                    .WithAcademicYear(2021)
                    .WithStartDate(TestData.StartDate)
                    .WithEndDate(DateTime.Now.AddDays(1))
                    .WithPeriod(TestData.ApprenticeshipId, 1)
                    .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-07-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(TestData.StartDate)
                .WithPriceEpisode(priceEpisodeFutureDate)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [Then(@"the learner record has in learning set to false")]
        public void ThenTheLearnerRecordHasInLearningSetToFalse()
        {
            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);
            learnerRecord.InLearning.Should().BeFalse();
        }

        [When(@"the learner has a data lock for a price episode in the previous academic year")]
        public async Task WhenTheLearnerHasADataLockForAPriceEpisodeInThePreviousAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 2, payable: false)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(2)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner has no data lock for a price episode in the current academic year")]
        public async Task WhenTheLearnerHasNoDataLockForAPriceEpisodeInTheCurrentAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 7, payable: false)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [Then(@"learner data is updated to reflect that learning has been found")]
        public async Task ThenLearnerDataIsUpdatedToReflectThatLearningHasBeenFound()
        {
            await Helper.LearnerDataHelper.VerifyLearningRecordsExist(TestData.ApprenticeshipId);

            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);

            learnerRecord.SubmissionFound.Should().BeTrue();            
            learnerRecord.LearningFound.Should().BeTrue();
            learnerRecord.InLearning.Should().BeTrue();
            learnerRecord.SubmissionDate.Should().Be(TestData.LearnerSubmission.IlrSubmissionDate);
        }

        [When(@"the learner has no data lock for a price episode in the previous academic year")]
        public async Task WhenTheLearnerHasNoDataLockForAPriceEpisodeInThePreviousAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 7, payable: true)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner has a data lock for a price episode in the current academic year")]
        public async Task WhenTheLearnerHasADataLockForAPriceEpisodeInTheCurrentAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2021)
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 2, payable: false)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(2)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner record has data lock set to true")]
        [Then(@"the learner record has data lock set to true")]
        public void ThenTheLearnerRecordHasDataLockSetToTrue()
        {
            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);
            learnerRecord.HasDataLock.Should().BeTrue();
        }

        [When(@"the learner record has data lock set to false")]
        [Then(@"the learner record has data lock set to false")]
        public void ThenTheLearnerRecordHasDataLockSetToFalse()
        {
            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);
            learnerRecord.HasDataLock.Should().BeFalse();
        }

        [Then(@"update the learner match record to reflect that no current data has been found")]
        public async Task ThenUpdateTheLearnerMatchToReflectThatNoCurrentDataHasBeenFound()
        {
            await Helper.LearnerDataHelper.VerifyLearningRecordsDoNotExist(TestData.ApprenticeshipId);

            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);
            var learningPeriods = Helper.EISqlHelper.GetAllFromDatabase<LearningPeriod>();

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
            await Helper.LearnerDataHelper.VerifyLearningRecordsDoNotExist(TestData.ApprenticeshipId);

            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);

            learnerRecord.SubmissionFound.Should().BeTrue();
            learnerRecord.LearningFound.Should().BeFalse();
            learnerRecord.HasDataLock.Should().BeNull();
            learnerRecord.InLearning.Should().BeNull();
            learnerRecord.SubmissionDate.Should().Be(TestData.LearnerSubmission.IlrSubmissionDate);
        }

        [Then(@"the learning is stopped")]
        public void ThenLearningisStopped()
        {
            var changeOfCircumstance = Helper.EISqlHelper.GetAllFromDatabase<ChangeOfCircumstance>().Single();

            changeOfCircumstance.ApprenticeshipIncentiveId.Should().Be(TestData.ApprenticeshipIncentiveId);
            changeOfCircumstance.ChangeType.Should().Be(ChangeOfCircumstanceType.LearningStopped);
            changeOfCircumstance.NewValue.Should().Be("2021-08-01");
        }

        [Given(@"learner match finds a matching apprenticeship ID in a price episode with no end date in the previous academic year")]
        public async Task GivenLearnerMatchFindsAMatchingApprenticeshipIDInAPriceEpisodeWithNoEndDateInThePreviousAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithAcademicYear(2021)
                .WithEndDate(null)
                .WithPeriod(TestData.ApprenticeshipId, 2, payable: true)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(2)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [Then(@"the learner data is updated with the price episode end date of the end of the previous academic year")]
        public async Task ThenTheLearnerDataIsUpdatedWithThePriceEpisodeEndDateOfTheEndOfThePreviousAcademicYear()
        {
            await Helper.LearnerDataHelper.VerifyLearningRecordsExist(TestData.ApprenticeshipId);

            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);

            var learningPeriod = Helper.EISqlHelper.GetFromDatabase<LearningPeriod>(l => l.LearnerId == learnerRecord.Id);

            var expectedEndDate = new DateTime(2021, 07, 31);
            learningPeriod.EndDate.Should().Be(expectedEndDate);
        }

        [Given(@"learner match finds a matching apprenticeship ID in a price episode with no end date in the current academic year")]
        public async Task GivenLearnerMatchFindsAMatchingApprenticeshipIDInAPriceEpisodeWithNoEndDateInTheCurrentAcademicYear()
        {
            var startDate = DateTime.Parse("2021-06-12");
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithAcademicYear(2122)
                .WithEndDate(null)
                .WithPeriod(TestData.ApprenticeshipId, 2, payable: true)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2122)
                .WithIlrSubmissionDate("2021-08-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(2)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [Then(@"the learner data is updated with the price episode end date of the end of the current academic year")]
        public async Task ThenTheLearnerDataIsUpdatedWithThePriceEpisodeEndDateOfTheEndOfTheCurrentAcademicYear()
        {
            await Helper.LearnerDataHelper.VerifyLearningRecordsExist(TestData.ApprenticeshipId);

            var learnerRecord = Helper.EISqlHelper.GetFromDatabase<Learner>(l => l.ApprenticeshipId == TestData.ApprenticeshipId);

            var learningPeriod = Helper.EISqlHelper.GetFromDatabase<LearningPeriod>(l => l.LearnerId == learnerRecord.Id);

            var expectedEndDate = new DateTime(2022, 07, 31);
            learningPeriod.EndDate.Should().Be(expectedEndDate);
        }
    }
}
