using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Dapper;
using Dapper.Contrib.Extensions;
using NUnit.Framework;
using SFA.DAS.EmployerIncentives.UITests.Messages;
using SFA.DAS.EmployerIncentives.UITests.Models;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LearnerMatchTestSteps
    {
        private EIConfig _config;
        private Fixture _fixture;
        private IncentiveApplication _incentiveApplication;
        private IncentiveApplicationApprenticeship _apprenticeship;

        public LearnerMatchTestSteps(ScenarioContext context)
        {
            _fixture = new Fixture();
            _config = context.GetEIConfig<EIConfig>();
        }

        [Given(@"there are some apprenticeship incentives")]
        public async Task GivenThereAreSomeApprenticeshipIncentives()
        {
            // Proper tests may not want to use autofixture, they may use known data instead.
            _incentiveApplication = _fixture.Create<IncentiveApplication>();
            _apprenticeship  = _fixture.Build<IncentiveApplicationApprenticeship>().With(a => a.IncentiveApplicationId, _incentiveApplication.Id).Create();

            using var dbConnection = new SqlConnection(_config.EI_IncentivesDbConnectionString);
            await DapperExtensions.InsertAsync(dbConnection, _incentiveApplication);
            await DapperExtensions.InsertAsync(dbConnection, _apprenticeship);

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

            // May need to wait a short while to allow earnings to be created. This can be improved to check the database
            Thread.Sleep(10000);

            // Possibly need to mock the learner match API
        }

        [When(@"the learner match service is completed")]
        public async Task WhenTheLearnerMatchServiceIsCompleted()
        {
            var learnerMatchService = new EILearnerMatchHelper(_config);
            await learnerMatchService.StartLearnerMatchOrchestrator();
            await learnerMatchService.WaitUntilComplete(new TimeSpan(0, 1, 0));
        }

        [Then(@"we have some learner data")]
        public void ThenWeHaveSomeLearnerData()
        {
            var sqlHelper = new EISqlHelper(_config);
            var learnersExisting = sqlHelper.VerifyLearningRecordsExist();
            Assert.IsTrue(learnersExisting);
        }

        [AfterScenario(Order = 1)]
        public async Task ClearUpData()
        {
            using var dbConnection = new SqlConnection(_config.EI_IncentivesDbConnectionString);
            await dbConnection.DeleteAsync(_apprenticeship);
            await dbConnection.DeleteAsync(_incentiveApplication);
        }
    }
}
