namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

[Binding, Scope(Tag = "@aanadmin")]
public class Admin_CreateEvent_DBSteps : Admin_CreateEvent_BaseSteps
{
    public Admin_CreateEvent_DBSteps(ScenarioContext context) : base(context)
    {

    }


    [Then(@"the system should confirm the event creation")]
    public void TheSystemShouldConfirmTheEventCreation() => objectContext.SetAanAdminEventId(AssertEventStatus(true));

    [Then(@"the system should confirm the event cancellation")]
    public void TheSystemShouldConfirmTheEventCancellation() => AssertEventStatus(false);

}