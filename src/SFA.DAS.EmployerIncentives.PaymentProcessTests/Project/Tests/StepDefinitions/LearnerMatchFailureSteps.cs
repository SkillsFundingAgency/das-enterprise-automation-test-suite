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
    [Scope(Feature = "LearnerMatchFailure")]
    public class LearnerMatchFailureSteps : StepsBase
    {
        private DateTime _initialIlrSubmissionDate;
        private DateTime _initialStartDate;

        protected LearnerMatchFailureSteps(ScenarioContext context) : base(context) { }

        [Given(@"the learner match process has been triggered")]
        public async Task GivenTheLearnerMatchProcessHasBeenTriggered()
        {
            _initialStartDate = new DateTime(2021, 9, 1);
            _initialIlrSubmissionDate = new DateTime(2021, 5, 12);

            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(1, 2122);

            var dateOfBirth = _initialStartDate.AddYears(-24).AddMonths(-11);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                    .WithAccount(TestData.Account)
                    .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _initialStartDate, dateOfBirth, Context.ScenarioInfo.Title, Phase.Phase2)
                    .WithApprenticeship(Fixture.Create<long>(), Fixture.Create<long>(), Fixture.Create<long>(), _initialStartDate, dateOfBirth, Context.ScenarioInfo.Title, Phase.Phase2)
                    .WithApprenticeship(Fixture.Create<long>(), Fixture.Create<long>(), Fixture.Create<long>(), _initialStartDate, dateOfBirth, Context.ScenarioInfo.Title, Phase.Phase2)
                    .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);

            foreach (var apprenticeship in TestData.IncentiveApplication.Apprenticeships)
            {
                var priceEpisode = new PriceEpisodeDtoBuilder()
                    .WithStartDate(_initialStartDate)
                    .WithAcademicYear(2122)
                    .WithEndDate(DateTime.Now.AddYears(1))
                    .WithPeriod(apprenticeship.ApprenticeshipId, 1)
                    .Create();

                var learnerSubmissionDto = new LearnerSubmissionDtoBuilder()
                    .WithUkprn(apprenticeship.UKPRN.Value)
                    .WithUln(apprenticeship.ULN)
                    .WithAcademicYear(2122)
                    .WithIlrSubmissionDate(_initialIlrSubmissionDate)
                    .WithIlrSubmissionWindowPeriod(1)
                    .WithStartDate(_initialStartDate)
                    .WithPriceEpisode(priceEpisode)
                    .Create();

                await Helper.LearnerMatchApiHelper.SetupResponse(apprenticeship.ULN, apprenticeship.UKPRN.Value, learnerSubmissionDto);
            }

            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"an exception occurs for a learner")]
        public async Task WhenAnExceptionOccursForALearner()
        {
            // invalidate data to cause an error
            await Helper.LearnerMatchApiHelper.SetupResponse(TestData.ULN, TestData.UKPRN,
                "{\"bad\": \"json\"}");

            await Helper.LearnerMatchOrchestratorHelper.Run(true);
        }

        [Then(@"a record of learner match failure is created for the learner")]
        public void ThenARecordOfLearnerMatchFailureIsCreatedForTheLearner()
        {
            var learner = Helper.EISqlHelper.GetFromDatabase<Learner>(x => x.ULN == TestData.ULN && x.Ukprn == TestData.UKPRN);
            learner.SuccessfulLearnerMatchExecution.Should().BeFalse();
        }
        
        [Then(@"the learner match process should continue for all remaining learners")]
        public void ThenTheLearnerMatchProcessShouldContinueForAllRemainingLearners()
        {
            var learners = Helper.EISqlHelper.GetAllFromDatabase<Learner>()
                .Where(learner => (learner.ULN == TestData.IncentiveApplication.Apprenticeships[1].ULN &&
                                   learner.Ukprn == TestData.IncentiveApplication.Apprenticeships[1].UKPRN) ||
                                  (learner.ULN == TestData.IncentiveApplication.Apprenticeships[2].ULN &&
                                   learner.Ukprn == TestData.IncentiveApplication.Apprenticeships[2].UKPRN));

            foreach (var learner in learners)
            {
                learner.SuccessfulLearnerMatchExecution.Should().BeTrue();
            }
        }
    }
}
