namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;


[Binding, Scope(Tag = "@aanadmin")]
public class Admin_CreateEvent_Steps : Admin_CreateEvent_BaseSteps
{
    public Admin_CreateEvent_Steps(ScenarioContext context) : base(context)
    {

    }

    [When(@"the user should be able to successfully create hybrid school event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateHybridSchoolEvent() => SubmitHybridEvent(true, true);

    [When(@"the user should be able to successfully create hybrid event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateHybridEvent() => SubmitHybridEvent(false, false);

    [When(@"the user should be able to successfully create inperson event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateInpersonEvent() => SubmitInPersonEvent(true, false);

    [When(@"the user should be able to successfully create inperson school event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateInpersonSchoolEvent() => SubmitInPersonEvent(false, true);

    [When(@"the user should be able to successfully create online event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateOnlineEvent() => SubmitOnlineEvent(true);

    [Then(@"the user should be able to successfully cancel event")]
    public void TheUserShouldBeAbleToSuccessfullyCancelEvent()
    {
        sucessfullyPublisedEventPage.AccessManageEvents().FilterEventBy(aanAdminDatahelper).CancelEvent().CancelEvent();
    }
}
