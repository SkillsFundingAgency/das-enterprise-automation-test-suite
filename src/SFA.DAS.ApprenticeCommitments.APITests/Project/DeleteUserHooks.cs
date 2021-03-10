using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    [Binding, Scope(Tag = "deleteuser")]
    public class DeleteUserHooks : DeleteBaseHooks
    {
        public DeleteUserHooks(ScenarioContext context) : base(context) { }

        [AfterScenario(Order = 33)]
        public void ClearDownData() => ClearDownUser();
    }
}
