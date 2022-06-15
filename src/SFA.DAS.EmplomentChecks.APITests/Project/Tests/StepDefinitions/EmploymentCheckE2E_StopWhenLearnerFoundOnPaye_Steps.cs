using NUnit.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmploymentCheckE2E_StopWhenLearnerFoundOnPaye_Steps
    {

        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper;

        public EmploymentCheckE2E_StopWhenLearnerFoundOnPaye_Steps(ScenarioContext context)
        {
            _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
        }

        [When(@"Learner is found to be '([^']*)' on one of the paye schemes")]
        public void WhenLearnerIsFoundToBeOnOneOfThePayeSchemes(bool? employmentstatus)
        {
            var employed = _employmentChecksSqlDbHelper.VerifyEmploymentStatusAgainstPayeScheme(1);

            Assert.AreEqual(employmentstatus, employed, "Employment Status in [Cache].[EmploymentCheckCacheResponse] is incorrect");
        }

        [Then(@"abandon all the remaining paye schemes for the check")]
        public void ThenAbandonAllTheRemainingPayeSchemesForTheCheck()
        {
            // get the Id for the Paye Scheme against which the apprentice is found employed. 
            // 1 parameter rapresents the employmentStatus we want to find

            int requestId = _employmentChecksSqlDbHelper.GetEmploymentCheckCacheRequestId(1);

            // verify that RequestCompletionStatus for this paye is set to 2 [completed]
            int status = _employmentChecksSqlDbHelper.getHmrcRequestCompletionStatus(requestId);

            Assert.AreEqual(2, status, "Completion Status for the first paye scheme is not as expected");

            // verify following Paye Schemes have been abandoned in [Cache].[EmploymentCheckCacheRequest] table

            var completionStatuses = _employmentChecksSqlDbHelper.getHmrcRequestCompletionStatuses(requestId);

            // RequestCompletionstatus 3 represents 'Abandoned' records
            for (int i= 0; i < completionStatuses.Count; i++)
            {
                Assert.AreEqual(3, completionStatuses[i][0], "Completion Status for the abandoned paye scheme is not as expected");
            }

            // verify no subsequest calls have been made to HMRC in [Cache].[EmploymentCheckCacheResponse] table

            int count = _employmentChecksSqlDbHelper.getNumberOfHmrcCallsAfterId(requestId);

            Assert.AreEqual(0, count, $"{count} subsequest call to HMRC were made after the apprentice was found employed on one of the paye schemes");
        }

        [Then(@"continue with the remaining paye schemes for the check")]
        public void ThenContinueWithTheRemainingPayeSchemesForTheCheck()
        {
            // get the Id for the first Paye Scheme against which the apprentice will be found as not employed
            // 0 parameter represents the employmentStatus we want to find

            int requestId = _employmentChecksSqlDbHelper.GetEmploymentCheckCacheRequestId(0);

            // verify that subsequent check for the next paye scheme is not abandoned in [Cache].[EmploymentCheckCacheRequest] table

            var completionStatus = _employmentChecksSqlDbHelper.getHmrcRequestCompletionStatuses(requestId);

            Assert.AreNotEqual(3, completionStatus[0][0], "Completion Status is set to 3 [Abandoned] which is not expected");

            // verify subsequent calls have been made to HMRC in [Cache].[EmploymentCheckCacheResponse] table

            int count = _employmentChecksSqlDbHelper.getNumberOfHmrcCallsAfterId(requestId);

            Assert.Greater(count, 0, " No further calls have been made to HMRC in [Cache].[EmploymentCheckCacheResponse] table");
        }
    }
}
