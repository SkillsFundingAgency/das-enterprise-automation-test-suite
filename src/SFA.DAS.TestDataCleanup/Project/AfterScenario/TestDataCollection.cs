using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataCleanup.Project.AfterScenario
{
    [Binding]
    public class TestDataCollection
    {
        private readonly ObjectContext _objectContext;

        public TestDataCollection(ScenarioContext context) => _objectContext = context.Get<ObjectContext>();

        [AfterScenario(Order = 10)]
        public void AfterScenario_ReportTestData() => new ReportTestDataHelper().ReportTestData(_objectContext.GetDirectory(), _objectContext.GetAll());
    }
}