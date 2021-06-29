using AutoFixture;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
// ReSharper disable PossibleInvalidOperationException

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LearnerMatchFailureSteps : StepsBase
    {
        private DateTime _initialIlrSubmissionDate;
        private DateTime _initialStartDate;

        protected LearnerMatchFailureSteps(ScenarioContext context) : base(context)
        {
            accountId = 14326;
            apprenticeshipId = fixture.Create<long>();
        }
        [Given(@"the learner match process has been triggered")]
        public async Task GivenTheLearnerMatchProcessHasBeenTriggered()
        {
            _initialStartDate = new DateTime(2021, 6, 1);
            _initialIlrSubmissionDate = new DateTime(2021, 5, 12);

            await SetActiveCollectionPeriod(10, 2021);

            var dateOfBirth = _initialStartDate.AddYears(-24).AddMonths(-11);

            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(accountId)
                .WithApprenticeship(apprenticeshipId, ULN, UKPRN, _initialStartDate, dateOfBirth, Phase.Phase2)
                .WithApprenticeship(fixture.Create<long>(), fixture.Create<long>(), fixture.Create<long>(), _initialStartDate, dateOfBirth, Phase.Phase2)
                .WithApprenticeship(fixture.Create<long>(), fixture.Create<long>(), fixture.Create<long>(), _initialStartDate, dateOfBirth, Phase.Phase2)
                .Create();

            await SubmitIncentiveApplication(incentiveApplication);

            foreach (var apprenticeship in incentiveApplication.Apprenticeships)
            {
                var priceEpisode = new PriceEpisodeDtoBuilder()
                    .WithStartDate(_initialStartDate)
                    .WithEndDate(DateTime.Now.AddYears(1))
                    .WithPeriod(apprenticeship.ApprenticeshipId, 10)
                    .Create();

                var learnerSubmissionDto = new LearnerSubmissionDtoBuilder()
                    .WithUkprn(apprenticeship.UKPRN.Value)
                    .WithUln(apprenticeship.ULN)
                    .WithAcademicYear(2021)
                    .WithIlrSubmissionDate(_initialIlrSubmissionDate)
                    .WithIlrSubmissionWindowPeriod(10)
                    .WithStartDate(_initialStartDate)
                    .WithPriceEpisode(priceEpisode)
                    .Create();

                await SetupLearnerMatchApiResponse(apprenticeship.ULN, apprenticeship.UKPRN.Value, learnerSubmissionDto);
            }

            await RunLearnerMatchOrchestrator(true);

            // 2nd run
            await SetActiveCollectionPeriod(11, 2021);

            foreach (var apprenticeship in incentiveApplication.Apprenticeships)
            {
                var priceEpisode = new PriceEpisodeDtoBuilder()
                    .WithStartDate(_initialStartDate)
                    .WithEndDate(DateTime.Now.AddDays(-1)) // Learning Stopped!!!
                    .WithPeriod(apprenticeship.ApprenticeshipId, 10)
                    .Create();

                var learnerSubmissionDto = new LearnerSubmissionDtoBuilder()
                    .WithUkprn(apprenticeship.UKPRN.Value)
                    .WithUln(apprenticeship.ULN)
                    .WithAcademicYear(2021)
                    .WithIlrSubmissionDate(_initialIlrSubmissionDate.AddMonths(1))
                    .WithIlrSubmissionWindowPeriod(10)
                    .WithStartDate(_initialStartDate)
                    .WithPriceEpisode(priceEpisode)
                    .Create();

                await SetupLearnerMatchApiResponse(apprenticeship.ULN, apprenticeship.UKPRN.Value, learnerSubmissionDto);
            }

            await RunLearnerMatchOrchestrator(true);
        }

        [When(@"an exception occurs for a learner")]
        public async Task WhenAnExceptionOccursForALearner()
        {
            // 3rd run 
            await SetActiveCollectionPeriod(12, 2021);

            foreach (var apprenticeship in incentiveApplication.Apprenticeships)
            {
                var priceEpisode = new PriceEpisodeDtoBuilder()
                    .WithStartDate(_initialStartDate)
                    .WithEndDate(DateTime.Now.AddYears(2))
                    .WithPeriod(apprenticeship.ApprenticeshipId, 10)
                    .Create();

                if (apprenticeship.UKPRN == UKPRN && apprenticeship.ULN == ULN)
                {
                    // Apprenticeship Id changed to cause an error
                    priceEpisode.Periods.First().ApprenticeshipId -= 1;
                }

                var learnerSubmissionDto = new LearnerSubmissionDtoBuilder()
                    .WithUkprn(apprenticeship.UKPRN.Value)
                    .WithUln(apprenticeship.ULN)
                    .WithAcademicYear(2021)
                    .WithIlrSubmissionDate(_initialIlrSubmissionDate.AddMonths(2))
                    .WithIlrSubmissionWindowPeriod(10)
                    .WithStartDate(_initialStartDate)
                    .WithPriceEpisode(priceEpisode)
                    .Create();

                await SetupLearnerMatchApiResponse(apprenticeship.ULN, apprenticeship.UKPRN.Value, learnerSubmissionDto);
            }

            await RunLearnerMatchOrchestrator(true);
        }

        [Then(@"a record of learner match failure is created for the learner")]
        public void ThenARecordOfLearnerMatchFailureIsCreatedForTheLearner()
        {
            var learner = GetFromDatabase<Learner>(x => x.ULN == ULN && x.Ukprn == UKPRN);
            learner.SuccessfulLearnerMatch.Should().BeFalse();
        }
        
        [Then(@"the learner match process should continue for all remaining learners")]
        public void ThenTheLearnerMatchProcessShouldContinueForAllRemainingLearners()
        {
            var learners = GetAllFromDatabase<Learner>()
                .Where(x => x.ULN != ULN && x.Ukprn != UKPRN);

            foreach (var learner in learners)
            {
                learner.SuccessfulLearnerMatch.Should().BeTrue();
            }
        }
        
        [Then(@"any CoCs are processed for each learner \(excluding exceptions\)")]
        public void ThenAnyCoCsAreProcessedForEachLearnerExcludingExceptions()
        {
            var changeOfCircumstances = GetAllFromDatabase<ChangeOfCircumstance>().ToList();
            changeOfCircumstances.Count.Should().BeGreaterOrEqualTo(3);

            var learner = GetFromDatabase<Learner>(x => x.ULN == ULN && x.Ukprn == UKPRN);
            GetAllFromDatabase<ChangeOfCircumstance>()
                .Count(x => x.ApprenticeshipIncentiveId == learner.ApprenticeshipIncentiveId)
                .Should().Be(1);
        }

        [Then(@"days in learning is calculated for each learner \(excluding exceptions\)")]
        public void ThenDaysInLearningIsCalculatedForEachLearnerExcludingExceptions()
        {
            var daysInLearnings = GetAllFromDatabase<ApprenticeshipDaysInLearning>().ToList();
            daysInLearnings.Count.Should().BeGreaterOrEqualTo(7);

            var learner = GetFromDatabase<Learner>(x => x.ULN == ULN && x.Ukprn == UKPRN);
            GetAllFromDatabase<ApprenticeshipDaysInLearning>()
                .Count(x => x.LearnerId == learner.Id)
                .Should().Be(1);
        }
    }
}
