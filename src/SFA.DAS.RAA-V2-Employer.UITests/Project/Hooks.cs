using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 34)]
        public void SetUpHelpers()
        {
            context.Set(new ProviderPermissionsSqlDbHelper(context.Get<ObjectContext>(), context.Get<DbConfig>()));

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(new RandomCourseDataHelper(), ApprenticeStatus.WaitingToStart);

            context.Set(apprenticeCourseDataHelper);
        }
    }
}
