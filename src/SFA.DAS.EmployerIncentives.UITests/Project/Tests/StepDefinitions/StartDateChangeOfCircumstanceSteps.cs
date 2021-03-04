using AutoFixture;
using Dapper.Contrib.Extensions;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.UITests.Data;
using SFA.DAS.EmployerIncentives.UITests.Messages;
using SFA.DAS.EmployerIncentives.UITests.Models;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
        private const long ApprenticeshipId = 133218;
        private readonly (byte Number, short Year) _paymentPeriod = (6, 2021);

        private IncentiveApplication _incentiveApplication;
        private IncentiveApplicationApprenticeship _apprenticeship;
        private Guid _apprenticeshipIncentiveId;
        private DateTime _plannedStartDate;
        private DateTime _dateOfBirth;
        private PendingPayment _pendingPayment;
        private Payment _payment;
        private List<PendingPayment> _newPendingPayments;

        public StartDateChangeOfCircumstanceSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an existing apprenticeship incentive with learning starting on 6-Aug-2020")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            await sqlHelper.CleanUpIncentives();
            await SetActiveCollectionPeriod(_paymentPeriod.Number, _paymentPeriod.Year);

            var accountLegalEntityId = fixture.Create<long>();
            await sqlHelper.CreateAccount(AccountId, accountLegalEntityId);

            _plannedStartDate = new DateTime(2020, 8, 6);
            _dateOfBirth = _plannedStartDate.AddYears(-24).AddMonths(-10); // under 25 at the start of learning 

            _incentiveApplication = fixture.Build<IncentiveApplication>()
                    .Without(x => x.Apprenticeships)
                    .With(x => x.AccountId, AccountId)
                    .With(x => x.AccountLegalEntityId, accountLegalEntityId)
                    .Create();
            _apprenticeship = fixture.Build<IncentiveApplicationApprenticeship>()
                .With(a => a.ULN, ULN)
                .With(a => a.UKPRN, UKPRN)
                .With(a => a.ApprenticeshipId, ApprenticeshipId)
                .With(a => a.IncentiveApplicationId, _incentiveApplication.Id)
                .With(x => x.WithdrawnByCompliance, false)
                .With(x => x.WithdrawnByEmployer, false)
                .With(x => x.WithdrawnByEmployer, false)
                .With(x => x.PlannedStartDate, _plannedStartDate)
                .With(x => x.DateOfBirth, _dateOfBirth)
                .Create();
            _incentiveApplication.Apprenticeships.Add(_apprenticeship);

            await sqlHelper.CreateIncentiveApplication(_incentiveApplication);

            var serviceBusHelper = new EIServiceBusHelper(config);
            Debug.Assert(_incentiveApplication.DateSubmitted != null, "_incentiveApplication.DateSubmitted != null");
            var command = new CreateIncentiveCommand(
                _incentiveApplication.AccountId,
                _incentiveApplication.AccountLegalEntityId,
                _apprenticeship.Id,
                _apprenticeship.ApprenticeshipId,
                _apprenticeship.FirstName,
                _apprenticeship.LastName,
                _apprenticeship.DateOfBirth,
                _apprenticeship.ULN,
                _apprenticeship.PlannedStartDate,
                _apprenticeship.ApprenticeshipEmployerTypeOnApproval,
                _apprenticeship.UKPRN,
                _incentiveApplication.DateSubmitted.Value,
                _incentiveApplication.SubmittedByEmail,
                _apprenticeship.CourseName
            );

            await serviceBusHelper.Publish(command);

            _apprenticeshipIncentiveId = await sqlHelper.GetApprenticeshipIncentiveIdWhenExists(_apprenticeship.Id, new TimeSpan(0, 0, 1, 0));
            await sqlHelper.WaitUntilEarningsExist(_apprenticeshipIncentiveId, new TimeSpan(0, 0, 1, 0));

            await learnerMatchApi.SetupResponse(ULN, UKPRN, LearnerMatchApiResponses.Clawbacks1_R07_json);
            await RunLearnerMatchOrchestrator();
        }

        [Given(@"a payment of £1000 sent in Period R07 2021")]
        public async Task GivenAPaymentOf1000SentInPeriodR()
        {
            await businessCentralApiHelper.SetupAcceptAllRequests();

            var paymentService = new EIPaymentsProcessHelper(config);
            await paymentService.StartPaymentProcessOrchestrator(_paymentPeriod.Year, _paymentPeriod.Number);
            await paymentService.WaitUntilWaitingForPaymentApproval();

            await paymentService.ApprovePayments();
            await paymentService.WaitUntilComplete();

            await using var dbConnection = new SqlConnection(sqlHelper.ConnectionString);
            _pendingPayment = dbConnection.GetAll<PendingPayment>().Single(p => p.ApprenticeshipIncentiveId ==
                _apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _pendingPayment.PaymentMadeDate.Should().NotBeNull();

            _payment = dbConnection.GetAll<Payment>().Single(p => p.ApprenticeshipIncentiveId ==
                _apprenticeshipIncentiveId && p.PendingPaymentId == _pendingPayment.Id);
            _payment.Should().NotBeNull();
        }

        [Given(@"a start date change of circumstance occurs in Period R08")]
        public async Task GivenAStartDateChangeOfCircumstanceOccursInPeriodR08()
        {
            await SetActiveCollectionPeriod(9, _paymentPeriod.Year);
        }

        [Given(@"learner data is updated with a new learning start date 1-Feb-2021 making the learner over twenty five at the start of learning")]
        public async Task GivenLearnerDataIsUpdatedWithANewValidStartDateMakingTheLearnerOverTwentyFiveAtTheStartOfLearning()
        {
            await learnerMatchApi.SetupResponse(ULN, UKPRN, LearnerMatchApiResponses.Clawbacks1_R08_json);
        }

        [When(@"the incentive learner data is refreshed")]
        public async Task WhenTheIncentiveLearnerDataIsRefreshed()
        {
            await RunLearnerMatchOrchestrator();
        }

        [When(@"the earnings are recalculated")]
        public void WhenTheEarningsAreRecalculated()
        {
            using var dbConnection = new SqlConnection(sqlHelper.ConnectionString);
            _newPendingPayments = dbConnection.GetAll<PendingPayment>().ToList();
        }

        [Then(@"the paid earning of £1000 is marked as requiring a clawback in the currently active Period R08")]
        public void ThenThePaidEarningOfIsMarkedAsRequiringAClawbackInTheCurrentlyActivePeriodR()
        {
            using var dbConnection = new SqlConnection(sqlHelper.ConnectionString);

            var pendingPayment = dbConnection.GetAll<PendingPayment>().Single(p => p.Id == _pendingPayment.Id);
            pendingPayment.PaymentMadeDate.Should().NotBeNull();
            pendingPayment.ClawedBack.Should().BeTrue();

            var clawback = dbConnection.GetAll<ClawbackPayment>().Single(p => p.PendingPaymentId == _pendingPayment.Id);
            clawback.Should().BeEquivalentTo(_payment, opt => opt.ExcludingMissingMembers()
                .Excluding(x => x.Id)
                .Excluding(x => x.Amount)
            );

            clawback.Amount.Should().Be(-1000);
        }

        [Then(@"a new first pending payment of £750 is created for Period R09 2021")]
        public void ThenANewFirstPendingPaymentOfIsCreated()
        {
            var pp = _newPendingPayments.Single(x =>
                x.ApprenticeshipIncentiveId == _apprenticeshipIncentiveId
                && x.EarningType == EarningType.FirstPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(9);
            pp.PaymentYear.Should().Be(2021);
        }

        [Then(@"a new second pending payment of £750 is created for Period R06 2122")]
        public void ThenANewSecondPendingPaymentOfIsCreated()
        {
            var pp = _newPendingPayments.Single(x =>
                 x.ApprenticeshipIncentiveId == _apprenticeshipIncentiveId
                && x.EarningType == EarningType.SecondPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(6);
            pp.PaymentYear.Should().Be(2122);
        }
    }
}
