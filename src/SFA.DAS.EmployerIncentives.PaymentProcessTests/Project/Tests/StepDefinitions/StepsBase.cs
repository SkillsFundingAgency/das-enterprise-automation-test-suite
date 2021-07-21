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
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

// ReSharper disable PossibleInvalidOperationException
// ReSharper disable InconsistentNaming

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    public class StepsBase
    {
        protected Fixture fixture;
        protected readonly DbConfig dbConfig;
        protected readonly EIPaymentProcessConfig eiConfig;
        protected EISqlHelper sqlHelper;
        protected LearnerMatchApiHelper learnerMatchApi;
        protected EILearnerMatchHelper learnerMatchService;
        protected BusinessCentralApiHelper businessCentralApiHelper;
        protected readonly EIServiceBusHelper serviceBusHelper;
        protected readonly EIPaymentsProcessHelper paymentService;
        protected readonly IList<Guid> incentiveIds = new List<Guid>();
        protected IncentiveApplication incentiveApplication;        
        protected long accountId;
        protected long apprenticeshipId;
        protected long UKPRN;
        protected long ULN;
        protected Guid apprenticeshipIncentiveId => incentiveIds.FirstOrDefault();

        private readonly StopWatchHelper _stopWatchHelper;

        protected StepsBase(ScenarioContext context)
        {
            _stopWatchHelper = context.Get<StopWatchHelper>();
            _stopWatchHelper.Start("StepsBase");
            fixture = new Fixture();
            UKPRN = fixture.Create<long>();
            ULN = fixture.Create<long>();

            eiConfig = context.GetEIPaymentProcessConfig<EIPaymentProcessConfig>();
            dbConfig = context.Get<DbConfig>();
            sqlHelper = new EISqlHelper(dbConfig);

            serviceBusHelper = new EIServiceBusHelper(eiConfig);

            learnerMatchApi = new LearnerMatchApiHelper(eiConfig);
            learnerMatchService = new EILearnerMatchHelper(eiConfig);

            businessCentralApiHelper = new BusinessCentralApiHelper(eiConfig);
            paymentService = new EIPaymentsProcessHelper(eiConfig);

            _stopWatchHelper.Stop("StepsBase");
        }

        protected async Task RunLearnerMatchOrchestrator(bool continueOnFailure = false)
        {
            _stopWatchHelper.Start("RunLearnerMatchOrchestrator");
            await learnerMatchService.StartLearnerMatchOrchestrator();

            if (continueOnFailure) await learnerMatchService.WaitUntilStopped();
            else await learnerMatchService.WaitUntilComplete();

            _stopWatchHelper.Stop("RunLearnerMatchOrchestrator");
        }

        protected async Task SubmitIncentiveApplication(IncentiveApplication application)
        {
            _stopWatchHelper.Start("SubmitIncentiveApplication");
            await sqlHelper.CreateAccount(application.AccountId, application.AccountLegalEntityId);
            await sqlHelper.CreateIncentiveApplication(application);

            foreach (var apprenticeship in application.Apprenticeships)
            {
                var command = new CreateIncentiveCommand(
                    application.AccountId,
                    application.AccountLegalEntityId,
                    apprenticeship.Id,
                    apprenticeship.ApprenticeshipId,
                    apprenticeship.FirstName,
                    apprenticeship.LastName,
                    apprenticeship.DateOfBirth,
                    apprenticeship.ULN,
                    apprenticeship.PlannedStartDate,
                    apprenticeship.ApprenticeshipEmployerTypeOnApproval,
                    apprenticeship.UKPRN,
                    application.DateSubmitted.Value,
                    application.SubmittedByEmail,
                    apprenticeship.CourseName,
                    apprenticeship.EmploymentStartDate.Value,
                    apprenticeship.Phase
                );

                await serviceBusHelper.Publish(command);
                var incentiveId = await sqlHelper.GetApprenticeshipIncentiveIdWhenExists(apprenticeship.Id, TimeSpan.FromMinutes(1));
                incentiveIds.Add(incentiveId);
                await sqlHelper.WaitUntilEarningsExist(apprenticeshipIncentiveId, TimeSpan.FromMinutes(1));
            }
            _stopWatchHelper.Stop("SubmitIncentiveApplication");
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

        protected async Task RunPaymentsOrchestrator()
        {
            _stopWatchHelper.Start("RunPaymentsOrchestrator");
            await paymentService.StartPaymentProcessOrchestrator();
            await paymentService.WaitUntilWaitingForPaymentApproval();
            _stopWatchHelper.Stop("RunPaymentsOrchestrator");
        }

        protected async Task RunApprovePaymentsOrchestrator()
        {
            _stopWatchHelper.Start("RunApprovePaymentsOrchestrator");
            await paymentService.ApprovePayments();
            await paymentService.WaitUntilComplete();
            _stopWatchHelper.Stop("RunApprovePaymentsOrchestrator");
        }

        protected async Task SetupBusinessCentralApiToAcceptAllPayments()
        {
            _stopWatchHelper.Start("SetupBusinessCentralApiToAcceptAllPayments");
            await businessCentralApiHelper.SetupAcceptAllRequests();
            _stopWatchHelper.Stop("SetupBusinessCentralApiToAcceptAllPayments");
        }
        protected async Task VerifyLearningRecordsExist()
        {
            var exist = await sqlHelper.VerifyLearningRecordsExist(apprenticeshipIncentiveId);
            Assert.IsTrue(exist);
        }

        protected async Task VerifyPaymentRecordsExist()
        {
            var exist = await sqlHelper.VerifyPaymentRecordsExist(apprenticeshipIncentiveId);
            Assert.IsTrue(exist);
        }

        [AfterScenario()]
        public async Task CleanUpIncentives()
        {
            if (apprenticeshipIncentiveId != Guid.Empty) await DeleteIncentives();
            if (incentiveApplication != null) await DeleteApplicationData();
            await learnerMatchApi.DeleteMapping(ULN, UKPRN);
            await ResetCalendar();
        }

        [BeforeScenario()]
        public async Task InitialCleanup()
        {
            await DeleteIncentive(accountId, apprenticeshipId);
            await ResetCalendar();
        }
    }
}
