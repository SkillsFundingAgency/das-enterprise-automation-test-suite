using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CancelEvent;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public class ManageEventsPage(ScenarioContext context) : SearchEventsBasePage(context)
{
    private static By CancelEventLink(string id) => By.CssSelector($"a[href='/events/{id}/cancel']");

    private static By CreateEventButton => By.CssSelector("#create-event");

    protected override string PageTitle => "Manage events";

    public CancelEventPage CancelEvent()
    {
        var eventId = context.Get<ObjectContext>().GetAanAdminEventId();

        formCompletionHelper.ClickElement(CancelEventLink(eventId));

        return new CancelEventPage(context);

    }

    public ManageEventsPage FilterEventBy(AanAdminCreateEventDatahelper data)
    {
        FilterEventBy(data.EventStartDateAndTime, data.EventEndDateAndTime, data.EventType, data.EventRegion);

        return this;
    }

    public EventFormatPage CreateEvent()
    {
        formCompletionHelper.Click(CreateEventButton);
        return new(context);
    }

    public new ManageEventsPage FilterEventFromTomorrow()
    {
        base.FilterEventFromTomorrow();
        return this;
    }

    public new ManageEventsPage FilterEventByOneMonth()
    {
        base.FilterEventByOneMonth();
        return this;
    }

    public new ManageEventsPage FilterEventByEventStatus_Published()
    {
        base.FilterEventByEventStatus_Published();
        return this;
    }

    public new ManageEventsPage FilterEventByEventStatus_Cancelled()
    {
        base.FilterEventByEventStatus_Cancelled();
        return this;
    }

    public new ManageEventsPage FilterEventByEventType_TrainingEvent()
    {
        base.FilterEventByEventType_TrainingEvent();
        return this;
    }

    public new ManageEventsPage FilterEventByEventRegion_London()
    {
        base.FilterEventByEventRegion_London();
        return this;
    }


    public new ManageEventsPage ClearAllFilters()
    {
        base.ClearAllFilters();
        return this;
    }

    public new ManageEventsPage VerifyEventStatus_Published_Filter()
    {
        base.VerifyEventStatus_Published_Filter();
        return this;
    }

    public new ManageEventsPage VerifyEventStatus_Cancelled_Filter()
    {
        base.VerifyEventStatus_Cancelled_Filter();
        return this;
    }
    public new ManageEventsPage VerifyEventType_TrainingEvent_Filter()
    {
        base.VerifyEventType_TrainingEvent_Filter();
        return this;
    }

    public new ManageEventsPage VerifyEventRegion_London_Filter()
    {
        base.VerifyEventRegion_London_Filter();
        return this;
    }

}
