using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "EmploymentCheck")]
    public class EmploymentCheckSteps : StepsBase
    {
        private DateTime _startDate;
        private string _employmentCheckResult = "employed";
        private IEnumerable<Models.EmploymentCheck> _employmentChecks;
        private bool _expectedEmployedAtStartOfApprenticeshipValidationResult;
        private bool _expectedEmployedBeforeSchemeStartedValidationResult;

        protected EmploymentCheckSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an apprenticeship incentive has been submitted in phase 1")]
        public async Task GivenAnExistingPhase1ApprenticeshipIncentive()
        {
            await CreateIncentive(Phase.Phase1, new DateTime(2020, 11, 30));
        }

        [Given(@"an apprenticeship incentive has been submitted in phase 2")]
        public async Task GivenAnExistingPhase2ApprenticeshipIncentive()
        {
            await CreateIncentive(Phase.Phase2, new DateTime(2021, 04, 30));
        }

        [Given(@"an apprenticeship incentive has been submitted in phase 3")]
        public async Task GivenAnExistingPhase3ApprenticeshipIncentive()
        {
            await CreateIncentive(Phase.Phase3, new DateTime(2021, 10, 30));
        }

        [Given(@"an apprenticeship incentive has been submitted less than 6 weeks ago")]
        public async Task GivenAnIncentiveSubmittedLessThan6WeeksAgo()
        {
            await CreateIncentive(Phase.Phase3, new DateTime(2022, 3, 31));
        }

        [Given(@"an employment check has been requested")]
        public async Task GivenAnEmploymentCheckHasBeenRequested()
        {
            await CreateIncentive(Phase.Phase2, new DateTime(2021, 04, 30));
            await WhenAnIlrSubmissionIsReceived();
            await WhenTheLearnerMatchIsRun();
            await Helper.EISqlHelper.WaitUntilCorrelationIdsSet(TestData.ApprenticeshipIncentiveId, TimeSpan.FromMinutes(1));
            _employmentChecks = Helper.EISqlHelper.GetAllFromDatabase<Models.EmploymentCheck>().Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);
        }

        [Given(@"the employment check request has not been superseded")]
        public void GivenTheEmploymentCheckHasNotBeenSuperseded()
        {
        }

        [Given(@"we have not previously received a result from the Employment Check service")]
        public void GivenWeHaveNotPreviouslyReceivedAResult()
        {
        }

        [Given(@"the employment check has been superseded")]
        public async Task GivenTheEmploymentCheckHasBeenSuperseded()
        {
            _startDate = _startDate.AddDays(10);
            await SetupSubmission();
            await WhenTheLearnerMatchIsRun();
            await Helper.EISqlHelper.WaitUntilCorrelationIdsSet(TestData.ApprenticeshipIncentiveId, TimeSpan.FromMinutes(1));
        }

        [Given(@"the employment check has not returned a result")]
        public void GivenTheEmploymentCheckHasNotReturnedAResult()
        {
            _expectedEmployedAtStartOfApprenticeshipValidationResult = false;
            _expectedEmployedBeforeSchemeStartedValidationResult = false;
        }

        [Given(@"a payment is due for the apprenticeship")]
        public void GivenAPaymentIsDueForTheApprenticeship()
        {
        }

        [Given(@"an employment check has failed for an apprenticeship incentive")]
        public async Task GivenAnEmploymentCheckHasFailed()
        {
            await GivenAnEmploymentCheckHasBeenRequested();
            await WhenTheEmploymentCheckIsComplete("employed", "not employed");
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedAtStartOfApprenticeship, false, TimeSpan.FromMinutes(1));
        }

        [Given(@"the employer has requested the check be re-ran")]
        public void GivenTheEmployerHasRequestedTheCheckBeReRan()
        {
        }

        [Given(@"month end is not in progress")]
        public void GivenMonthEndIsNotInProgress()
        {
        }

        [Given(@"we have previously received a result from the Employment Check service")]
        public async Task GivenWeHavePreviouslyReceivedAResultFromTheEmploymentCheckService()
        {
            await WhenTheEmploymentCheckIsComplete();
            _employmentCheckResult = "not employed";
        }

        [Given(@"the employment check returns that the apprentice was employed in the 6 months prior to the scheme phase starting")]
        public async Task GivenTheApprenticeWasEmployedPriorToSchemeStart()
        {
            _expectedEmployedBeforeSchemeStartedValidationResult = false;
            _expectedEmployedAtStartOfApprenticeshipValidationResult = true;
            _employmentCheckResult = "employed";
            await WhenTheEmploymentCheckIsComplete();
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedAtStartOfApprenticeship, true, TimeSpan.FromMinutes(1));
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedBeforeSchemeStarted, true, TimeSpan.FromMinutes(1));
        }

        [Given(@"the employment check returns that the apprentice was not employed in the 6 weeks after their start date")]
        public async Task GivenTheApprenticeWasNotEmployedAtApprenticeshipStart()
        {
            _expectedEmployedBeforeSchemeStartedValidationResult = true;
            _expectedEmployedAtStartOfApprenticeshipValidationResult = false;
            _employmentCheckResult = "not employed";
            await WhenTheEmploymentCheckIsComplete();
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedAtStartOfApprenticeship, false, TimeSpan.FromMinutes(1));
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedBeforeSchemeStarted, false, TimeSpan.FromMinutes(1));
        }

        [Given(@"the employment check returns that the apprentice was employed in the 6 weeks after their start date")]
        [Given(@"the employment check returns that the apprentice was not employed in the 6 months prior to the scheme starting")]
        public async Task GivenTheApprenticeHasValidEmploymentChecks()
        {
            await WhenTheEmploymentCheckIsComplete("not employed", "employed");
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedAtStartOfApprenticeship, true, TimeSpan.FromMinutes(1));
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedBeforeSchemeStarted, false, TimeSpan.FromMinutes(1));
        }

        [Given(@"an ILR has not been submitted for the learner")]
        public void GivenAnIlrHasNotBeenSubmitted()
        {
            _expectedEmployedBeforeSchemeStartedValidationResult = false;
            _expectedEmployedAtStartOfApprenticeshipValidationResult = false;
        }

        [Given(@"the apprenticeship incentive has been withdrawn")]
        public async Task GivenTheApprenticeshipIncentiveHasBeenWithdrawn()
        {
            await Helper.EIFunctionsHelper.Withdraw(TestData.ULN, TestData.IncentiveApplication.AccountLegalEntityId, WithdrawalType.Compliance);
            await Helper.EISqlHelper.WaitUntilIncentiveWithdrawn(TestData.ApprenticeshipIncentiveId, TimeSpan.FromSeconds(5));
        }

        [Given(@"month end is in progress")]
        public async Task GivenMonthEndIsInProgress()
        {
            await Helper.PaymentsOrchestratorHelper.Run();
        }

        [Given(@"apprenticeship incentives have been submitted")]
        public async Task GivenApprenticeshipIncentivesHaveBeenSubmitted()
        {
            await CreateIncentive(Phase.Phase2, new DateTime(2021, 04, 30));
            await CreateIncentive(Phase.Phase2, new DateTime(2021, 05, 30));
        }

        [Given(@"an ILR submission has been received for that learner")]
        public async Task GivenAnIlrSubmissionIsReceived()
        {
            await WhenAnIlrSubmissionIsReceived();
            await WhenTheLearnerMatchIsRun();
        }

        private async Task CreateIncentive(Phase phase, DateTime startDate)
        {
            _startDate = startDate;

            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, 2021);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithDateSubmitted(_startDate)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN,
                    _startDate, _startDate.AddYears(-20),
                    Context.ScenarioInfo.Title, phase)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [When(@"we have not previously requested an employment check for the learner")]
        public void WhenWeHaveNotPreviouslyRequestedAnEmploymentCheck()
        {
        }

        [When(@"6 weeks has elapsed since the start date of the apprenticeship")]
        public void When6WeeksHaveElapsedSinceStartDate()
        {
        }

        [When(@"an ILR submission is received for that learner")]
        public async Task WhenAnIlrSubmissionIsReceived()
        {
            await Helper.EmploymentCheckApiHelper.SetupPut();
            await SetupSubmission();
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, 2021);
        }

        [When(@"a Start Date Change of Circumstance has been identified in that ILR submission")]
        public async Task WhenAStartDateCoCOccurs()
        {
            _startDate = _startDate.AddDays(10);
            await SetupSubmission();
        }

        [When(@"the learner match is run")]
        public async Task WhenTheLearnerMatchIsRun()
        {
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"the check has been completed by the Employment Check service")]
        public async Task WhenTheEmploymentCheckIsComplete()
        {
            await WhenTheEmploymentCheckIsComplete(_employmentCheckResult, _employmentCheckResult);
        }

        public async Task WhenTheEmploymentCheckIsComplete(string statusBeforeScheme, string statusAtStart)
        {
            var employedBeforeSchemeCheck = _employmentChecks.Single(x => x.CheckType == EmploymentCheckType.EmployedBeforeSchemeStarted);
            await Helper.EIServiceBusHelper.Publish(new EmploymentCheck.Types.EmploymentCheckCompletedEvent(employedBeforeSchemeCheck.CorrelationId, IsEmployed(statusBeforeScheme), DateTime.Now, null!));
            var employedAtStartCheck = _employmentChecks.Single(x => x.CheckType == EmploymentCheckType.EmployedAtStartOfApprenticeship);
            await Helper.EIServiceBusHelper.Publish(new EmploymentCheck.Types.EmploymentCheckCompletedEvent(employedAtStartCheck.CorrelationId, IsEmployed(statusAtStart), DateTime.Now, null!));
        }

        private static bool IsEmployed(string status) => status == "employed";

        [When(@"the month end process is initiated")]
        public async Task WhenMonthEndIsRan()
        {
            await Helper.PaymentsOrchestratorHelper.Run();
        }

        [When(@"there are no other validation failures")]
        public void WhenThereAreNoOtherValidationFailures()
        {
        }

        [When(@"the second line support user requests a recheck")]
        public async Task WhenARecheckIsRequested()
        {
            await Helper.EIFunctionsHelper.TriggerEmploymentCheck(TestData.Account.AccountLegalEntityId, TestData.ULN);
        }

        [When(@"the refresh of all employment checks is requested")]
        public async Task WhenTheRefreshOfAllEmploymentChecksIsRequested()
        {
            await Helper.EISqlHelper.DeleteEmploymentChecks(TestData.ApprenticeshipIncentiveId);
            await Helper.EIFunctionsHelper.TriggerEmploymentChecks();
        }

        [Then(@"a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 1 starting")]
        public async Task ThenANewNotEmployedBeforePhase1EmploymentCheckIsCreated()
        {
            await VerifyNotEmployedBeforePhaseEmploymentCheck(new DateTime(2020, 07, 31), new DateTime(2020, 08, 01).AddMonths(-6));
        }

        [Then(@"a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 2 starting")]
        public async Task ThenANewNotEmployedBeforePhase2EmploymentCheckIsCreated()
        {
            await VerifyNotEmployedBeforePhaseEmploymentCheck(new DateTime(2021, 03, 31), new DateTime(2021, 04, 01).AddMonths(-6));
        }

        [Then(@"a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 3 starting")]
        public async Task ThenANewNotEmployedBeforePhase3EmploymentCheckIsCreated()
        {
            await VerifyNotEmployedBeforePhaseEmploymentCheck(new DateTime(2021, 09, 30), new DateTime(2021, 10, 01).AddMonths(-6));
        }

        private async Task VerifyNotEmployedBeforePhaseEmploymentCheck(DateTime maximumDate, DateTime minimumDate)
        {
            await Helper.EISqlHelper.WaitUntilCorrelationIdsSet(TestData.ApprenticeshipIncentiveId, TimeSpan.FromMinutes(1));

            var employmentCheck = Helper.EISqlHelper.GetAllFromDatabase<Models.EmploymentCheck>()
                .Single(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId &&
                             x.CheckType == EmploymentCheckType.EmployedBeforeSchemeStarted);

            employmentCheck.CorrelationId.Should().NotBe(Guid.Empty);
            employmentCheck.MaximumDate.Should().Be(maximumDate);
            employmentCheck.MinimumDate.Should().Be(minimumDate);
            employmentCheck.Result.Should().BeNull();
        }

        [Then(@"a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date")]
        public async Task ThenANewEmployedAfterStartDateEmploymentCheckIsCreated()
        {
            await Helper.EISqlHelper.WaitUntilCorrelationIdsSet(TestData.ApprenticeshipIncentiveId, TimeSpan.FromMinutes(1));

            var employmentCheck = Helper.EISqlHelper.GetAllFromDatabase<Models.EmploymentCheck>()
                .Single(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && x.CheckType == EmploymentCheckType.EmployedAtStartOfApprenticeship);

            employmentCheck.CorrelationId.Should().NotBe(Guid.Empty);
            employmentCheck.MaximumDate.Should().Be(_startDate.AddDays(42));
            employmentCheck.MinimumDate.Should().Be(_startDate);
            employmentCheck.Result.Should().BeNull();
        }

        [Then(@"a new employment check is not requested")]
        public void ThenANewEmploymentCheckIsNotRequested()
        {
            var employmentCheckCount = Helper.EISqlHelper.GetAllFromDatabase<Models.EmploymentCheck>()
                .Count(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);

            employmentCheckCount.Should().Be(0);
        }

        [Then(@"the result is stored")]
        public async Task ThenTheResultIsStored()
        {
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedAtStartOfApprenticeship, true, TimeSpan.FromMinutes(1));
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedBeforeSchemeStarted, true, TimeSpan.FromMinutes(1));
        }

        [Then(@"the result is updated")]
        public async Task ThenTheResultIsUpdated()
        {
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedAtStartOfApprenticeship, false, TimeSpan.FromMinutes(1));
            await Helper.EISqlHelper.WaitUntilEmploymentCheckResultIsSet(TestData.ApprenticeshipIncentiveId, EmploymentCheckType.EmployedBeforeSchemeStarted, false, TimeSpan.FromMinutes(1));
        }

        [Then(@"the result is discarded")]
        public void ThenTheResultIsDiscarded()
        {
            var employmentChecks = Helper.EISqlHelper.GetAllFromDatabase<Models.EmploymentCheck>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId).ToList();

            employmentChecks[0].Result.Should().BeNull();
            employmentChecks[1].Result.Should().BeNull();
        }

        [Then(@"a payment is not created for the apprenticeship incentive")]
        public void ThenAPaymentIsNotCreatedForTheApprenticeshipIncentive()
        {
            var payments = Helper.EISqlHelper.GetAllFromDatabase<Payment>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId).ToList();

            payments.Should().BeEmpty();

            var pendingPayments = Helper.EISqlHelper.GetAllFromDatabase<PendingPayment>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId).ToList();

            var validationResults = Helper.EISqlHelper.GetAllFromDatabase<PendingPaymentValidationResult>()
                .Where(vr => pendingPayments.Any(pp => pp.Id == vr.PendingPaymentId));

            validationResults.Single(x => x.Step == "EmployedAtStartOfApprenticeship").Result.Should().Be(_expectedEmployedAtStartOfApprenticeshipValidationResult);
            validationResults.Single(x => x.Step == "EmployedBeforeSchemeStarted").Result.Should().Be(_expectedEmployedBeforeSchemeStartedValidationResult);
        }

        [Then(@"a payment is created for the apprenticeship incentive")]
        public void ThenAPaymentIsCreatedForTheApprenticeshipIncentive()
        {
            var payments = Helper.EISqlHelper.GetAllFromDatabase<Payment>()
                .Where(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId).ToList();

            payments.Count().Should().Be(1);
        }

        private async Task SetupSubmission()
        {
            var academicYear = 2021;

            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithAcademicYear(academicYear)
                .WithStartDate(_startDate)
                .WithEndDate(_startDate.AddYears(1))
                .WithPeriod(TestData.ApprenticeshipId, 11)
                .Create();

            var learnerSubmissionData = new LearnerSubmissionDtoBuilder()
                .WithUkprn(TestData.UKPRN)
                .WithUln(TestData.ULN)
                .WithAcademicYear(academicYear)
                .WithIlrSubmissionDate(_startDate.AddMonths(1))
                .WithIlrSubmissionWindowPeriod(1)
                .WithStartDate(_startDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN, learnerSubmissionData);
        }
    }
}
