using NUnit.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmploymentCheckE2E_StopWhenLearnerFoundOnPaye_Steps
    {

        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper;
        private ScenarioContext _context;

        public EmploymentCheckE2E_StopWhenLearnerFoundOnPaye_Steps(ScenarioContext context)
        {
            _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
            _context = context;
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

            // verify following Paye Schemes have been abandoned in [Cache].[EmploymentCheckCacheRequest] table

            var completionStatus = _employmentChecksSqlDbHelper.getRequestCompletionStatuses(requestId);

            for (int i= 0; i < completionStatus.Count; i++)
            {
                Assert.AreEqual(20, completionStatus[i][0], "Completion Status is not as expected");
            }

            // verify no subsequest calls have been made to HMRC in [Cache].[EmploymentCheckCacheResponse] table

            int count = _employmentChecksSqlDbHelper.getNumberOfHmrcCallsAfterId(requestId);

            Assert.AreEqual(0, count, $"{count} subsequest call to HMRC were made after the apprentice was found employed on one of the paye schemes");
        }

        [Then(@"contnue with the remaining paye schemes for the check")]
        public void ThenContnueWithTheRemainingPayeSchemesForTheCheck()
        {
            // get the Id for the first Paye Scheme against which the apprentice will be found as not emplyed
            // 0 parameter rapresents the employmentStatus we want to find

            int requestId = _employmentChecksSqlDbHelper.GetEmploymentCheckCacheRequestId(0);

            // verify that subsequest check for the next paye scheme is not abandoned in [Cache].[EmploymentCheckCacheRequest] table

            var completionStatus = _employmentChecksSqlDbHelper.getRequestCompletionStatuses(requestId);

            Assert.AreNotEqual(20, completionStatus[0][0], "Completion Status is set to 20 [Abandoned] which is not expected");

            // verify subsequest calls have been made to HMRC in [Cache].[EmploymentCheckCacheResponse] table

            int count = _employmentChecksSqlDbHelper.getNumberOfHmrcCallsAfterId(requestId);

            Assert.Greater(count, 0, " No further calls have been made to HMRC in [Cache].[EmploymentCheckCacheResponse] table");
        }
    }
}
