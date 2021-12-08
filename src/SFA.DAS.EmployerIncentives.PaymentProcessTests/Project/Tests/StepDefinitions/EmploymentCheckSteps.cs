using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "EmploymentCheck")]
    public class EmploymentCheckSteps : StepsBase
    {
        private DateTime _startDate;

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

        [Given(@"an apprenticeship incentive has been submitted less than 6 weeks ago")]
        public async Task GivenAnIncentiveSubmittedLessThan6WeeksAgo()
        {
            await CreateIncentive(Phase.Phase2, DateTime.Now.AddDays(-41));
        }

        private async Task CreateIncentive(Phase phase, DateTime startDate)
        {
            _startDate = startDate;

            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(6, 2021);

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
        public async Task WhenTheLearnerMatchIsRun()
        {
            await Helper.EmploymentCheckApiHelper.SetupPut();
            await SetupSubmission();
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, 2021);
            await Helper.LearnerMatchOrchestratorHelper.Run();
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

        private async Task VerifyNotEmployedBeforePhaseEmploymentCheck(DateTime maximumDate, DateTime minimumDate)
        {
            await Helper.EISqlHelper.WaitUntilEarningsExist(TestData.ApprenticeshipIncentiveId, TimeSpan.FromMinutes(1));

            var employmentCheck = Helper.EISqlHelper.GetAllFromDatabase<EmploymentCheck>()
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
            await Helper.EISqlHelper.WaitUntilEarningsExist(TestData.ApprenticeshipIncentiveId, TimeSpan.FromMinutes(1));

            var employmentCheck = Helper.EISqlHelper.GetAllFromDatabase<EmploymentCheck>()
                .Single(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId && x.CheckType == EmploymentCheckType.EmployedAtStartOfApprenticeship);

            employmentCheck.CorrelationId.Should().NotBe(Guid.Empty);
            employmentCheck.MaximumDate.Should().Be(_startDate.AddDays(42));
            employmentCheck.MinimumDate.Should().Be(_startDate);
            employmentCheck.Result.Should().BeNull();
        }

        [Then(@"a new employment check is not requested")]
        public async Task ThenANewEmploymentCheckIsNotRequested()
        {
            var employmentCheckCount = Helper.EISqlHelper.GetAllFromDatabase<EmploymentCheck>()
                .Count(x => x.ApprenticeshipIncentiveId == TestData.ApprenticeshipIncentiveId);

            employmentCheckCount.Should().Be(0);
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
