using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Helpers;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.AssessorCertification.APITests.Project.Helpers.SqlDbHelpers;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.AssessorCertification.APITests.Project.StepDefinitions
{
    [Binding]
    public class RecordAssessmentOutcomesSteps
    {
        private readonly Outer_AssessorCertificationApiRestClient _restClient;
        private readonly AssessorCertificationSqlDbHelper _assessorCertificationSqlDbHelper;

   


        public RecordAssessmentOutcomesSteps(ScenarioContext context)
        {
            _restClient = context.GetRestClient<Outer_AssessorCertificationApiRestClient>();
            _assessorCertificationSqlDbHelper = context.Get<AssessorCertificationSqlDbHelper>();
           
        }
        string contextUln;
        [Given(@"the user prepares payload with uln (.*)")]
        public void GivenTheUserPreparesPayloadWithUln(string uln)
        {
            _assessorCertificationSqlDbHelper.DeleteCertificate(uln);
            contextUln = uln;
        }

        [Given(@"the user prepares request with uln (.*)")]
        public void GivenTheUserPreparesRequestWithForUln(string uln)
        {
            contextUln = uln;
        }

        [Given(@"the user prepares request for submission with uln (.*)")]
        public void GivenTheUserPreparesRequestForSubmissionWithUln(string uln)
        {
            _assessorCertificationSqlDbHelper.UpdateCertificateStatusToDraft(uln);
            contextUln = uln;
        }




        [When(@"the user sends (GET|POST|PUT|DELETE) request to (.*) with payload (.*)")]
        public void TheUserSendsRequestTo(Method method, string endppoint, string payload) => CreateRestRequest(method, endppoint, payload);

        IRestResponse restResponse = null;

        [Then(@"a (OK|BadRequest|Unauthorized|Forbidden|NotFound|Accepted|NoContent) response is received")]
        public void AResponseIsReceived(HttpStatusCode responsecode)
        {
            restResponse = _restClient.Execute(responsecode);
        }

        [Then(@"the EPARefNumber in the response is same as in the Certificates table in the database")]
        public void ThenTheEPARefNumberInTheResponseIsSameAsInTheCertificatesTableInTheDatabase()
        {
            var actualEPARef = _assessorCertificationSqlDbHelper.GetEPAreferenceAfterAPI(contextUln);

            Assert.True(restResponse.Content.ToString().Contains(actualEPARef), "Value is not contained in response");
            
        }

        [Then(@"the CertificateReference in the response is same as in the Certificates table in the database")]
        public void ThenTheCertificateReferenceInTheResponseIsSameAsInTheCertificatesTableInTheDatabase()
        {
            var actualCertRef = _assessorCertificationSqlDbHelper.GetEPAreferenceAfterAPI(contextUln);

            Assert.True(restResponse.Content.ToString().Contains(actualCertRef), "Value is not contained in response");
        }

        [Then(@"the status in the Certificates Table in database is (.*)")]
        public void ThenTheStatusInTheCertificatesTableInDatabaseIsDeleted(string status)
        {
            var certStatus = _assessorCertificationSqlDbHelper.GetCertificateStatus(contextUln);

            Assert.True(status.Equals(certStatus), "Certificated Status is not the expected value");
        }

        [Then(@"Action in the Certificatelog is (.*)")]
        public void ThenActionInTheCertificatelogIsAmend(string Action)
        {
            var certLogAction = _assessorCertificationSqlDbHelper.GetCertificateLogAction(contextUln);

            Assert.True(Action.Equals(certLogAction), "Certificated Status is not the expected value");
        }

        [Then(@"the Learner ULn in the response is same as Uln in the Ilrs table in the database")]
        public void ThenTheLearnerULnInTheResponseIsSameAsUlnInTheIlrsTableInTheDatabase()
        {
            var learnerUln = _assessorCertificationSqlDbHelper.GetLearnerUln(contextUln);

            Assert.True(restResponse.Content.ToString().Contains(learnerUln), "Learner Uln is not the expected value");
        }

        [Then(@"the currentStatus in the response message is (.*)")]
        public void ThenTheCurrentStatusInTheResponseMessageIsSubmitted(string currentStatus)
        {
           Assert.True(restResponse.Content.ToString().Contains(currentStatus), "Current Status is not the expected value");
        }


        private void CreateRestRequest(Method method, string endppoint, string payload) => _restClient.CreateRestRequest(method, endppoint, payload);
    }
}
