using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Helpers;
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
        private readonly ApprenticeCommitmentSqlHelper _apprenticeCommitmentSqlHelper;
        private readonly ApprenticeCommitmentsSqlDbHelper _apprenticeCommitmentsRegistrationSqlDbHelper;
        private readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;
        private readonly ApprenticeCommitmentsDataHelper _dataHelper;
        private readonly ObjectContext _objectContext;
        private IRestResponse _restResponse;
        protected readonly UI.FrameworkHelpers.AssertHelper _assertHelper;

        internal Outer_ApprenticeCommitmentsApiHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<UI.FrameworkHelpers.AssertHelper>();
            _outerApiRestClient = new Outer_ApprenticeCommitmentsApiRestClient(context.GetOuter_ApiAuthTokenConfig());
            _apprenticeCommitmentSqlHelper = context.Get<ApprenticeCommitmentSqlHelper>();
            _apprenticeCommitmentsRegistrationSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _dataHelper = context.Get<ApprenticeCommitmentsDataHelper>();
        }

        internal void CreateApprenticeship()
        {
            var (accountid, apprenticeshipid, firstname, lastname, trainingname, orgname) = _apprenticeCommitmentSqlHelper.GetEmployerData();

            var createApprenticeship = new CreateApprenticeship { EmployerAccountId = accountid, ApprenticeshipId = apprenticeshipid, Organisation = orgname, Email = GetApprenticeEmail() };

            _objectContext.SetAccountId(accountid);
            _objectContext.SetApprenticeshipId(apprenticeshipid);
            _objectContext.SetOrganisationName(orgname);
            _objectContext.SetFirstName(firstname);
            _objectContext.SetLastName(lastname);
            _objectContext.SetTrainingName(trainingname);
            _outerApiRestClient.CreateApprenticeship(createApprenticeship);

            _restResponse = _outerApiRestClient.Execute();
        }


        internal void VerifyRegistration()
        {
            (string registrationId, string userIdentityid)  = _apprenticeCommitmentsRegistrationSqlDbHelper.GetRegistrationId(GetApprenticeEmail());

            var verifyRegistration = new VerifyIdentityRegistrationCommand
            {
                RegistrationId = registrationId,
                UserIdentityId = userIdentityid,
                FirstName = _objectContext.GetFirstName(),
                LastName = _objectContext.GetLastName(),
                Email = GetApprenticeEmail(),
                DateOfBirth = new DateTime(_dataHelper.DateOfBirthYear, _dataHelper.DateOfBirthMonth, _dataHelper.DateOfBirthDay),
                NationalInsuranceNumber = _dataHelper.NationalInsuranceNumber
            };

            _outerApiRestClient.VerifyRegistration(verifyRegistration);

            _restResponse = _outerApiRestClient.Execute();
        }


        internal void AssertResponse(HttpStatusCode expected) => AssertHelper.AssertResponse(expected, _restResponse);

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

        private string GetApprenticeEmail() => _objectContext.GetApprenticeEmail();
    }
}