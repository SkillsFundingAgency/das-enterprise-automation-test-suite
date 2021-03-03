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
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StartDateChangeOfCircumstanceSteps
    {
        // from JSON
        // ReSharper disable InconsistentNaming
        private const long ULN = 7229721937;
        private const long UKPRN = 10005310;
        private const long ApprenticeshipId = 133218;
        private readonly (byte Number, short Year, DateTime PayDay) _paymentPeriod = (7, 2021, new DateTime(2021, 2, 6));
        // ReSharper disable InconsistentNaming

        private readonly EIConfig _config;
        private readonly Fixture _fixture;
        private IncentiveApplication _incentiveApplication;
        private IncentiveApplicationApprenticeship _apprenticeship;
        private Guid _apprenticeshipIncentiveId;
        private DateTime _plannedStartDate;
        private DateTime _dateOfBirth;
        private PendingPayment _pendingPayment;
        private PendingPaymentValidationResult _pendingPaymentValidationResult;
        private EISqlHelper _sqlHelper;
        private Payment _payment;
        private List<PendingPayment> _newPendingPayments;
        private LearnerMatchApiHelper _learnerMatchApi;

        public StartDateChangeOfCircumstanceSteps(ScenarioContext context)
        {
            _fixture = new Fixture();
            _config = context.GetEIConfig<EIConfig>();
        }

        [Given(@"an existing apprenticeship incentive with learning starting on 6-Aug-2020")]
        public async Task GivenAnExistingApprenticeshipIncentive()
        {
            _sqlHelper = new EISqlHelper(_config);
            await _sqlHelper.CleanUpIncentives();
            await _sqlHelper.SetActiveCollectionPeriod(_paymentPeriod.Number, _paymentPeriod.Year);

            _plannedStartDate = new DateTime(2020, 11, 30);
            _dateOfBirth = _plannedStartDate.AddYears(-24).AddMonths(-10); // under 25 at the start of learning 

            _incentiveApplication = _fixture.Build<IncentiveApplication>()
                    .Without(x => x.Apprenticeships).Create();
            _apprenticeship = _fixture.Build<IncentiveApplicationApprenticeship>()
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

            await _sqlHelper.CreateIncentiveApplication(_incentiveApplication);

            var serviceBusHelper = new EIServiceBusHelper(_config);
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

            _apprenticeshipIncentiveId = await _sqlHelper.GetApprenticeshipIncentiveIdWhenExists(_apprenticeship.Id, new TimeSpan(0, 0, 1, 0));
            await _sqlHelper.WaitUntilEarningsExist(_apprenticeshipIncentiveId, new TimeSpan(0, 0, 1, 0));

            _learnerMatchApi = new LearnerMatchApiHelper(_config);
            Debug.Assert(_apprenticeship.UKPRN != null, "_apprenticeship.UKPRN != null");
            await _learnerMatchApi.SetupResponse(_apprenticeship.ULN, _apprenticeship.UKPRN.Value, LearnerMatchApiResponses.Clawbacks1_R07_json);
        }

        [Given(@"a payment of £1000 sent in Period R07 2021")]
        public async Task GivenAPaymentOf1000SentInPeriodR()
        {
            await using var dbConnection = new SqlConnection(_sqlHelper.ConnectionString);
            _pendingPayment = dbConnection.GetAll<PendingPayment>().Single(p => p.ApprenticeshipIncentiveId ==
                _apprenticeshipIncentiveId && p.EarningType == EarningType.FirstPayment);
            _pendingPayment.PaymentMadeDate = _paymentPeriod.PayDay;
            await dbConnection.UpdateAsync(_pendingPayment);
            _pendingPaymentValidationResult = _fixture.Build<PendingPaymentValidationResult>()
                .With(p => p.PendingPaymentId, _pendingPayment.Id)
                .With(p => p.PeriodNumber, _pendingPayment.PeriodNumber)
                .With(p => p.PaymentYear, _pendingPayment.PaymentYear)
                .With(p => p.Step, "HasBankDetails")
                .With(p => p.Result, true)
                .With(p => p.CreatedDateUtc, _pendingPayment.CalculatedDate.AddHours(1))
                .Create();
            await _sqlHelper.InsertAsync(_pendingPaymentValidationResult);

            _payment = _fixture.Build<Payment>()
                .With(p => p.AccountId, _incentiveApplication.AccountId)
                .With(p => p.AccountLegalEntityId, _incentiveApplication.AccountLegalEntityId)
                .With(p => p.ApprenticeshipIncentiveId, _apprenticeshipIncentiveId)
                .With(p => p.PaidDate, _paymentPeriod.PayDay)
                .With(p => p.PendingPaymentId, _pendingPayment.Id)
                .With(p => p.Amount, _pendingPayment.Amount)
                .With(p => p.PaymentYear, _pendingPayment.PaymentYear)
                .With(p => p.PaymentPeriod, _pendingPayment.PeriodNumber)
                .With(p => p.CalculatedDate, _pendingPayment.CalculatedDate.AddHours(1))
                .Create();
            await _sqlHelper.InsertAsync(_payment);
        }

        [Given(@"a start date change of circumstance occurs in Period R08")]
        public async Task GivenAStartDateChangeOfCircumstanceOccursInPeriodR08()
        {
            await _sqlHelper.SetActiveCollectionPeriod(8, 2021);
        }

        [Given(@"learner data is updated with a new learning start date 1-Feb-2021 making the learner over twenty five at the start of learning")]
        public async Task GivenLearnerDataIsUpdatedWithANewValidStartDateMakingTheLearnerOverTwentyFiveAtTheStartOfLearning()
        {
            await _learnerMatchApi.SetupResponse(ULN, UKPRN, LearnerMatchApiResponses.Clawbacks1_R08_json);
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
