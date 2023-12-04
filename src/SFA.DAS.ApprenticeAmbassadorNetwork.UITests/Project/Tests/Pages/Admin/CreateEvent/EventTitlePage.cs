namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventTitlePage : AanAdminBasePage
{
    protected override string PageTitle => "Event title";

    private static By EventTitleSelector => By.CssSelector("#eventTitle");

    public EventTitlePage(ScenarioContext context) : base(context) { }

    public EventOutlinePage SubmitEventTitle()
    {
        EnterEventTitle(aanAdminCreateEventDatahelper);

        return new(context);
    }

    public CheckYourEventPage UpdateEventTitle()
    {
        EnterEventTitle(aanAdminUpdateEventDatahelper);

        return new(context);
    }

    private void EnterEventTitle(AanAdminCreateEventBaseDatahelper dataHelper)
    {
        string eventTitle = dataHelper.EventTitle;

        formCompletionHelper.EnterText(EventTitleSelector, eventTitle);

        objectContext.SetAanEventTitle(eventTitle);

        var eventType = SelectRandomOption("#EventTypeId");

        var eventRegion = SelectRandomOption("#EventRegionId");

        dataHelper.SetEventTypeAndRegion(eventType, eventRegion);

        Continue();
    }
}
