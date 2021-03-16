using SFA.DAS.API.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeCommitmentsAPISteps
    {
        private readonly ApprenticeCommitmentsApiHelper _apprenticeCommitmentsApiHelper;
        private readonly Inner_CommitmentsApiRestClient _innerApiRestClient;
        private readonly AccountsAndCommitmentsSqlHelper _apprenticeCommitmentSqlHelper;

        public ApprenticeCommitmentsAPISteps(ScenarioContext context)
        {
            _apprenticeCommitmentsApiHelper = new ApprenticeCommitmentsApiHelper(context);

            _innerApiRestClient = context.GetRestClient<Inner_CommitmentsApiRestClient>();

            _apprenticeCommitmentSqlHelper = context.Get<AccountsAndCommitmentsSqlHelper>();
        }

        [Then(@"the apprenticeship records can be fetched")]
        public void ThenTheApprenticeshipRecordsCanBeFetched() => _apprenticeCommitmentsApiHelper.GetApprenticeships();

        [Then(@"the apprenticeship record can be fetched")]
        public void ThenTheApprenticeshipRecordCanBeFetched() => _apprenticeCommitmentsApiHelper.GetApprenticeship();

        [Given(@"an apprentice has created an account")]
        public void GivenAnApprenticeHasCreatedAnAccount()
        {
            _apprenticeCommitmentsApiHelper.CreateApprenticeship();

            _apprenticeCommitmentsApiHelper.VerifyRegistration();
        }

        [Then(@"the apprentice can change their email address")]
        public void ThenTheApprenticeCanChangeTheirEmailAddress()
        {
            _apprenticeCommitmentsApiHelper.ChangeApprenticeEmailAddress();

            _apprenticeCommitmentsApiHelper.AssertApprenticeEmailUpdated();
        }

        [Then(@"das-commitments-api endpoint can be accessed")]
        public void ThenDasCommitmentsApiCanBeAccessed()
        {
            var (_, apprenticeshipid, _, _, _, _, _) = _apprenticeCommitmentSqlHelper.GetEmployerData();

            _innerApiRestClient.GetApprenticeship(apprenticeshipid, HttpStatusCode.OK);
        }

        [When(@"an apprenticeship is posted")]
        public void WhenAnApprenticeshipIsPosted() => _apprenticeCommitmentsApiHelper.CreateApprenticeship();

        [Then(@"the apprentice details are updated in the login db")]
        public void ThenTheApprenticeDetailsAreUpdatedInTheLoginDb() => _apprenticeCommitmentsApiHelper.AssertApprenticeLoginData();
    }
}