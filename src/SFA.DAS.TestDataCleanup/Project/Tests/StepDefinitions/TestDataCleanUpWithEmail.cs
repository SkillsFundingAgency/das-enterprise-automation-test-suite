using SFA.DAS.TestDataCleanup.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataCleanup.Project.Tests.StepDefinitions
{
    [Binding]
    public class TestDataCleanUpWithEmail : TestdataCleanupBaseSteps
    {
        public TestDataCleanUpWithEmail(ScenarioContext context) : base(context) { }


        [Then(@"the test data are cleaned up for email (.*)")]
        public void ThenTheTestDataAreCleanedUpForEmail(string email) => CleanUpTestData(email);


        [Then(@"the test data are cleaned up")]
        public void ThenTheTestDataAreCleanedUp() => CleanUpTestData("AP_Test_%05Nov2019%");

        private void CleanUpTestData(string email) => CleanUpTestData(() => new TestDataCleanUpSqlDataHelper(_dbConfig).CleanUpTestData(email));
    }
}
