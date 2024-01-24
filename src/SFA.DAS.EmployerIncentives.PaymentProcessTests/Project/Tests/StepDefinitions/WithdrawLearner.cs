using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "WithdrawLearner")]
    public class WithdrawLearnerSteps : StepsBase
    {
        private readonly int _initialPaymentAmount;
        private PendingPayment _initialEarningFirstPayment;
        private PendingPayment _initialEarningSecondPayment;
        private Payment _firstPayment;
        private Payment _secondPayment;
        private DateTime _startDate;

        public WithdrawLearnerSteps(ScenarioContext context) : base(context)
        {
            TestData.PeriodNumber = 11;
            TestData.AcademicYear = 2021;
            _initialPaymentAmount = 1500;
        }

        [Given("an existing apprenticeship incentive")]
        public async Task AnExistingApprenticeshipIncentive()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(TestData.PeriodNumber, TestData.AcademicYear);

            _startDate = DateTime.Parse("2021-4-01");
            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _startDate, _startDate.AddYears(-24), Context.ScenarioInfo.Title, Phase.Phase2)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [Given("the first payment has been made")]
        public async Task TheFirstPaymentHasBeenMade()
        {
            var priceEpisode = new PriceEpisodeDtoBuilder()
                 .WithAcademicYear(2021)
                 .WithStartDate(_startDate)
                 .WithEndDate("2022-10-15T00:00:00")
                 .WithPeriod(TestData.ApprenticeshipId, 7)
                 .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(TestData.AcademicYear)
                .WithIlrSubmissionDate("2021-06-25T00:00:00")
                .WithIlrSubmissionWindowPeriod(TestData.PeriodNumber)
                .WithStartDate(_startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
            await TheLearnerMatchProcessIsRun();

            await ThePaymentProcessIsRun();

            _initialEarningFirstPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarningFirstPayment.PaymentMadeDate.Should().NotBeNull();
            _initialEarningFirstPayment.DueDate.Should().Be(new DateTime(2021, 6, 29));

            _initialEarningSecondPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.SecondPayment);
            _initialEarningSecondPayment.PaymentMadeDate.Should().BeNull();

            _firstPayment = Helper.EISqlHelper.GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningFirstPayment.Id);
            _firstPayment.Should().NotBeNull();
            _firstPayment.PaidDate.Should().NotBeNull();
            _firstPayment.PaidDate.Value.Date.Should().Be(DateTime.Today);
            _firstPayment.Amount.Should().Be(_initialPaymentAmount);

            var archivedPayments = Helper.EISqlHelper.GetAllFromDatabase<ArchivedPayment>();
            archivedPayments.Count.Should().Be(0);

            var pendingPaymentValidationResults = Helper.EISqlHelper.GetAllFromDatabase<PendingPaymentValidationResult>();
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningFirstPayment.Id).Should().BeGreaterOrEqualTo(9);
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningSecondPayment.Id).Should().Be(0);

            var clawbackPayments = Helper.EISqlHelper.GetAllFromDatabase<ClawbackPayment>();
            clawbackPayments.Count.Should().Be(0);

            _secondPayment = Helper.EISqlHelper.GetSingleOrDefaultFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningSecondPayment.Id);
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
                 .WithPeriod(TestData.ApprenticeshipId, 7)
                 .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(TestData.AcademicYear)
                .WithIlrSubmissionDate("2021-07-25T00:00:00")
                .WithIlrSubmissionWindowPeriod(TestData.PeriodNumber + 1)
                .WithStartDate(_startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod((byte)(TestData.PeriodNumber + 1), TestData.AcademicYear);

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }

        [Given(@"the learner match process is run")]
        public async Task TheLearnerMatchProcessIsRun()
        {
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [Given(@"the payment process is run")]
        public async Task ThePaymentProcessIsRun()
        {
            await Helper.BusinessCentralApiHelper.AcceptAllPayments();
            await Helper.PaymentsOrchestratorHelper.Run();
            await Helper.PaymentsOrchestratorHelper.Approve();
        }

        [Given(@"the paid first earning, payment record and the validation records are retained")]
        public void ThePaidFirstEarningPaymentRecordAndValidationRecordsAreRetained()
        {
            var firstPendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && p.ClawedBack == true);
            firstPendingPayment.Amount.Should().Be(_initialEarningFirstPayment.Amount);
            firstPendingPayment.PeriodNumber.Should().Be(_initialEarningFirstPayment.PeriodNumber);
            firstPendingPayment.PaymentYear.Should().Be(_initialEarningFirstPayment.PaymentYear);
            firstPendingPayment.PaymentMadeDate.Should().Be(DateTime.Today);

            var pendingPaymentValidationResults = Helper.EISqlHelper.GetAllFromDatabase<PendingPaymentValidationResult>();
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningFirstPayment.Id).Should().BeGreaterOrEqualTo(9);
            pendingPaymentValidationResults.Count(v => v.PendingPaymentId == _initialEarningSecondPayment.Id).Should().Be(0);

            var firstPayment = Helper.EISqlHelper.GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningFirstPayment.Id);
            firstPayment.Should().BeEquivalentTo(_firstPayment);
        }

        [Given(@"the paid first earning is clawed back for the same amount")]
        public void ThePaidFirstEarningIsClawedBackFortheSameAmount()
        {
            var firstClawbackPayment = Helper.EISqlHelper.GetFromDatabase<ClawbackPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningFirstPayment.Id);
            firstClawbackPayment.PaymentId.Should().Be(_firstPayment.Id);
            firstClawbackPayment.Amount.Should().Be(_firstPayment.Amount * -1);
            firstClawbackPayment.PendingPaymentId.Should().Be(_initialEarningFirstPayment.Id);
            firstClawbackPayment.AccountId.Should().Be(TestData.Account.AccountId);
            firstClawbackPayment.CollectionPeriod.Should().Be((byte)(TestData.PeriodNumber + 1));
            firstClawbackPayment.CollectionPeriodYear.Should().Be(TestData.AcademicYear);
        }

        [Given(@"the second unpaid earning is archived then deleted")]
        public void TheSecondUnpaidEarningIsArchivedandDeleted()
        {
            var secondPayment = Helper.EISqlHelper.GetSingleOrDefaultFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningSecondPayment.Id);
            secondPayment.Should().BeNull();

            var secondPaymentArchived = Helper.EISqlHelper.GetSingleOrDefaultFromDatabase<ArchivedPendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.PendingPaymentId == _initialEarningSecondPayment.Id);
            secondPaymentArchived.Should().NotBeNull();
            secondPaymentArchived.Amount.Should().Be(_initialEarningSecondPayment.Amount);
            secondPaymentArchived.PeriodNumber.Should().Be(_initialEarningSecondPayment.PeriodNumber);
            secondPaymentArchived.PaymentYear.Should().Be(_initialEarningSecondPayment.PaymentYear);
            secondPaymentArchived.ClawedBack.Should().BeFalse();
        }

        [Given(@"new earnings are calculated")]
        public void TheNewEarningsAreCalculated()
        {
            var newfirstPendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && !p.ClawedBack);
            newfirstPendingPayment.PeriodNumber = 12;
            newfirstPendingPayment.PaymentYear = 2021;
            newfirstPendingPayment.Amount = 1500;

            var newSecondPendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.SecondPayment);
            newSecondPendingPayment.PeriodNumber = 9;
            newSecondPendingPayment.PaymentYear = 2122;
            newSecondPendingPayment.Amount = 1500;
        }

        [Given(@"an application has been withdrawn by compliance")]
        public async Task GivenAnApplicationHasBeenWithdrawnByCompliance()
        {
            await AnExistingApprenticeshipIncentive();
            await Withdraw(WithdrawalType.Compliance);
        }

        [Given(@"an application has been withdrawn by an employer")]
        public async Task GivenAnApplicationHasBeenWithdrawnByEmployer()
        {
            await AnExistingApprenticeshipIncentive();
            await Withdraw(WithdrawalType.Employer);
        }

        [When(@"the Learner Withdraw Request is processed")]
        public async Task TheLearnerWithdrawRequestIsProcessed()
        {
            await Withdraw(WithdrawalType.Compliance);
        }

        private async Task Withdraw(WithdrawalType withdrawalType)
        {
            await Helper.EIFunctionsHelper.Withdraw(TestData.ULN, TestData.IncentiveApplication.AccountLegalEntityId, withdrawalType);
            await Helper.EISqlHelper.WaitUntilIncentiveWithdrawn(TestData.ApprenticeshipIncentiveId, TimeSpan.FromSeconds(5));
        }

        [When(@"Reinstatement is requested")]
        public async Task WhenReinstatementIsRequested()
        {
            await Helper.EIFunctionsHelper.Reinstate(TestData.ULN, TestData.IncentiveApplication.AccountLegalEntityId);
        }

        [Then(@"the first earnings should have been removed")]
        public void TheFirstEarningsShouldHaveBeenRemoved()
        {
            var clawedBackFirstPendingPayment = Helper.EISqlHelper.GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && p.ClawedBack);
            clawedBackFirstPendingPayment.PeriodNumber = TestData.PeriodNumber;
            clawedBackFirstPendingPayment.PaymentYear = TestData.AcademicYear;
            clawedBackFirstPendingPayment.AccountLegalEntityId = TestData.IncentiveApplication.AccountLegalEntityId;
            clawedBackFirstPendingPayment.AccountId = TestData.IncentiveApplication.AccountId;

            var firstPendingPayment = Helper.EISqlHelper.GetSingleOrDefaultFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment && !p.ClawedBack);
            firstPendingPayment.Should().BeNull();
        }

        [Then(@"the second earnings should have been removed")]
        public void TheSecondEarningsShouldHaveBeenRemoved()
        {
            var secondPendingPayment = Helper.EISqlHelper.GetSingleOrDefaultFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && p.EarningType == EarningType.SecondPayment);
            secondPendingPayment.Should().BeNull();
        }

        [Then(@"the apprenticeship incentive status is set to Active")]
        public async Task ThenTheApprenticeshipIncentiveStatusIsSetToActive()
        {
            await Helper.EISqlHelper.WaitUntilEarningsExist(TestData.ApprenticeshipIncentiveId, TimeSpan.FromMinutes(1));
            var apprenticeshipIncentive = Helper.EISqlHelper.GetFromDatabase<ApprenticeshipIncentive>(ai => ai.Id == TestData.ApprenticeshipIncentiveId);
            apprenticeshipIncentive.Status.Should().Be(IncentiveStatus.Active);
        }

        [Then(@"WithdrawnByCompliance flag of the application apprenticeship is unset")]
        public void ThenTheWithdrawnByComplianceFlagIsUnset()
        {
            var incentiveApplicationApprenticeship = Helper.EISqlHelper.GetFromDatabase<IncentiveApplicationApprenticeship>(iaa => iaa.IncentiveApplicationId == TestData.IncentiveApplication.Id);
            incentiveApplicationApprenticeship.WithdrawnByCompliance.Should().BeFalse();
        }

        [Then(@"the earnings are recalculated")]
        public void ThenTheEarningsAreRecalculated()
        {
            var pendingPayments = Helper.EISqlHelper.GetAllFromDatabase<PendingPayment>().Where(pp => pp.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);
            pendingPayments.Should().HaveCount(2);
        }

        [Then(@"the application is not reinstated")]
        public void ThenTheApplicationIsNotReinstated()
        {
            var apprenticeshipIncentive = Helper.EISqlHelper.GetFromDatabase<ApprenticeshipIncentive>(ai => ai.Id == TestData.ApprenticeshipIncentiveId);
            apprenticeshipIncentive.Status.Should().Be(IncentiveStatus.Withdrawn);

            var incentiveApplicationApprenticeship = Helper.EISqlHelper.GetFromDatabase<IncentiveApplicationApprenticeship>(iaa => iaa.IncentiveApplicationId == TestData.IncentiveApplication.Id);
            incentiveApplicationApprenticeship.WithdrawnByEmployer.Should().BeTrue();
        }
    }
}
