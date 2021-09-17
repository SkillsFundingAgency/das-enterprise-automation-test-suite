using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
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
        private Phase _phase;
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;

        protected PaymentValidationSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an existing (.*) apprenticeship incentive submitted in Academic Year (.*)")]
        public async Task GivenAnExistingPhaseApprenticeshipIncentiveSubmittedInAcademicYear(string phase, short year)
        {
            _phase = Enum.Parse<Phase>(phase);
            if (_phase == Phase.Phase3)
            {
                await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(5, year);
                _initialStartDate = new DateTime(2021, 10, 1);
                _initialEndDate = new DateTime(2022, 12, 31);
            }
            else
            {
                _phase.Should().Be(Phase.Phase3);
            }
            
            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithDateSubmitted(_initialStartDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _initialStartDate,
                    _initialStartDate.AddYears(-24), _phase)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);

            const byte period = 5;
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(2122)
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(TestData.ApprenticeshipId, period)
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(year)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(-1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, submission);
        }

        [Given(@"an existing apprenticeship incentive")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            const byte period = 10;
            const short year = 2021;
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);

            var startDate = new DateTime(2021, 03, 03);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, 
                    TestData.UKPRN, startDate, startDate.AddYears(-20)
                    ,Phase.Phase1)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(startDate)
                .WithEndDate("2022-10-15T00:00:00")
                .WithPeriod(TestData.ApprenticeshipId, 11)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate("2020-11-12T09:11:46.82")
                .WithIlrSubmissionWindowPeriod(11)
                .WithStartDate(startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [When(@"the Payment Run occurs")]
        public async Task WhenThePaymentRunOccurs()
        {
            await Helper.LearnerMatchOrchestratorHelper.Run();
            await Helper.PaymentsOrchestratorHelper.Run();
            await Helper.CollectionCalendarHelper.Reset();
        }

        [Then(@"the (.*) Step in PendingPaymentValidationResult table for the (.*) is set to (.*)")]
        public void ThenHasPendingPaymentValidationStepSetToValue(string stepName, EarningType earningType, bool stepValue)
        {
            _pendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId 
                                                                  && x.EarningType == earningType);

            var validationStep = Helper.EISqlHelper.GetFromDatabase<PendingPaymentValidationResult>(x =>
                x.PendingPaymentId == _pendingPayment.Id
                && x.Step == stepName);
            
            validationStep.Should().NotBeNull();
            validationStep.Result.Should().Be(stepValue);
        }

        [Then(@"the payment record for the first earnings is created")]
        public void ThenThePaymentRecordForTheFirstEarningsIsCreated()
        {
            var payment = Helper.EISqlHelper.GetFromDatabase<Payment>(x => x.PendingPaymentId == _pendingPayment.Id);
            payment.Should().NotBeNull();
            payment.PaymentPeriod.Should().Be(10);
            payment.PaymentYear.Should().Be(2021);
        }
    }
}
