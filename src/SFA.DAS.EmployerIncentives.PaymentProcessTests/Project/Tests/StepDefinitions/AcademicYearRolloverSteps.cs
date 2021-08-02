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
    public class AcademicYearRolloverSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;
        private Learner _learner;

        protected AcademicYearRolloverSteps(ScenarioContext context) : base(context)
        {
            testData.AccountId = 14326;
        }

        [Given(@"an existing Phase1 apprenticeship incentive")]
        public async Task GivenAnExistingPhase1ApprenticeshipIncentive()
        {
            await helper.CollectionCalendarHelper.SetActiveCollectionPeriod(11, 2021);

            _initialStartDate = new DateTime(2021, 1, 5);
            _initialEndDate = new DateTime(2021, 7, 31);

            testData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(testData.AccountId)
                .WithApprenticeship(testData.ApprenticeshipId, testData.ULN, testData.UKPRN, _initialStartDate,
                    _initialStartDate.AddYears(-24), Phase.Phase1)
                .Create();

            await helper.IncentiveApplicationHelper.Submit(testData.IncentiveApplication);

            const byte period = 4;
            var priceEpisode = new PriceEpisodeDtoBuilder()
                .WithStartDate(_initialStartDate)
                .WithEndDate(_initialEndDate)
                .WithPeriod(testData.ApprenticeshipId, period)
                .Create();

            var submission = new LearnerSubmissionDtoBuilder()
                .WithUkprn(testData.UKPRN)
                .WithUln(testData.ULN)
                .WithAcademicYear(2021)
                .WithIlrSubmissionDate(_initialStartDate.AddMonths(-1))
                .WithIlrSubmissionWindowPeriod(period)
                .WithStartDate(_initialStartDate)
                .WithPriceEpisode(priceEpisode)
                .Create();

            await helper.LearnerMatchApiHelper.SetupResponse(testData.ULN, testData.UKPRN, submission);
            await helper.LearnerMatchOrchestratorHelper.Run();
        }
        
        [When(@"a call to the learner match service is made for an incentive application after the census date for R12 of the previous academic year")]
        public async Task GivenACallToTheLearnerMatchServiceIsMadeForAnIncentiveApplicationAfterTheCensusDateForROfThePreviousAcademicYear()
        {
            await helper.CollectionCalendarHelper.SetActiveCollectionPeriod(12, 2021);
            await helper.LearnerMatchOrchestratorHelper.Run();
        }

        [Given(@"the end date of the most recent price episode is the census date of the previous Academic Year")]
        public void GivenTheEndDateOfTheMostRecentPriceEpisodeIsTheCensusDateOfThePreviousAcademicYear()
        {
            // blank
        }

        [When(@"the provider has not submitted an ILR for the current Academic")]
        public void WhenTheProviderHasNotSubmittedAnILRForTheCurrentAcademic()
        {
            // blank
        }
        
        [Then(@"do not trigger a learning stopped CoC event")]
        public void ThenDoNotTriggerALearningStoppedCoCEvent()
        {
            _learner = helper.EISqlHelper.GetFromDatabase<Learner>(x =>
                x.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId);
            _learner.Should().NotBeNull();

            _learner.InLearning.Should().BeTrue();

            helper.EISqlHelper.GetAllFromDatabase<ChangeOfCircumstance>()
                .Any(x => x.ApprenticeshipIncentiveId == testData.ApprenticeshipIncentiveId)
                .Should().BeFalse();
        }
    }
}
