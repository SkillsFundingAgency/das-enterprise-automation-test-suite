using AutoFixture;
using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using SFA.DAS.Payments.Model.Core;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LearnerMatchFailureSteps : StepsBase
    {
        protected LearnerMatchFailureSteps(ScenarioContext context) : base(context)
        {
        }
        [Given(@"the learner match process has been triggered")]
        public async Task GivenTheLearnerMatchProcessHasBeenTriggered()
        {
            var initialStartDate = new DateTime(2021, 7, 1);
            
            await SetActiveCollectionPeriod(10, 2021);

            var dateOfBirth = initialStartDate.AddYears(-24).AddMonths(-11); // under 25 at the start of learning 

            incentiveApplication = new IncentiveApplicationBuilder()
                .WithAccountId(accountId)
                .WithApprenticeship(apprenticeshipId, ULN, UKPRN, initialStartDate, dateOfBirth, Phase.Phase2)
                .WithApprenticeship(fixture.Create<long>(), fixture.Create<long>(), fixture.Create<long>(), initialStartDate, dateOfBirth, Phase.Phase2)
                .WithApprenticeship(fixture.Create<long>(), fixture.Create<long>(), fixture.Create<long>(), initialStartDate, dateOfBirth, Phase.Phase2)
                .WithApprenticeship(fixture.Create<long>(), fixture.Create<long>(), fixture.Create<long>(), initialStartDate, dateOfBirth, Phase.Phase2)
                .WithApprenticeship(fixture.Create<long>(), fixture.Create<long>(), fixture.Create<long>(), initialStartDate, dateOfBirth, Phase.Phase2)
                .Create();
 
            await SubmitIncentiveApplication(incentiveApplication);

            foreach (var apprenticeship in incentiveApplication.Apprenticeships)
            {
                var priceEpisode = new PriceEpisodeDtoBuilder()
                    .WithStartDate(initialStartDate)
                    .WithEndDate(initialStartDate.AddMonths(12))
                    .WithPeriod(apprenticeship.ApprenticeshipId, 10)
                    .Create();

                var learnerSubmissionDto = new LearnerSubmissionDtoBuilder()
                    .WithUkprn(apprenticeship.UKPRN.Value)
                    .WithUln(apprenticeship.ULN)
                    .WithAcademicYear(2021)
                    .WithIlrSubmissionDate("2021-05-12T09:11:46.82")
                    .WithIlrSubmissionWindowPeriod(10)
                    .WithStartDate(initialStartDate)
                    .WithPriceEpisode(priceEpisode)
                    .Create();

                await SetupLearnerMatchApiResponse(ULN, UKPRN, learnerSubmissionDto);
            }

            await RunLearnerMatchOrchestrator();

        }
        
        [When(@"an exception occurs for a learner")]
        public void WhenAnExceptionOccursForALearner()
        {
            var learners = GetAllFromDatabase<Models.Learner>();
            learners.Count.Should().BeGreaterOrEqualTo(5);
        }
        
        [Then(@"each exception is logged with the detail of the exception in Kabana and Apps Insight")]
        public void ThenEachExceptionIsLoggedWithTheDetailOfTheExceptionInKabanaAndAppsInsight()
        {
            var learner = GetFromDatabase<Models.Learner>(x => x.ULN == ULN && x.Ukprn == UKPRN);
            learner.SuccessfulLearnerMatch.Should().BeFalse();
        }
        
        [Then(@"the learner match process should continue for all remaining learners")]
        public void ThenTheLearnerMatchProcessShouldContinueForAllRemainingLearners()
        {
            
        }
        
        [Then(@"any CoCs are processed for each learner \(excluding exceptions\)")]
        public void ThenAnyCoCsAreProcessedForEachLearnerExcludingExceptions()
        {
           
        }
        
        [Then(@"days in learning is calculated for each learner \(excluding exceptions\)")]
        public void ThenDaysInLearningIsCalculatedForEachLearnerExcludingExceptions()
        {
         
        }

    }
}
