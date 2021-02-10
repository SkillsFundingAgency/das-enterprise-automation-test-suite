using NUnit.Framework;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeCommitmentsAPISteps
    {
        private readonly ApprenticeCommitmentsRestClient _restClient;
        private readonly AuthTokenApiRestClient _manageIdentityRestClient;
        private readonly ApprenticeCommitmentSqlHelper _apprenticeCommitmentSqlHelper;
        private readonly ObjectContext _objectContext;

        public ApprenticeCommitmentsAPISteps(ScenarioContext context)
        {
            _restClient = context.GetRestClient<ApprenticeCommitmentsRestClient>();

            _manageIdentityRestClient = context.GetRestClient<AuthTokenApiRestClient>();

            _apprenticeCommitmentSqlHelper = context.Get<ApprenticeCommitmentSqlHelper>();

            _objectContext = context.Get<ObjectContext>();
        }

        [Then(@"das-commitments-api (/ping) endpoint can be accessed")]
        public void ThenDasCommitmentsApiCanBeAccessed(string endpoint)
        {
            var restClient = new CommitmentsInnerApiRestClient(_manageIdentityRestClient);

            restClient.PerformHeathCheck(endpoint);

            var response = restClient.Execute();

            AssertHelper.AssertResponse(HttpStatusCode.OK, response);
        }

        [When(@"an apprenticeship is posted")]
        public void WhenAnApprenticeshipIsPosted()
        {
            var (accountid, apprenticeshipid, firstname, lastname, trainingname, orgname) = _apprenticeCommitmentSqlHelper.GetEmployerData();

            var createApprenticeship = new CreateApprenticeship { EmployerAccountId = accountid, ApprenticeshipId = apprenticeshipid, Organisation = orgname };

            _objectContext.SetAccountId(accountid);
            _objectContext.SetApprenticeshipId(apprenticeshipid);
            _objectContext.SetOrganisationName(orgname);
            _objectContext.SetFirstName(firstname);
            _objectContext.SetLastName(lastname);
            _objectContext.SetTrainingName(trainingname);
            _objectContext.SetEmail(createApprenticeship.Email);

            _restClient.CreateApprenticeship(createApprenticeship);
        }

        [Then(@"the apprentice details are updated in the login db")]
        public void ThenTheApprenticeDetailsAreUpdatedInTheLoginDb()
        {
            var (firstname, lastname) = _apprenticeCommitmentSqlHelper.GetApprenticeLoginData(_objectContext.GetEmail());

            Assert.Multiple(() =>
            {
                Assert.AreEqual(_objectContext.GetFirstName(), firstname, $"Apprentice first name did not match");

                Assert.AreEqual(_objectContext.GetLastName(), lastname, $"Apprentice last name did not match");
            });
        }

        [Then(@"a (OK|BadRequest|Unauthorized|Forbidden|NotFound|Accepted) response is received")]
        public void AResponseIsReceived(HttpStatusCode responsecode)
        {
            var response = _restClient.Execute();

            AssertHelper.AssertResponse(responsecode, response);
        }
    }
}