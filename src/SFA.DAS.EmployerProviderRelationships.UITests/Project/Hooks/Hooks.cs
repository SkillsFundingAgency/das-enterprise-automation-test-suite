using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Hooks
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
    //    [AfterScenario(Order = 22)]
    //    [Scope(Tag = "deletepermission")]
    //    public void DeleteProviderRelationA() => context.Get<TryCatchExceptionHelper>().AfterScenarioException(() => new DeleteProviderRelationinDbHelper(context).DeleteProviderRelation());
    }
}
