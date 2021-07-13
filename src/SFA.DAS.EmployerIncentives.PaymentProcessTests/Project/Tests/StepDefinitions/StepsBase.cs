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
        protected Guid apprenticeshipIncentiveId = Guid.Empty;
        protected IncentiveApplication incentiveApplication;
        protected (byte Number, short Year) activePaymentPeriod;
        private readonly Stopwatch _stopwatch;
        protected long accountId;
        protected long apprenticeshipId;
        protected long UKPRN;
        protected long ULN;

        protected StepsBase(ScenarioContext context)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
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

            Console.WriteLine($@"[StepsBase] initialised in {_stopwatch.Elapsed.Milliseconds} ms");
        }

        protected async Task RunLearnerMatchOrchestrator()
        {
            StartStopWatch("RunLearnerMatchOrchestrator");
            await learnerMatchService.StartLearnerMatchOrchestrator();
            await learnerMatchService.WaitUntilComplete();
            StopStopWatch("RunLearnerMatchOrchestrator");
        }

        protected void StartStopWatch(string caller)
        {
            _stopwatch.Restart();
            Console.WriteLine($@"[{caller}] started");
        }

        protected void StopStopWatch(string caller)
        {
            Console.WriteLine($@"[{caller}] finished in {_stopwatch.ElapsedMilliseconds} ms");
        }

        protected async Task SetActiveCollectionPeriod(byte periodNumber, short academicYear)
        {
            activePaymentPeriod.Number = periodNumber;
            activePaymentPeriod.Year = academicYear;

            StartStopWatch("SetActiveCollectionPeriod");
            await sqlHelper.SetActiveCollectionPeriod(periodNumber, academicYear);
            StopStopWatch("SetActiveCollectionPeriod");
        }

        protected async Task SubmitIncentiveApplication(IncentiveApplication application)
        {
            StartStopWatch("SubmitIncentiveApplication");
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
                apprenticeshipIncentiveId = await sqlHelper.GetApprenticeshipIncentiveIdWhenExists(apprenticeship.Id, TimeSpan.FromMinutes(1));
                await sqlHelper.WaitUntilEarningsExist(apprenticeshipIncentiveId, TimeSpan.FromMinutes(1));
            }
            StopStopWatch("SubmitIncentiveApplication");
        }

        protected async Task DeleteApplicationData()
        {
            StartStopWatch("DeleteApplicationData");
            await sqlHelper.DeleteApplicationData(incentiveApplication.Id);
            StopStopWatch("DeleteApplicationData");
        }

        protected async Task DeleteIncentives()
        {
            StartStopWatch("DeleteIncentiveData");
            foreach (var apprenticeship in incentiveApplication.Apprenticeships)
            {
                await DeleteIncentive(incentiveApplication.AccountId, apprenticeship.ApprenticeshipId);
            }
            StopStopWatch("DeleteIncentiveData");
        }

        private async Task DeleteIncentive(long accountId, long apprenticeshipId)
        {
            await sqlHelper.DeleteIncentiveData(accountId, apprenticeshipId);
        }

        private async Task ResetCalendar()
        {
            await sqlHelper.ResetCalendar();
        }

        protected async Task SetupLearnerMatchApiResponse(long uln, long ukprn, string json)
        {
            StartStopWatch("SetupLearnerMatchApiResponse");
            await learnerMatchApi.SetupResponse(uln, ukprn, json);
            StopStopWatch("SetupLearnerMatchApiResponse");
        }

        protected async Task SetupLearnerMatchApiResponse(long uln, long ukprn, LearnerSubmissionDto data)
        {
            StartStopWatch("SetupLearnerMatchApiResponse");
            await learnerMatchApi.SetupResponse(uln, ukprn, data);
            StopStopWatch("SetupLearnerMatchApiResponse");
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
            StartStopWatch("RunPaymentsOrchestrator");
            await paymentService.StartPaymentProcessOrchestrator();
            await paymentService.WaitUntilWaitingForPaymentApproval();
            StopStopWatch("RunPaymentsOrchestrator");
        }

        protected async Task RunApprovePaymentsOrchestrator()
        {
            StartStopWatch("RunApprovePaymentsOrchestrator");
            await paymentService.ApprovePayments();
            await paymentService.WaitUntilComplete();
            StopStopWatch("RunApprovePaymentsOrchestrator");
        }

        protected async Task SetupBusinessCentralApiToAcceptAllPayments()
        {
            StartStopWatch("SetupBusinessCentralApiToAcceptAllPayments");
            await businessCentralApiHelper.SetupAcceptAllRequests();
            StopStopWatch("SetupBusinessCentralApiToAcceptAllPayments");
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
