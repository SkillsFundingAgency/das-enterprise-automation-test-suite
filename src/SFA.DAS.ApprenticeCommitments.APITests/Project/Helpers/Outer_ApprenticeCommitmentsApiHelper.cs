using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class Outer_ApprenticeCommitmentsApiHelper
    {
        private readonly ScenarioContext _context;
        private readonly Outer_ApprenticeCommitmentsApiRestClient _outerApiRestClient;
        private readonly ApprenticeCommitmentsJobs_CreateApprenticeshipClient _apprenticeCommitmentsJobs_CreateApprenticeshipClient;
        private readonly Outer_ApprenticeCommitmentsHealthApiRestClient _outerHealthApiRestClient;
        private readonly AccountsAndCommitmentsSqlHelper _accountsAndCommitmentsSqlHelper;
        private readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;
        private readonly ObjectContext _objectContext;
        protected readonly FrameworkHelpers.RetryAssertHelper _assertHelper;

        internal Outer_ApprenticeCommitmentsApiHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<FrameworkHelpers.RetryAssertHelper>();
            _outerApiRestClient = new Outer_ApprenticeCommitmentsApiRestClient(context.GetOuter_ApiAuthTokenConfig());
            _apprenticeCommitmentsJobs_CreateApprenticeshipClient = new ApprenticeCommitmentsJobs_CreateApprenticeshipClient(context.GetApprenticeCommitmentsJobsAuthTokenConfig());
            _outerHealthApiRestClient = new Outer_ApprenticeCommitmentsHealthApiRestClient();
            _accountsAndCommitmentsSqlHelper = context.Get<AccountsAndCommitmentsSqlHelper>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
        }

        public IRestResponse Ping() => _outerHealthApiRestClient.Ping(HttpStatusCode.OK);

        public IRestResponse CheckHealth() => _outerHealthApiRestClient.CheckHealth(HttpStatusCode.OK);

        protected IRestResponse CreateApprovalsCreatedEvent()
        {
            var (email, accountid, apprenticeshipid, _, _, _, orgname, legalEntityId, providerId, startDate, _, _) = GetEmployerData();

            var createApprenticeship = new ApprovalsCreated
            {
                EmployerAccountId = accountid,
                CommitmentsApprenticeshipId = apprenticeshipid,
                CommitmentsApprovedOn = DateTime.Parse(startDate).ToString("yyyy-MM-dd"),
                Email = email,
                EmployerName = orgname,
                EmployerAccountLegalEntityId = legalEntityId,
                TrainingProviderId = providerId
            };

            return _outerApiRestClient.CreateApprovalsCreatedEvent(createApprenticeship, HttpStatusCode.OK);
        }

        protected IRestResponse CreateApprenticeshipViaCommitmentsJob()
        {
            var (email, accountid, apprenticeshipid, _, _, _, orgname, legalEntityId, providerId, _, _, createdOn) = GetEmployerData();

            var createApprenticeship = new CreateApprenticeshipViaCommitmentsJob
            {
                AccountId = accountid,
                ApprenticeshipId = apprenticeshipid,
                Email = email,
                LegalEntityName = orgname,
                AccountLegalEntityId = legalEntityId,
                ProviderId = providerId,
                CreatedOn = createdOn
            };

            return _apprenticeCommitmentsJobs_CreateApprenticeshipClient.CreateApprenticeshipViaCommitmentsJob(createApprenticeship, HttpStatusCode.Accepted);
        }

        public IRestResponse CreateApprentice()
        {
            var createApprentice = new Apprentice
            {
                ApprenticeId = Guid.NewGuid(),
                DateOfBirth = _objectContext.GetDateOfBirth(),
                FirstName = _objectContext.GetFirstName(),
                LastName = _objectContext.GetLastName(),
                Email = GetApprenticeEmail()
            };

            return _outerApiRestClient.CreateApprentice(createApprentice, HttpStatusCode.OK);
        }

        public IRestResponse CreateApprenticeship()
        {
            var email = GetApprenticeEmail();

            var regId = _aComtSqlDbHelper.GetRegistrationId(email, _context.ScenarioInfo.Title);
                
            var apprenticeId = _aComtSqlDbHelper.GetApprenticeDetails(email).apprenticeId;

            _objectContext.SetApprenticeId(apprenticeId);

            var createApprenticeship = new CreateApprenticeshipFromRegistration
            {
                RegistrationId = regId,
                ApprenticeId = apprenticeId
            };

            return _outerApiRestClient.CreateApprenticeship(createApprenticeship, HttpStatusCode.OK);
        }

        public IRestResponse GetApprenticeships() => _outerApiRestClient.GetApprenticeships(_objectContext.GetApprenticeId(), HttpStatusCode.OK);

        public IRestResponse GetApprenticeship()
        {
            var apprenticeId = _objectContext.GetApprenticeId();

            var commitmentsApprenticeshipId = _aComtSqlDbHelper.GetApprenticeshipId(apprenticeId);

            return _outerApiRestClient.GetApprenticeship(apprenticeId, commitmentsApprenticeshipId, HttpStatusCode.OK);
        }

        private (string email, long accountid, long apprenticeshipid, string firstname, string lastname, string trainingname, string empname, long legalEntityId, long providerId, string startDate, string endDate, string createdOn) GetEmployerData()
        {
            var (accountid, apprenticeshipid, firstname, lastname, dateOfBirth, trainingname, orgname, legalEntityId, providerId, startDate, endDate, createdOn) = _accountsAndCommitmentsSqlHelper.GetCommitmentData();

            var (legalName, tradingName) = _accountsAndCommitmentsSqlHelper.GetProviderData(providerId);

            var email = GetApprenticeEmail();

            _objectContext.SetAccountId(accountid);
            _objectContext.SetCommitmentsApprenticeshipId(apprenticeshipid);
            _objectContext.SetOrganisationName(orgname);
            _objectContext.SetFirstName(firstname);
            _objectContext.SetLastName(lastname);
            _objectContext.SetDateOfBirth(dateOfBirth.Date);
            _objectContext.SetTrainingName(trainingname);
            _objectContext.SetEmployerAccountLegalEntityId(legalEntityId);
            _objectContext.SetProviderName(GetProviderName(tradingName, legalName));
            _objectContext.SetEmployerName(orgname);
            _objectContext.SetTrainingStartDate(startDate);
            _objectContext.SetTrainingEndDate(endDate);

            _accountsAndCommitmentsSqlHelper.UpdateEmailForApprenticeshipRecord(email, apprenticeshipid);

            return (email, accountid, apprenticeshipid, firstname, lastname, trainingname, orgname, legalEntityId, providerId, startDate, endDate, createdOn);
        }

        private string GetApprenticeEmail() => _objectContext.GetApprenticeEmail();

        private string GetProviderName(string tradingName, string legalName) => string.IsNullOrWhiteSpace(tradingName) ? legalName : tradingName;
    }
}