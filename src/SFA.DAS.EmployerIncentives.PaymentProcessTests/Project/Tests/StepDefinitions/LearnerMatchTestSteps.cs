using System;
using System.Threading.Tasks;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "LearnerMatchTest")]
    public class LearnerMatchTestSteps : StepsBase
    {
        private const long AccountId = 14326;
        private const long ApprenticeshipId = 133217890;

        public LearnerMatchTestSteps(ScenarioContext context) : base(context) { }

        [Given(@"there are some apprenticeship incentives")]
        public async Task GivenThereAreSomeApprenticeshipIncentives()
        {
            await SetActiveCollectionPeriod(10, 2021);

            var startDate = DateTime.Parse("2021-06-12");
            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(AccountId)
                .WithApprenticeship(ApprenticeshipId, ULN, UKPRN, startDate, startDate.AddYears(-24), context.ScenarioInfo.Title, Phase.Phase2)
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(ApprenticeshipId, 7)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(7)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionData);
        }

        [When(@"the learner match service is completed")]
        public async Task WhenTheLearnerMatchServiceIsCompleted()
        {
            await RunLearnerMatchOrchestrator();
        }

        [Then(@"we have some learner data")]
        public async Task ThenWeHaveSomeLearnerData()
        {
            await VerifyLearningRecordsExist();
        }
    }
}
