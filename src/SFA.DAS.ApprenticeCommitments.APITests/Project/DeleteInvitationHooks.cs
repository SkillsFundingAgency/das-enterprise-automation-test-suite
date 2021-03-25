using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    [Binding, Scope(Tag = "deleteinvitation")]
    public class DeleteInvitationHooks : DataClearDownHooks
    {
        public DeleteInvitationHooks(ScenarioContext context) : base(context) { }

        [AfterScenario(Order = 32)]
        public void ClearDownData() => ClearDownInvitation();
    }
}
