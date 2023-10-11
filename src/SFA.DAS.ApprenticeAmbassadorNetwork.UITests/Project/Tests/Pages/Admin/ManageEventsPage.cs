namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public class ManageEventsPage : SearchEventsBasePage
{
    private static By CreateEventButton => By.CssSelector("#create-event");

    protected override string PageTitle => "Manage events";

    public ManageEventsPage(ScenarioContext context) : base(context) { }

    public EventFormatPage CreateEvent()
    {
        formCompletionHelper.Click(CreateEventButton);
        return new (context);
    }

    public new ManageEventsPage FilterEventByTomorrow()
    {
        base.FilterEventByTomorrow();
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
