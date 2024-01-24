namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class CheckYourEventPage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "Check your event before publishing";

    private static By ChangeFormat => By.CssSelector("a[href='/events/new/format']");

    private static By ChangeType => By.CssSelector("a[href='/events/new/type']");

    private static By ChangeDateandTime => By.CssSelector("a[href='/events/new/dateandtime']");

    private static By ChangeDescription => By.CssSelector("a[href='/events/new/description']");

    private static By ChangeGuestSpeaker => By.CssSelector("a[href='/events/new/guestspeakers/question']");

    private static By ChangeOrganiser => By.CssSelector("a[href='/events/new/organiser']");

    private static By ChangeSchool => By.CssSelector("a[href='/events/new/school/question']");

    private static By ChangeAttendees => By.CssSelector("a[href='/events/new/attendees']");

    public SucessfullyPublisedEventPage SubmitEvent()
    {
        Continue();

        return new SucessfullyPublisedEventPage(context);
    }

    public EventPreviewPage GoToEventPreviewPage(EventFormat eventFormat)
    {
        formCompletionHelper.ClickLinkByText("preview the event here");

        return new EventPreviewPage(context, eventFormat);
    }

    public EventFormatPage ChangeEventFormat()
    {
        formCompletionHelper.Click(ChangeFormat);

        return new EventFormatPage(context);
    }

    public EventTitlePage ChangeEventType()
    {
        formCompletionHelper.Click(ChangeType);

        return new EventTitlePage(context);
    }

    public EventDatePage ChangeEventDateandTime()
    {
        formCompletionHelper.Click(ChangeDateandTime);

        return new EventDatePage(context);
    }

    public EventOutlinePage ChangeEventDescription()
    {
        formCompletionHelper.Click(ChangeDescription);

        return new EventOutlinePage(context);
    }

    public IncludeGuestSpeakerPage ChangeGuestSpeakers()
    {
        formCompletionHelper.Click(ChangeGuestSpeaker);

        return new IncludeGuestSpeakerPage(context);
    }

    public EventOrganiserNamePage ChangeEventOrganiser()
    {
        formCompletionHelper.Click(ChangeOrganiser);

        return new EventOrganiserNamePage(context);
    }

    public IsEventAtSchoolPage ChangeEventSchool()
    {
        formCompletionHelper.Click(ChangeSchool);

        return new IsEventAtSchoolPage(context);
    }

    public EventAttendeesPage ChangeEventAttendees()
    {
        formCompletionHelper.Click(ChangeAttendees);

        return new EventAttendeesPage(context);
    }

}
