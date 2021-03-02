using AutoFixture;
using Dapper.Contrib.Extensions;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.UITests.Data;
using SFA.DAS.EmployerIncentives.UITests.Messages;
using SFA.DAS.EmployerIncentives.UITests.Models;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StartDateChangeOfCircumstanceSteps
    {
        private EIConfig _config;
        private Fixture _fixture;
        private IncentiveApplication _incentiveApplication;
        private IncentiveApplicationApprenticeship _apprenticeship;
        private Guid _apprenticeshipIncentiveId;
        private DateTime _plannedStartDate;
        private DateTime _newStartDate;
        private DateTime _dateOfBirth; // under 25
        //private readonly Account _accountModel;
        // private readonly ApprenticeshipIncentive _apprenticeshipIncentive;
        //  private readonly PendingPayment _pendingPayment;
        private readonly LearnerSubmissionDto _learnerMatchApiData;
        // private readonly PendingPaymentValidationResult _pendingPaymentValidationResult;
        // private Payment _payment;
        // private List<PendingPayment> _newPendingPayments;
        private readonly (byte Number, short Year) _paymentPeriod = (1, 2021);
        private long Uln = 7229721937;
        private long Ukprn = 10005310;
        private PendingPayment _pendingPayment;
        private PendingPaymentValidationResult _pendingPaymentValidationResult;
        private EISqlHelper _sqlHelper;
        private Payment _payment;
        private List<PendingPayment> _newPendingPayments;

        public StartDateChangeOfCircumstanceSteps(ScenarioContext context)
        {
            _fixture = new Fixture();
            _config = context.GetEIConfig<EIConfig>();
        }

        [Given(@"an existing apprenticeship incentive")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            _sqlHelper = new EISqlHelper(_config);
            await _sqlHelper.SetActiveCollectionPeriod(6, 2021);

            _plannedStartDate = new DateTime(2020, 8, 1);
            _dateOfBirth = _plannedStartDate.AddYears(-24).AddMonths(-10); // under 25 at the start of learning 
            _newStartDate = new DateTime(2020, 1, 1);

            _incentiveApplication = _fixture.Build<IncentiveApplication>()
                    .Without(x => x.Apprenticeships).Create();
            _apprenticeship = _fixture.Build<IncentiveApplicationApprenticeship>()
                .With(a => a.ULN, Uln)
                .With(a => a.UKPRN, Ukprn)
                .With(a => a.IncentiveApplicationId, _incentiveApplication.Id)
                .With(x => x.WithdrawnByCompliance, false)
                .With(x => x.WithdrawnByEmployer, false)
                .With(x => x.WithdrawnByEmployer, false)
                .With(x => x.PlannedStartDate, _plannedStartDate)
                .With(x => x.DateOfBirth, _dateOfBirth)
                .Create();
            _incentiveApplication.Apprenticeships.Add(_apprenticeship);

            await _sqlHelper.CreateIncentiveApplication(_incentiveApplication);

            var serviceBusHelper = new EIServiceBusHelper(_config);
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

            _apprenticeshipIncentiveId = await _sqlHelper.GetApprenticeshipIncentiveIdWhenExists(_apprenticeship.Id, new TimeSpan(0, 0, 1, 0));
            await _sqlHelper.WaitUntilEarningsExist(_apprenticeshipIncentiveId, new TimeSpan(0, 0, 1, 0));

        }

        [Given(@"a payment of £1000 sent in Period R07")]
        public async Task GivenAPaymentOf1000SentInPeriodR()
        {
            _pendingPayment = _fixture.Build<PendingPayment>()
                .With(p => p.AccountId, _incentiveApplication.AccountId)
                .With(p => p.AccountLegalEntityId, _incentiveApplication.AccountLegalEntityId)
                .With(p => p.ApprenticeshipIncentiveId, _apprenticeshipIncentiveId)
                .With(p => p.DueDate, _plannedStartDate.AddMonths(1))
                .With(p => p.PeriodNumber, _paymentPeriod.Number)
                .With(p => p.PaymentYear, _paymentPeriod.Year)
                .With(p => p.Amount, 1000)
                .With(p => p.ClawedBack, false)
                .With(p => p.EarningType, EarningType.FirstPayment)
                .With(p => p.PaymentMadeDate, _plannedStartDate.AddMonths(1))

                .Create();

            _pendingPaymentValidationResult = _fixture.Build<PendingPaymentValidationResult>()
                .With(p => p.PendingPaymentId, _pendingPayment.Id)
                .With(p => p.PeriodNumber, _paymentPeriod.Number)
                .With(p => p.PaymentYear, _paymentPeriod.Year)
                .With(p => p.Step, "HasBankDetails")
                .With(p => p.Result, true)
                .Create();

            _payment = _fixture.Build<Payment>()
                .With(p => p.AccountId, _incentiveApplication.AccountId)
                .With(p => p.AccountLegalEntityId, _incentiveApplication.AccountLegalEntityId)
                .With(p => p.ApprenticeshipIncentiveId, _apprenticeshipIncentiveId)
                .With(p => p.PaidDate, DateTime.Now.AddDays(-1))
                .With(p => p.PendingPaymentId, _pendingPayment.Id)
                .With(p => p.Amount, _pendingPayment.Amount)
                .With(p => p.PaymentYear, _pendingPayment.PaymentYear)
                .With(p => p.PaymentPeriod, _pendingPayment.PeriodNumber)
                .Create();

            await _sqlHelper.InsertAsync(_pendingPayment);
            await _sqlHelper.InsertAsync(_pendingPaymentValidationResult);
            await _sqlHelper.InsertAsync(_payment);
        }

        [Given(@"a start date change of circumstance occurs in Period R08")]
        public async Task GivenAStartDateChangeOfCircumstanceOccursInPeriodR08()
        {
            await _sqlHelper.SetActiveCollectionPeriod(8, 2021);
        }

        [Given(@"learner data is updated with a new valid start date making the learner over twenty five at the start of learning")]
        public async Task GivenLearnerDataIsUpdatedWithANewValidStartDateMakingTheLearnerOverTwentyFiveAtTheStartOfLearning()
        {
            var learnerMatchApi = new LearnerMatchApiHelper(_config);
            await learnerMatchApi.SetupResponse(_apprenticeship.ULN, _apprenticeship.UKPRN.Value, LearnerMatchApiResponses.Clawbacks1_R08_json);
        }

        [When(@"the incentive learner data is refreshed")]
        public async Task WhenTheIncentiveLearnerDataIsRefreshed()
        {
            var learnerMatchService = new EILearnerMatchHelper(_config);
            await learnerMatchService.StartLearnerMatchOrchestrator();
            await learnerMatchService.WaitUntilComplete(new TimeSpan(0, 1, 0));
        }

        [When(@"the earnings are recalculated")]
        public void WhenTheEarningsAreRecalculated()
        {
            using var dbConnection = new SqlConnection(_sqlHelper.ConnectionString);
            _newPendingPayments = dbConnection.GetAll<PendingPayment>().ToList();
        }

        [Then(@"the paid earning of £1000 is marked as requiring a clawback in the currently active Period R08")]
        public void ThenThePaidEarningOfIsMarkedAsRequiringAClawbackInTheCurrentlyActivePeriodR()
        {
            using var dbConnection = new SqlConnection(_sqlHelper.ConnectionString);

            var pendingPayment = dbConnection.GetAll<PendingPayment>().Single(p => p.Id == _pendingPayment.Id);
            pendingPayment.ClawedBack.Should().BeTrue();

            var clawback = dbConnection.GetAll<ClawbackPayment>().Single(p => p.PendingPaymentId == _pendingPayment.Id);
            clawback.Should().BeEquivalentTo(_payment, opt => opt.ExcludingMissingMembers()
                .Excluding(x => x.Id));
        }

        [Then(@"a new first pending payment of £750 is created")]
        public void ThenANewFirstPendingPaymentOfIsCreated()
        {
            var pp = _newPendingPayments.Single(x =>
                x.ApprenticeshipIncentiveId == _apprenticeshipIncentiveId
                && x.EarningType == EarningType.FirstPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(4);
            pp.PaymentYear.Should().Be(2021);
        }

        [Then(@"a new second pending payment of £750 is created")]
        public void ThenANewSecondPendingPaymentOfIsCreated()
        {
            var pp = _newPendingPayments.Single(x =>
                 x.ApprenticeshipIncentiveId == _apprenticeshipIncentiveId
                && x.EarningType == EarningType.SecondPayment
                && !x.ClawedBack);

            pp.Amount.Should().Be(750);
            pp.PaymentMadeDate.Should().BeNull();
            pp.PeriodNumber.Should().Be(1);
            pp.PaymentYear.Should().Be(2122);
        }
    }
}
