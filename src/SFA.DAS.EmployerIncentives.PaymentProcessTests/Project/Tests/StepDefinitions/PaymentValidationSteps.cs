using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "PaymentValidation")]
    public class PaymentValidationSteps : StepsBase
    {
        private PendingPayment _pendingPayment;

        private readonly Helper _helper;

        protected PaymentValidationSteps(ScenarioContext context) : base(context)
        {
            testData.AccountId = 14326;
            testData.ApprenticeshipId = 133218;

            _helper = context.Get<Helper>();
        }

        [Given(@"an existing apprenticeship incentive")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            const byte period = 10;
            const short year = 2021;
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);

            var startDate = new DateTime(2021, 03, 03);

            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, 
                    testData.UKPRN, startDate, startDate.AddYears(-20)
                    ,Phase.Phase1)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(testData.ApprenticeshipId, 11)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
        }

        [When(@"the Payment Run occurs")]
        public async Task WhenThePaymentRunOccurs()
        {
            await _helper.LearnerMatchOrchestratorHelper.Run();
            await _helper.PaymentsOrchestratorHelper.Run();
            await _helper.CollectionCalendarHelper.Reset();
        }

        [Then(@"the (.*) Step in PendingPaymentValidationResult table for the (.*) is set to (.*)")]
        public void ThenHasPendingPaymentValidationStepSetToValue(string stepName, EarningType earningType, bool stepValue)
        {
            _pendingPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(x => x.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId 
                                                                  && x.EarningType == earningType);

            var validationStep = _helper.EISqlHelper.GetFromDatabase<PendingPaymentValidationResult>(x =>
                x.PendingPaymentId == _pendingPayment.Id
                && x.Step == stepName);
            
            validationStep.Should().NotBeNull();
            validationStep.Result.Should().Be(stepValue);
        }

        [Then(@"the payment record for the first earnings is created")]
        public void ThenThePaymentRecordForTheFirstEarningsIsCreated()
        {
            var payment = _helper.EISqlHelper.GetFromDatabase<Payment>(x => x.PendingPaymentId == _pendingPayment.Id);
            payment.Should().NotBeNull();
            payment.PaymentPeriod.Should().Be(10);
            payment.PaymentYear.Should().Be(2021);
        }
    }
}
