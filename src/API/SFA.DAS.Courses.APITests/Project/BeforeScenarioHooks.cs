using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Courses.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => context.SetRestClient(new Inner_CoursesApiRestClient(context.Get<ObjectContext>(), context.Get<Inner_ApiFrameworkConfig>()));
    }
}