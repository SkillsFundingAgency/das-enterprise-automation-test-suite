using System;
using System.Threading.Tasks;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "PaymentsProcess")]
    public class PaymentsProcessSteps : StepsBase
    {
        private readonly Helper _helper;
        
        public PaymentsProcessSteps(ScenarioContext context) : base(context) 
        {
            testData.AccountId = 14326;
            testData.ApprenticeshipId = 133217891;

            _helper = context.Get<Helper>();
        }

        [Given(@"there is a valid learner")]
        public async Task GivenThereIsAValidLearner()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(2, 2122);

            var startDate = DateTime.Parse("2021-6-12");
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
            await _helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"the payment process is completed")]
        public async Task WhenThePaymentProcessIsCompleted()
        {
            await _helper.BusinessCentralApiHelper.AcceptAllPayments();
            await _helper.PaymentsOrchestratorHelper.Run();
            await _helper.PaymentsOrchestratorHelper.Approve();
        }

        [Then(@"payments exist")]
        public async Task ThenPaymentsExist()
        {
            await _helper.LearnerDataHelper.VerifyPaymentRecordsExist(testData.ApprenticeshipIncentiveId, paymentsSent: true);
        }
    }
}
