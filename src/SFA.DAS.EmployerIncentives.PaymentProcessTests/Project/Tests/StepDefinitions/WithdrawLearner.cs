using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "WithdrawLearner")]
    public class WithdrawLearnerSteps : StepsBase
    {
        private readonly Helper _helper;

        private readonly int _initialPaymentAmount;
        private PendingPayment _initialEarningFirstPayment;
        private PendingPayment _initialEarningSecondPayment;
        private Payment _firstPayment;
        private Payment _secondPayment;
        private DateTime _startDate;

        public WithdrawLearnerSteps(ScenarioContext context) : base(context)
        {
            testData.AccountId = 14326;
            testData.ApprenticeshipId = 133217891;
            testData.PeriodNumber = 11;
            testData.AcademicYear = 2021;

            _helper = context.Get<Helper>();

            _initialPaymentAmount = 1500;
        }

        [Given("an existing apprenticeship incentive")]
        public async Task AnExistingApprenticeshipIncentive()
        {
            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod(testData.PeriodNumber, testData.AcademicYear);

            _startDate = DateTime.Parse("2021-4-01");
            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, _startDate, _startDate.AddYears(-24), Phase.Phase2)
                .Create();

            await _helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);
        }

        [Given("the first payment has been made")]
        public async Task TheFirstPaymentHasBeenMade()
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                 .WithAcademicYear(2021)
                 .WithStartDate(_startDate)
                 .WithEndDate("2022-10-15T00:00:00")
                 .WithPeriod(testData.ApprenticeshipId, 7)
                 .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(testData.AcademicYear)
                .WithIlrSubmissionDate("2021-06-25T00:00:00")
                .WithIlrSubmissionWindowPeriod(testData.PeriodNumber)
                .WithStartDate(_startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);
            await TheLearnerMatchProcessIsRun();

            await ThePaymentProcessIsRun();

            _initialEarningFirstPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarningFirstPayment.PaymentMadeDate.Should().NotBeNull();
            _initialEarningFirstPayment.DueDate.Should().Be(new DateTime(2021, 6, 29));

            _initialEarningSecondPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.EarningType == EarningType.SecondPayment);
            _initialEarningSecondPayment.PaymentMadeDate.Should().BeNull();

            _firstPayment = _helper.EISqlHelper.GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningFirstPayment.Id);
            _firstPayment.Should().NotBeNull();
            _firstPayment.PaidDate.Should().NotBeNull();
            _firstPayment.PaidDate.Value.Date.Should().Be(DateTime.Today);
            _firstPayment.Amount.Should().Be(_initialPaymentAmount);

            var archivedPayments = _helper.EISqlHelper.GetAllFromDatabase<ArchivedPayment>();
            archivedPayments.Count.Should().Be(0);

            var pendingPaymentValidationResults = _helper.EISqlHelper.GetAllFromDatabase<PendingPaymentValidationResult>();
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningFirstPayment.Id).Should().Be(8);
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningSecondPayment.Id).Should().Be(0);

            var clawbackPayments = _helper.EISqlHelper.GetAllFromDatabase<ClawbackPayment>();
            clawbackPayments.Count.Should().Be(0);

            _secondPayment = _helper.EISqlHelper.GetSingleOrDefaultFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningSecondPayment.Id);
            _secondPayment.Should().BeNull();
        }

        [Given(@"a start date change of circumstance occurs which is eligible for the application phase and results in a different due period")]
        public async Task AStartDateChangeOfCircumstanceOccurs()
        {
            _startDate = DateTime.Parse("2021-5-02");

            var priceEpisode = new PriceEpisodeDtoBuilder()
                 .WithAcademicYear(2021)
                 .WithStartDate(_startDate)
                 .WithEndDate("2022-10-15T00:00:00")
                 .WithPeriod(testData.ApprenticeshipId, 7)
                 .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(testData.AcademicYear)
                .WithIlrSubmissionDate("2021-07-25T00:00:00")
                .WithIlrSubmissionWindowPeriod(testData.PeriodNumber + 1)
                .WithStartDate(_startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await _helper.CollectionCalendarHelper.SetActiveCollectionPeriod((byte)(testData.PeriodNumber + 1), testData.AcademicYear);

            await _helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, learnerSubmissionData);            
        }

        [Given(@"the learner match process is run")]
        public async Task TheLearnerMatchProcessIsRun()
        {
            await _helper.LearnerMatchOrchestratorHelper.Run();
        }

        [Given(@"the payment process is run")]
        public async Task ThePaymentProcessIsRun()
        {
            await _helper.BusinessCentralApiHelper.AcceptAllPayments();
            await _helper.PaymentsOrchestratorHelper.Run();
            await _helper.PaymentsOrchestratorHelper.Approve();
        }

        [Given(@"the paid first earning, payment record and the validation records are retained")]
        public void ThePaidFirstEarningPaymentRecordAndValidationRecordsAreRetained()
        {
            var firstPendingPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && p.ClawedBack == true);
            firstPendingPayment.Amount.Should().Be(_initialEarningFirstPayment.Amount);
            firstPendingPayment.PeriodNumber.Should().Be(_initialEarningFirstPayment.PeriodNumber);
            firstPendingPayment.PaymentYear.Should().Be(_initialEarningFirstPayment.PaymentYear);
            firstPendingPayment.PaymentMadeDate.Should().Be(DateTime.Today);

            var pendingPaymentValidationResults = _helper.EISqlHelper.GetAllFromDatabase<PendingPaymentValidationResult>();
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningFirstPayment.Id).Should().Be(8);
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningSecondPayment.Id).Should().Be(0);

            var firstPayment = _helper.EISqlHelper.GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningFirstPayment.Id);
            firstPayment.Should().BeEquivalentTo(_firstPayment);
        }

        [Given(@"the paid first earning is clawed back for the same amount")]
        public void ThePaidFirstEarningIsClawedBackFortheSameAmount()
        {
            var firstClawbackPayment = _helper.EISqlHelper.GetFromDatabase<ClawbackPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningFirstPayment.Id);
            firstClawbackPayment.PaymentId.Should().Be(_firstPayment.Id);
            firstClawbackPayment.Amount.Should().Be(_firstPayment.Amount * -1);
            firstClawbackPayment.PendingPaymentId.Should().Be(_initialEarningFirstPayment.Id);
            firstClawbackPayment.AccountId.Should().Be(testData.AccountId);
            firstClawbackPayment.CollectionPeriod.Should().Be((byte)(testData.PeriodNumber + 1));
            firstClawbackPayment.CollectionPeriodYear.Should().Be(testData.AcademicYear);
        }

        [Given(@"the second unpaid earning is archived then deleted")]
        public void TheSecondUnpaidEarningIsArchivedandDeleted()
        {
            var secondPayment = _helper.EISqlHelper.GetSingleOrDefaultFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningSecondPayment.Id);
            secondPayment.Should().BeNull();

            var secondPaymentArchived = _helper.EISqlHelper.GetSingleOrDefaultFromDatabase<ArchivedPendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningSecondPayment.Id);
            secondPaymentArchived.Should().NotBeNull();
            secondPaymentArchived.Amount.Should().Be(_initialEarningSecondPayment.Amount);
            secondPaymentArchived.PeriodNumber.Should().Be(_initialEarningSecondPayment.PeriodNumber);
            secondPaymentArchived.PaymentYear.Should().Be(_initialEarningSecondPayment.PaymentYear);
            secondPaymentArchived.ClawedBack.Should().BeFalse();
        }

        [Given(@"new earnings are calculated")]
        public void TheNewEarningsAreCalculated()
        {
            var newfirstPendingPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && !p.ClawedBack);
            newfirstPendingPayment.PeriodNumber = 12;
            newfirstPendingPayment.PaymentYear = 2021;
            newfirstPendingPayment.Amount = 1500;

            var newSecondPendingPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.EarningType == EarningType.SecondPayment);
            newSecondPendingPayment.PeriodNumber = 9;
            newSecondPendingPayment.PaymentYear = 2122;
            newSecondPendingPayment.Amount = 1500;
        }

        [When(@"the Learner Withdraw Request is processed")]
        public async Task TheLearnerWithdrawRequestIsProcessed()
        {
            await _helper.EIFunctionsHelper.Withdraw(testData.ULN, testData.IncentiveApplication.AccountLegalEntityId, WithdrawalType.Compliance);
            Thread.Sleep(5000); // The earnings don't get deleted straight away
        }

        [Then(@"the first earnings should have been removed")]
        public void TheFirstEarningsShouldHaveBeenRemoved()
        {
            var clawedBackFirstPendingPayment = _helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && p.ClawedBack);
            clawedBackFirstPendingPayment.PeriodNumber = testData.PeriodNumber;
            clawedBackFirstPendingPayment.PaymentYear = testData.AcademicYear;
            clawedBackFirstPendingPayment.AccountLegalEntityId = testData.IncentiveApplication.AccountLegalEntityId;
            clawedBackFirstPendingPayment.AccountId = testData.IncentiveApplication.AccountId;

            var firstPendingPayment = _helper.EISqlHelper.GetSingleOrDefaultFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && !p.ClawedBack);
            firstPendingPayment.Should().BeNull();
        }

        [Then(@"the second earnings should have been removed")]
        public void TheSecondEarningsShouldHaveBeenRemoved()
        {
            var secondPendingPayment = _helper.EISqlHelper.GetSingleOrDefaultFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId && p.EarningType == EarningType.SecondPayment);
            secondPendingPayment.Should().BeNull();
        }
    }
}
