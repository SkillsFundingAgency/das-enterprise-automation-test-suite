using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeCommitmentsAPISteps
    {
        private readonly OuterApiRestClient _restClient;
        private readonly ManageIdentityRestClient _manageIdentityRestClient;
        private readonly ApprenticeCommitmentSqlHelper _apprenticeCommitmentSqlHelper;
        private readonly ObjectContext _objectContext;

        public ApprenticeCommitmentsAPISteps(ScenarioContext context)
        {
            _restClient = context.GetRestClient<OuterApiRestClient>();

            _manageIdentityRestClient = context.GetRestClient<ManageIdentityRestClient>();

            _apprenticeCommitmentSqlHelper = context.Get<ApprenticeCommitmentSqlHelper>();

            _objectContext = context.Get<ObjectContext>();
        }

        [Then(@"I can access das commitments api")]
        public void ThenICanAccessDasCommitmentsApi()
        {
            _manageIdentityRestClient.GetAuthToken();
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

            var payload = JsonHelper.Serialize(createApprenticeship);

            _restClient.CreateRestRequest(Method.POST, "/apprenticeships", payload);
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
    }
}