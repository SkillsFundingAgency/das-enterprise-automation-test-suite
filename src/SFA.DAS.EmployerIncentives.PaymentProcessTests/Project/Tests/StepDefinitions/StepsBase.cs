using AutoFixture;
using Dapper.Contrib.Extensions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Messages;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
// ReSharper disable PossibleInvalidOperationException

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    public class StepsBase
    {
        protected Fixture fixture;
        protected EIConfig eiConfig;
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

        protected StepsBase(ScenarioContext context)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            fixture = new Fixture();
            eiConfig = context.GetEIConfig<EIConfig>();
            sqlHelper = new EISqlHelper(eiConfig);

            var config = context.Get<FrameworkConfig>();
            serviceBusHelper = new EIServiceBusHelper(config.NServiceBusConfig);

            learnerMatchApi = new LearnerMatchApiHelper();
            learnerMatchService = new EILearnerMatchHelper(eiConfig);

            businessCentralApiHelper = new BusinessCentralApiHelper();
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
                    apprenticeship.CourseName
                );

                await serviceBusHelper.Publish(command);
                apprenticeshipIncentiveId = await sqlHelper.GetApprenticeshipIncentiveIdWhenExists(apprenticeship.Id, TimeSpan.FromMinutes(5));
                await sqlHelper.WaitUntilEarningsExist(apprenticeshipIncentiveId, TimeSpan.FromMinutes(5));
            }
            StopStopWatch("SubmitIncentiveApplication");
        }

        protected async Task DeleteApplicationData()
        {
            StartStopWatch("DeleteApplicationData");
            await sqlHelper.DeleteApplicationData(incentiveApplication.Id);
            StopStopWatch("DeleteApplicationData");
        }

        protected async Task DeleteIncentive()
        {
            StartStopWatch("DeleteIncentiveData");
            await sqlHelper.DeleteIncentiveData(apprenticeshipIncentiveId);
            StopStopWatch("DeleteIncentiveData");
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
            await paymentService.StartPaymentProcessOrchestrator(activePaymentPeriod.Year, activePaymentPeriod.Number);
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

        [AfterScenario()]
        protected async Task CleanUpIncentives()
        {
            if (apprenticeshipIncentiveId != Guid.Empty) await DeleteIncentive();
            if (incentiveApplication != null) await DeleteApplicationData();
        }
    }
}
