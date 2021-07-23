using AutoFixture;
using Dapper.Contrib.Extensions;
using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Messages;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

// ReSharper disable PossibleInvalidOperationException
// ReSharper disable InconsistentNaming

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    public class StepsBase
    {
        protected TestData testData;

        protected Fixture fixture;
        protected readonly DbConfig dbConfig;
        protected readonly EIPaymentProcessConfig eiConfig;
        protected EISqlHelper sqlHelper;
        protected LearnerMatchApiHelper learnerMatchApi;
        protected BusinessCentralApiHelper businessCentralApiHelper;
        protected IncentiveApplication incentiveApplication;        

        private readonly StopWatchHelper _stopWatchHelper;
        

        protected StepsBase(ScenarioContext context)
        {
            _stopWatchHelper = context.Get<StopWatchHelper>();
            _stopWatchHelper.Start("StepsBase");
            fixture = new Fixture();
            testData = context.Get<TestData>();

            eiConfig = context.GetEIPaymentProcessConfig<EIPaymentProcessConfig>();
            dbConfig = context.Get<DbConfig>();
            sqlHelper = new EISqlHelper(dbConfig);

            learnerMatchApi = new LearnerMatchApiHelper(eiConfig);            

            businessCentralApiHelper = new BusinessCentralApiHelper(eiConfig);

            _stopWatchHelper.Stop("StepsBase");
        }

        protected async Task DeleteApplicationData()
        {
            _stopWatchHelper.Start("DeleteApplicationData");
            await sqlHelper.DeleteApplicationData(incentiveApplication.Id);
            _stopWatchHelper.Stop("DeleteApplicationData");
        }

        protected async Task DeleteIncentives()
        {
            _stopWatchHelper.Start("DeleteIncentiveData");
            foreach (var apprenticeship in incentiveApplication.Apprenticeships)
            {
                await DeleteIncentive(incentiveApplication.AccountId, apprenticeship.ApprenticeshipId);
            }
            _stopWatchHelper.Stop("DeleteIncentiveData");
        }

        private async Task DeleteIncentive(long accountId, long apprenticeshipId)
        {
            await sqlHelper.DeleteIncentiveData(accountId, apprenticeshipId);
        }

        protected async Task ResetCalendar()
        {
            await sqlHelper.ResetCalendar();
        }

        protected async Task SetupLearnerMatchApiResponse(long uln, long ukprn, string json)
        {
            _stopWatchHelper.Start("SetupLearnerMatchApiResponse");
            await learnerMatchApi.SetupResponse(uln, ukprn, json);
            _stopWatchHelper.Stop("SetupLearnerMatchApiResponse");
        }

        protected async Task SetupLearnerMatchApiResponse(long uln, long ukprn, LearnerSubmissionDto data)
        {
            _stopWatchHelper.Start("SetupLearnerMatchApiResponse");
            await learnerMatchApi.SetupResponse(uln, ukprn, data);
            _stopWatchHelper.Stop("SetupLearnerMatchApiResponse");
        }

        protected List<T> GetAllFromDatabase<T>() where T : class
        {
            using var dbConnection = new SqlConnection(sqlHelper.ConnectionString);
            return dbConnection.GetAll<T>().ToList();
        }

        protected T GetFromDatabase<T>(Func<T, bool> predicate) where T : class
        {
            using var dbConnection = new SqlConnection(sqlHelper.ConnectionString);
            return dbConnection.GetAll<T>().Single(predicate);
        }

        protected async Task SetupBusinessCentralApiToAcceptAllPayments()
        {
            _stopWatchHelper.Start("SetupBusinessCentralApiToAcceptAllPayments");
            await businessCentralApiHelper.SetupAcceptAllRequests();
            _stopWatchHelper.Stop("SetupBusinessCentralApiToAcceptAllPayments");
        }
        protected async Task VerifyLearningRecordsExist()
        {
            var exist = await sqlHelper.VerifyLearningRecordsExist(testData.ApprenticeshipIncentiveId);
            Assert.IsTrue(exist);
        }

        protected async Task VerifyPaymentRecordsExist()
        {
            var exist = await sqlHelper.VerifyPaymentRecordsExist(testData.ApprenticeshipIncentiveId);
            Assert.IsTrue(exist);
        }

        [AfterScenario()]
        public async Task CleanUpIncentives()
        {
            if (testData.ApprenticeshipIncentiveId != Guid.Empty) await DeleteIncentives();
            if (incentiveApplication != null) await DeleteApplicationData();
            await learnerMatchApi.DeleteMapping(testData.ULN, testData.UKPRN);
            await ResetCalendar();
        }

        [BeforeScenario()]
        public async Task InitialCleanup()
        {
            await DeleteIncentive(testData.AccountId, testData.ApprenticeshipId);
            await ResetCalendar();
        }
    }
}
