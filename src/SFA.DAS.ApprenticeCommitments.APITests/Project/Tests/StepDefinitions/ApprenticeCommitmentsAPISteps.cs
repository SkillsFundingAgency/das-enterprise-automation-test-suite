using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeCommitmentsAPISteps
    {
        private readonly FrameworkRestClient _restClient;
        private readonly ApprenticeCommitmentSqlHelper _apprenticeCommitmentSqlHelper;
        private readonly ObjectContext _objectContext;

        public ApprenticeCommitmentsAPISteps(ScenarioContext context)
        {
            _restClient = context.GetRestClient<FrameworkRestClient>();

            _apprenticeCommitmentSqlHelper = context.Get<ApprenticeCommitmentSqlHelper>();

            _objectContext = context.Get<ObjectContext>();
        }

        [When(@"an apprenticeship is posted")]
        public void WhenAnApprenticeshipIsPosted()
        {
            var (accountid, apprenticeshipid, orgname) = _apprenticeCommitmentSqlHelper.GetEmployerData();

            var createApprenticeship = new CreateApprenticeship { EmployerAccountId = accountid, ApprenticeshipId = apprenticeshipid, Organisation = orgname };

            _objectContext.SetAccountId(accountid);
            _objectContext.SetApprenticeshipId(apprenticeshipid);
            _objectContext.SetOrganisationName(orgname);
            _objectContext.SetEmail(createApprenticeship.Email);

            var payload = JsonHelper.Serialize(createApprenticeship);

            _restClient.CreateRestRequest(Method.POST, "/apprenticeships", payload);
        }
    }
}