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
        private readonly Outer_ApprenticeCommitmentsApiRestClient _outerApiRestClient;
        private readonly ApprenticeCommitmentsJobs_CreateApprenticeshipClient _apprenticeCommitmentsJobs_CreateApprenticeshipClient;
        private readonly Outer_ApprenticeCommitmentsHealthApiRestClient _outerHealthApiRestClient;
        private readonly AccountsAndCommitmentsSqlHelper _accountsAndCommitmentsSqlHelper;
        private readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;
        private readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;
        private readonly ApprenticeCommitmentsDataHelper _dataHelper;
        private readonly ObjectContext _objectContext;
        protected readonly UI.FrameworkHelpers.RetryAssertHelper _assertHelper;

        internal Outer_ApprenticeCommitmentsApiHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<UI.FrameworkHelpers.RetryAssertHelper>();
            _outerApiRestClient = new Outer_ApprenticeCommitmentsApiRestClient(context.GetOuter_ApiAuthTokenConfig());
            _apprenticeCommitmentsJobs_CreateApprenticeshipClient = new ApprenticeCommitmentsJobs_CreateApprenticeshipClient(context.GetApprenticeCommitmentsJobsAuthTokenConfig());
            _outerHealthApiRestClient = new Outer_ApprenticeCommitmentsHealthApiRestClient();
            _accountsAndCommitmentsSqlHelper = context.Get<AccountsAndCommitmentsSqlHelper>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _dataHelper = context.Get<ApprenticeCommitmentsDataHelper>();
        }

        public IRestResponse Ping() => _outerHealthApiRestClient.Ping(HttpStatusCode.OK);

        public IRestResponse CheckHealth() => _outerHealthApiRestClient.CheckHealth(HttpStatusCode.OK);

        protected IRestResponse CreateApprenticeshipViaApi()
        {
            var (email, accountid, apprenticeshipid, _, _, _, orgname, legalEntityId, providerId, startDate, _, _) = GetEmployerData();

            var createApprenticeship = new CreateApprenticeshipViaApi
            {
                EmployerAccountId = accountid,
                CommitmentsApprenticeshipId = apprenticeshipid,
                CommitmentsApprovedOn = DateTime.Parse(startDate).ToString("yyyy-MM-dd"),
                Email = email,
                EmployerName = orgname,
                EmployerAccountLegalEntityId = legalEntityId,
                TrainingProviderId = providerId
            };

            return _outerApiRestClient.CreateApprenticeshipViaApi(createApprenticeship, HttpStatusCode.Accepted);
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

        public IRestResponse VerifyIdentity()
        {
            (string apprenticeId, _)  = _aComtSqlDbHelper.GetRegistrationId(GetApprenticeEmail());

            var verifyIdentity = new VerifyIdentityRegistrationCommand
            {
                ApprenticeId = apprenticeId,
                UserIdentityId = apprenticeId,
                FirstName = _objectContext.GetFirstName(),
                LastName = _objectContext.GetLastName(),
                Email = GetApprenticeEmail(),
                DateOfBirth = _objectContext.GetDateOfBirth(),
            };

            return _outerApiRestClient.VerifyIdentity(verifyIdentity, HttpStatusCode.OK);
        }

        public IRestResponse ChangeApprenticeEmailAddress()
        {
            var apprenticeId = _aComtSqlDbHelper.GetApprenticeId(GetApprenticeEmail());

            _objectContext.SetApprenticeId(apprenticeId);

            var changeEmailRequest = new ApprenticeEmailAddressRequest
            {
                Email = _dataHelper.NewEmail
            };

            return _outerApiRestClient.ChangeApprenticeEmailAddress(apprenticeId, changeEmailRequest, HttpStatusCode.OK);
        }

        public IRestResponse GetApprenticeships()
        {
            var apprenticeId = _aComtSqlDbHelper.GetApprenticeId(GetApprenticeEmail());

            _objectContext.SetApprenticeId(apprenticeId);

            return _outerApiRestClient.GetApprenticeships(apprenticeId, HttpStatusCode.OK);
        }

        public IRestResponse GetApprenticeship()
        {
            var apprenticeId = _aComtSqlDbHelper.GetApprenticeId(GetApprenticeEmail());

            var commitmentsApprenticeshipId = _aComtSqlDbHelper.GetApprenticeshipId(apprenticeId);

            _objectContext.SetApprenticeId(apprenticeId);

            return _outerApiRestClient.GetApprenticeship(apprenticeId, commitmentsApprenticeshipId, HttpStatusCode.OK);
        }

        internal void AssertApprenticeEmailUpdated()
        {
            _assertHelper.RetryOnNUnitException(() =>
            {
                var email = _aComtSqlDbHelper.GetApprenticeEmail(_objectContext.GetApprenticeId());

                Assert.AreEqual(_dataHelper.NewEmail, email, $"Apprentice new email did not match");
            });
        }

        internal void AssertApprenticeLoginData()
        {
            _assertHelper.RetryOnNUnitException(() => 
            {
                var (firstname, lastname) = _apprenticeLoginSqlDbHelper.GetApprenticeLoginData(_objectContext.GetApprenticeEmail());

                Assert.Multiple(() =>
                {
                    Assert.AreEqual(_objectContext.GetFirstName(), firstname, $"Apprentice first name did not match");

                    Assert.AreEqual(_objectContext.GetLastName(), lastname, $"Apprentice last name did not match");
                });
            });
        }

        private (string email, long accountid, long apprenticeshipid, string firstname, string lastname, string trainingname, string empname, long legalEntityId, long providerId, string startDate, string endDate, string createdOn) GetEmployerData()
        {
            var (accountid, apprenticeshipid, firstname, lastname, dateOfBirth, trainingname, orgname, legalEntityId, providerId, startDate, endDate, createdOn) = _accountsAndCommitmentsSqlHelper.GetEmployerData();

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