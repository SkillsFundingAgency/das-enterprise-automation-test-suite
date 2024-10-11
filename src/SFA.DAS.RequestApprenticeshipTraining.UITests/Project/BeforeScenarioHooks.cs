using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        private readonly ObjectContext _objectcontext = context.Get<ObjectContext>();
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            context.Set(new RoatpV2SqlDataHelper(_objectcontext, _dbConfig));
        }
    }
}
