using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
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
        private const long AccountId = 14326;
        private const long ApprenticeshipId = 133217891;
        private readonly byte _periodNumber;
        private readonly short _academicYear;
        private readonly int _initialPaymentAmount;
        private PendingPayment _initialEarningFirstPayment;
        private PendingPayment _initialEarningSecondPayment;
        private Payment _firstPayment;
        private Payment _secondPayment;
        private DateTime _startDate;

        public WithdrawLearnerSteps(ScenarioContext context) : base(context)
        {
            _periodNumber = 11;
            _academicYear = 2021;
            _initialPaymentAmount = 1500;
        }

        [Given("an existing apprenticeship incentive")]
        public async Task AnExistingApprenticeshipIncentive()
        {
            await SetActiveCollectionPeriod(_periodNumber, _academicYear);

            _startDate = DateTime.Parse("2021-4-01");
            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(AccountId)
                .WithApprenticeship(ApprenticeshipId, ULN, UKPRN, _startDate, _startDate.AddYears(-24), Phase.Phase2)
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);
        }

        [Given("the first payment has been made")]
        public async Task TheFirstPaymentHasBeenMade()
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                 .WithStartDate(_startDate)
                 .WithEndDate("2022-10-15T00:00:00")
                 .WithPeriod(ApprenticeshipId, 7)
                 .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(_academicYear)
                .WithIlrSubmissionDate("2021-06-25T00:00:00")
                .WithIlrSubmissionWindowPeriod(_periodNumber)
                .WithStartDate(_startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionData);
            await TheLearnerMatchProcessIsRun();

            await ThePaymentProcessIsRun();

            _initialEarningFirstPayment = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarningFirstPayment.PaymentMadeDate.Should().NotBeNull();
            _initialEarningFirstPayment.DueDate.Should().Be(new DateTime(2021, 6, 29));

            _initialEarningSecondPayment = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.SecondPayment);
            _initialEarningSecondPayment.PaymentMadeDate.Should().BeNull();

            _firstPayment = GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningFirstPayment.Id);
            _firstPayment.Should().NotBeNull();
            _firstPayment.PaidDate.Should().NotBeNull();
            _firstPayment.PaidDate.Value.Date.Should().Be(DateTime.Today);
            _firstPayment.Amount.Should().Be(_initialPaymentAmount);

            var archivedPayments = GetAllFromDatabase<ArchivedPayment>();
            archivedPayments.Count.Should().Be(0);

            var pendingPaymentValidationResults = GetAllFromDatabase<PendingPaymentValidationResult>();
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningFirstPayment.Id).Should().Be(8);
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningSecondPayment.Id).Should().Be(0);

            var clawbackPayments = GetAllFromDatabase<ClawbackPayment>();
            clawbackPayments.Count.Should().Be(0);

            _secondPayment = GetSingleOrDefaultFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningSecondPayment.Id);
            _secondPayment.Should().BeNull();
        }

        [Given(@"a start date change of circumstance occurs which is eligible for the application phase and results in a different due period")]
        public async Task AStartDateChangeOfCircumstanceOccurs()
        {
            _startDate = DateTime.Parse("2021-5-02");

            var priceEpisode = new PriceEpisodeDtoBuilder()
                 .WithStartDate(_startDate)
                 .WithEndDate("2022-10-15T00:00:00")
                 .WithPeriod(ApprenticeshipId, 7)
                 .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(UKPRN)
                .WithUln(ULN)
                .WithAcademicYear(_academicYear)
                .WithIlrSubmissionDate("2021-07-25T00:00:00")
                .WithIlrSubmissionWindowPeriod(_periodNumber + 1)
                .WithStartDate(_startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await SetActiveCollectionPeriod((byte)(_periodNumber + 1), _academicYear);

            await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionData);            
        }

        [Given(@"the learner match process is run")]
        public async Task TheLearnerMatchProcessIsRun()
        {
            await RunLearnerMatchOrchestrator();
        }

        [Given(@"the payment process is run")]
        public async Task ThePaymentProcessIsRun()
        {
            await SetupBusinessCentralApiToAcceptAllPayments();
            await RunPaymentsOrchestrator();
            await RunApprovePaymentsOrchestrator();
        }

        [Given(@"the paid first earning, payment record and the validation records are retained")]
        public void ThePaidFirstEarningPaymentRecordAndValidationRecordsAreRetained()
        {
            var firstPendingPayment = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && p.ClawedBack == true);
            firstPendingPayment.Amount.Should().Be(_initialEarningFirstPayment.Amount);
            firstPendingPayment.PeriodNumber.Should().Be(_initialEarningFirstPayment.PeriodNumber);
            firstPendingPayment.PaymentYear.Should().Be(_initialEarningFirstPayment.PaymentYear);
            firstPendingPayment.PaymentMadeDate.Should().Be(DateTime.Today);

            var pendingPaymentValidationResults = GetAllFromDatabase<PendingPaymentValidationResult>();
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningFirstPayment.Id).Should().Be(8);
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningSecondPayment.Id).Should().Be(0);

            var firstPayment = GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningFirstPayment.Id);
            firstPayment.Should().BeEquivalentTo(_firstPayment);
        }

        [Given(@"the paid first earning is clawed back for the same amount")]
        public void ThePaidFirstEarningIsClawedBackFortheSameAmount()
        {
            var firstClawbackPayment = GetFromDatabase<ClawbackPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningFirstPayment.Id);
            firstClawbackPayment.PaymentId.Should().Be(_firstPayment.Id);
            firstClawbackPayment.Amount.Should().Be(_firstPayment.Amount * -1);
            firstClawbackPayment.PendingPaymentId.Should().Be(_initialEarningFirstPayment.Id);
            firstClawbackPayment.AccountId.Should().Be(AccountId);
            firstClawbackPayment.CollectionPeriod.Should().Be((byte)(_periodNumber + 1));
            firstClawbackPayment.CollectionPeriodYear.Should().Be(_academicYear);
        }

        [Given(@"the second unpaid earning is archived then deleted")]
        public void TheSecondUnpaidEarningIsArchivedandDeleted()
        {
            var secondPayment = GetSingleOrDefaultFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningSecondPayment.Id);
            secondPayment.Should().BeNull();

            var secondPaymentArchived = GetSingleOrDefaultFromDatabase<ArchivedPendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningSecondPayment.Id);
            secondPaymentArchived.Should().NotBeNull();
            secondPaymentArchived.Amount.Should().Be(_initialEarningSecondPayment.Amount);
            secondPaymentArchived.PeriodNumber.Should().Be(_initialEarningSecondPayment.PeriodNumber);
            secondPaymentArchived.PaymentYear.Should().Be(_initialEarningSecondPayment.PaymentYear);
            secondPaymentArchived.ClawedBack.Should().BeFalse();
        }

        [Given(@"new earnings are calculated")]
        public void TheNewEarningsAreCalculated()
        {
            var newfirstPendingPayment = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && !p.ClawedBack);
            newfirstPendingPayment.PeriodNumber = 12;
            newfirstPendingPayment.PaymentYear = 2021;
            newfirstPendingPayment.Amount = 1500;

            var newSecondPendingPayment = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.SecondPayment);
            newSecondPendingPayment.PeriodNumber = 9;
            newSecondPendingPayment.PaymentYear = 2122;
            newSecondPendingPayment.Amount = 1500;
        }

        [When(@"the Learner Withdraw Request is processed")]
        public async Task TheLearnerWithdrawRequestIsProcessed()
        {
            await functionsService.Withdraw(ULN, incentiveApplication.AccountLegalEntityId, WithdrawalType.Compliance);
            Thread.Sleep(5000); // The earnings don't get deleted straight away
        }

        [Then(@"the first earnings should have been removed")]
        public void TheFirstEarningsShouldHaveBeenRemoved()
        {
            var clawedBackFirstPendingPayment = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && p.ClawedBack);
            clawedBackFirstPendingPayment.PeriodNumber = _periodNumber;
            clawedBackFirstPendingPayment.PaymentYear = _academicYear;
            clawedBackFirstPendingPayment.AccountLegalEntityId = incentiveApplication.AccountLegalEntityId;
            clawedBackFirstPendingPayment.AccountId = incentiveApplication.AccountId;

            var firstPendingPayment = GetSingleOrDefaultFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && !p.ClawedBack);
            firstPendingPayment.Should().BeNull();
        }

        [Then(@"the second earnings should have been removed")]
        public void TheSecondEarningsShouldHaveBeenRemoved()
        {
            var secondPendingPayment = GetSingleOrDefaultFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && p.EarningType == EarningType.SecondPayment);
            secondPendingPayment.Should().BeNull();
        }
    }
}
