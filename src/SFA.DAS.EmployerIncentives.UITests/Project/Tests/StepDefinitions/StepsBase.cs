using AutoFixture;
using Dapper.Contrib.Extensions;
using SFA.DAS.EmployerIncentives.UITests.Messages;
using SFA.DAS.EmployerIncentives.UITests.Models;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
// ReSharper disable PossibleInvalidOperationException

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    public class StepsBase
    {
        protected Fixture fixture;
        protected EIConfig config;
        protected EISqlHelper sqlHelper;
        protected LearnerMatchApiHelper learnerMatchApi;
        protected EILearnerMatchHelper learnerMatchService;
        protected BusinessCentralApiHelper businessCentralApiHelper;
        protected IncentiveApplicationBuilder incentiveApplicationBuilder;
        protected readonly EIServiceBusHelper serviceBusHelper;
        protected readonly EIPaymentsProcessHelper paymentService;


        protected StepsBase(ScenarioContext context)
        {
            fixture = new Fixture();
            config = context.GetEIConfig<EIConfig>();
            sqlHelper = new EISqlHelper(config);
            serviceBusHelper = new EIServiceBusHelper(config);

            learnerMatchApi = new LearnerMatchApiHelper(config);
            learnerMatchService = new EILearnerMatchHelper(config);

            businessCentralApiHelper = new BusinessCentralApiHelper(config);
            paymentService = new EIPaymentsProcessHelper(config);

            incentiveApplicationBuilder = new IncentiveApplicationBuilder();
        }

        protected async Task RunLearnerMatchOrchestrator()
        {
            await learnerMatchService.StartLearnerMatchOrchestrator();
            await learnerMatchService.WaitUntilComplete();
        }

        protected async Task SetActiveCollectionPeriod(byte periodNumber, short academicYear)
        {
            await sqlHelper.SetActiveCollectionPeriod(periodNumber, academicYear);
        }

        protected async Task<Guid> Submit(IncentiveApplication application)
        {
            await sqlHelper.CreateAccount(application.AccountId, application.AccountLegalEntityId);
            await sqlHelper.CreateIncentiveApplication(application);
            var apprenticeshipIncentiveId = Guid.Empty;

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
                apprenticeshipIncentiveId = await sqlHelper.GetApprenticeshipIncentiveIdWhenExists(apprenticeship.Id, TimeSpan.FromMinutes(1));
                await sqlHelper.WaitUntilEarningsExist(apprenticeshipIncentiveId, TimeSpan.FromMinutes(1));
            }

            return apprenticeshipIncentiveId;
        }

        protected async Task CleanUpIncentives()
        {
            await sqlHelper.CleanUpIncentives();
        }

        protected async Task<StepsBase> SetupLearnerMatchApiResponse(long uln, long ukprn, string json)
        {
            await learnerMatchApi.SetupResponse(uln, ukprn, json);
            return this;
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

        protected async Task RunPaymentsOrchestrator(short paymentPeriodYear, byte paymentPeriodNumber)
        {
            await paymentService.StartPaymentProcessOrchestrator(paymentPeriodYear, paymentPeriodNumber);
            await paymentService.WaitUntilWaitingForPaymentApproval();
        }

        protected async Task RunApprovePaymentsOrchestrator()
        {
            await paymentService.ApprovePayments();
            await paymentService.WaitUntilComplete();
        }

        protected async Task SetupBusinessCentralApiToAcceptAllPayments()
        {
            await businessCentralApiHelper.SetupAcceptAllRequests();
        }
    }
}
