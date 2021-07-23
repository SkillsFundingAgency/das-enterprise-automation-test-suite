using System;
using System.Threading.Tasks;
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
        private readonly CollectionPeriodHelper _collectionPeriodHelper;
        private readonly LearnerMatchOrchestratorHelper _learnerMatchOrchestratorHelper;
        private readonly IncentiveApplicationHelper _incentiveApplicationHelper;

        public LearnerMatchTestSteps(ScenarioContext context) : base(context) 
        {
            testData.AccountId = 14326;
            testData.ApprenticeshipId = 133217890;

            _collectionPeriodHelper = context.Get<CollectionPeriodHelper>();
            _learnerMatchOrchestratorHelper = context.Get<LearnerMatchOrchestratorHelper>();
            _incentiveApplicationHelper = context.Get<IncentiveApplicationHelper>();
        }

        [Given(@"there are some apprenticeship incentives")]
        public async Task GivenThereAreSomeApprenticeshipIncentives()
        {
            await _collectionPeriodHelper.SetActiveCollectionPeriod(10, 2021);            

            var startDate = DateTime.Parse("2021-06-12");
            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, startDate, startDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _incentiveApplicationHelper.Submit(incentiveApplication);

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

            await SetupLearnerMatchApiResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the learner match service is completed")]
        public async Task WhenTheLearnerMatchServiceIsCompleted()
        {
            await _learnerMatchOrchestratorHelper.Run();
        }

        [Then(@"we have some learner data")]
        public async Task ThenWeHaveSomeLearnerData()
        {
            await VerifyLearningRecordsExist();
        }
    }
}
