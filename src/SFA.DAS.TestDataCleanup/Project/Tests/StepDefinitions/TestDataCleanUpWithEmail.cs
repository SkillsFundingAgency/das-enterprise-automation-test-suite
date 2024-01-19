namespace SFA.DAS.TestDataCleanup.Project.Tests.StepDefinitions;

[Binding]
public class TestDataCleanUpWithEmail(ScenarioContext context)
{
    private readonly TestdataCleanupStepsHelper _testDataCleanUpStepsHelper = new(context);

    [Then(@"the test data are cleaned up for email (.*)")]
    public void ThenTheTestDataAreCleanedUpForEmail(string email) => CleanUpTestData(email);

    [Then(@"the test data are cleaned up")]
    public void ThenTheTestDataAreCleanedUp() => CleanUpTestData("AP_Test_101_21Nov2019%");

    private void CleanUpTestData(string email) => _testDataCleanUpStepsHelper.CleanUpAllDbTestData(email);
}
