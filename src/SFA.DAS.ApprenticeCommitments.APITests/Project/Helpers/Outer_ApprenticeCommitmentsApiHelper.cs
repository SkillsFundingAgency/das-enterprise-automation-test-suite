using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class Outer_ApprenticeCommitmentsApiHelper
    {
        private readonly Outer_ApprenticeCommitmentsApiRestClient _outerApiRestClient;
        private readonly ApprenticeCommitmentSqlHelper _apprenticeCommitmentSqlHelper;
        private readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;
        private readonly ObjectContext _objectContext;
        private IRestResponse _restResponse;
        protected readonly UI.FrameworkHelpers.AssertHelper _assertHelper;

        internal Outer_ApprenticeCommitmentsApiHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<UI.FrameworkHelpers.AssertHelper>();
            _outerApiRestClient = new Outer_ApprenticeCommitmentsApiRestClient(context.GetOuter_ApiAuthTokenConfig());
            _apprenticeCommitmentSqlHelper = context.Get<ApprenticeCommitmentSqlHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
        }

        internal void CreateApprenticeship()
        {
            var (accountid, apprenticeshipid, firstname, lastname, trainingname, orgname) = _apprenticeCommitmentSqlHelper.GetEmployerData();

            var createApprenticeship = new CreateApprenticeship { EmployerAccountId = accountid, ApprenticeshipId = apprenticeshipid, Organisation = orgname, Email = _objectContext.GetApprenticeEmail() };

            _objectContext.SetAccountId(accountid);
            _objectContext.SetApprenticeshipId(apprenticeshipid);
            _objectContext.SetOrganisationName(orgname);
            _objectContext.SetFirstName(firstname);
            _objectContext.SetLastName(lastname);
            _objectContext.SetTrainingName(trainingname);
            _outerApiRestClient.CreateApprenticeship(createApprenticeship);

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
    }
}