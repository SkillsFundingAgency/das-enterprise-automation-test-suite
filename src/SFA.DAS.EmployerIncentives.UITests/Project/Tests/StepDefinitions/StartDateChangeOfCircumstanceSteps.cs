using FluentAssertions;
using SFA.DAS.EmployerIncentives.UITests.Data;
using SFA.DAS.EmployerIncentives.UITests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StartDateChangeOfCircumstanceSteps : StepsBase
    {
        // from JSON
        private const long ULN = 7229721937;
        private const long UKPRN = 10005310;
        private const long AccountId = 14326;
        private const long AccountLegalEntityId = 123456;
        private const long ApprenticeshipId = 133218;
        private readonly DateTime _plannedStartDate = new DateTime(2020, 8, 6);

        private readonly (byte Number, short Year) _paymentPeriod = (6, 2021);


        private PendingPayment _initialEarning;
        private Payment _payment;
        private List<PendingPayment> _newPendingPayments;

        public StartDateChangeOfCircumstanceSteps(ScenarioContext context) : base(context) { }

        [Given(@"an existing apprenticeship incentive with learning starting on 6-Aug-2020")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            await SetActiveCollectionPeriod(_paymentPeriod.Number, _paymentPeriod.Year);

            var dateOfBirth = _plannedStartDate.AddYears(-24).AddMonths(-10); // under 25 at the start of learning 

            incentiveApplication = incentiveApplicationBuilder.Build()
                .WithAccountId(AccountId)
                .WithApprenticeship(ApprenticeshipId, ULN, UKPRN, _plannedStartDate, dateOfBirth)
                .Create();

            apprenticeshipIncentiveId = await SubmitIncentiveApplication(incentiveApplication);

            await SetupLearnerMatchApiResponse(ULN, UKPRN, LearnerMatchApiResponses.Clawbacks1_R07_json);
            await RunLearnerMatchOrchestrator();
        }

        [Given(@"a payment of £1000 sent in Period R07 2021")]
        public async Task GivenAPaymentOf1000SentInPeriodR072021()
        {
            await SetupBusinessCentralApiToAcceptAllPayments();
            await RunPaymentsOrchestrator(_paymentPeriod.Year, _paymentPeriod.Number);
            await RunApprovePaymentsOrchestrator();

            _initialEarning = GetFromDatabase<PendingPayment>(p => p.ApprenticeshipIncentiveId ==
                apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _initialEarning.PaymentMadeDate.Should().NotBeNull();

            _payment = GetFromDatabase<Payment>(p => p.ApprenticeshipIncentiveId ==
                apprenticeshipIncentiveId && p.PendingPaymentId == _initialEarning.Id);
            _payment.Should().NotBeNull();
            _payment.PaidDate.Should().NotBeNull();
        }

        [Given(@"a start date change of circumstance occurs in Period R09 2021")]
        public async Task GivenAStartDateChangeOfCircumstanceOccursInPeriodR09()
        {
            await SetActiveCollectionPeriod(9, _paymentPeriod.Year);
        }

        [Given(@"learner data is updated with a new learning start date 1-Feb-2021 making the learner over twenty five at the start of learning")]
        public async Task GivenLearnerDataIsUpdatedWithANewValidStartDateMakingTheLearnerOverTwentyFiveAtTheStartOfLearning()
        {
            await SetupLearnerMatchApiResponse(ULN, UKPRN, LearnerMatchApiResponses.Clawbacks1_R08_json);
        }

        [When(@"the incentive learner data is refreshed")]
        public async Task WhenTheIncentiveLearnerDataIsRefreshed()
        {
            await RunLearnerMatchOrchestrator();
        }

        [When(@"the earnings are recalculated")]
        public void WhenTheEarningsAreRecalculated()
        {
            _newPendingPayments = GetAllFromDatabase<PendingPayment>();
        }

        [Then(@"the paid earning of £1000 is marked as requiring a clawback in the currently active Period R09 2021")]
        public void ThenThePaidEarningOfIsMarkedAsRequiringAClawbackInTheCurrentlyActivePeriodR()
        {
            var pendingPayment = GetFromDatabase<PendingPayment>(p => p.Id == _initialEarning.Id);
            pendingPayment.PaymentMadeDate.Should().NotBeNull();
            pendingPayment.ClawedBack.Should().BeTrue();

            var clawback = GetFromDatabase<ClawbackPayment>(p => p.PendingPaymentId == _initialEarning.Id);
            clawback.Should().BeEquivalentTo(_payment, opt => opt.ExcludingMissingMembers()
                .Excluding(x => x.Id)
                .Excluding(x => x.Amount)
            );

            clawback.Amount.Should().Be(-1000);
            clawback.CollectionPeriodYear.Should().Be(2021);
            clawback.CollectionPeriod.Should().Be(9);
        }

        [Then(@"a new first pending payment of £750 is created for Period R09 2021")]
        public void ThenANewFirstPendingPaymentOfIsCreated()
        {
            var pp = _newPendingPayments.Single(x =>
                x.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                && x.EarningType == EarningType.FirstPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(9);
            pp.PaymentYear.Should().Be(2021);
        }

        [Then(@"a new second pending payment of £750 is created for Period R06 2122")]
        public async Task ThenANewSecondPendingPaymentOfIsCreated()
        {
            var pp = _newPendingPayments.Single(x =>
                 x.ApprenticeshipIncentiveId == apprenticeshipIncentiveId
                && x.EarningType == EarningType.SecondPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(6);
            pp.PaymentYear.Should().Be(2122);
        }

    }
}
