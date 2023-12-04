using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

[Binding, Scope(Tag = "@aanadmin")]
public class Admin_ChangeEvent_Steps : Admin_CreateEvent_BaseSteps
{
    private CheckYourEventPage checkYourEventPage;

    public Admin_ChangeEvent_Steps(ScenarioContext context) : base(context)
    {

    }

    [When(@"the user should be able to successfully enters all the details for hybrid event")]
    public void TheUserShouldBeAbleToSuccessfullyEntersAllTheDetailsForHybridEvent()
    {
        checkYourEventPage = CheckYourEvent(EventFormat.Hybrid, false, false);
    }

    [When(@"changes the event to an online event")]
    public void ChangesTheEventToAnOnlineEvent()
    {
        var eventFormat = EventFormat.Online;

        checkYourEventPage.ChangeEventFormat().ChangeEventFormat(eventFormat);

        sucessfullyPublisedEventPage = new InPersonOrOnlinePage(context, EventFormat.Online).ContinueToCheckYourEventPage().GoToEventPreviewPage(eventFormat).GoToCheckYourEventPage().SubmitEvent();
    }
}
