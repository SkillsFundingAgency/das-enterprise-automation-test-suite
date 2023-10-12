namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public enum EventFormat
{
    InPerson,
    Online,
    Hybrid
}


public class EventFormatPage : AanAdminBasePage
{
    protected override string PageTitle => "Event format";

    public EventFormatPage(ScenarioContext context) : base(context) { }

    public EventTitlePage SubmitEventFormat(EventFormat eventFormat)
    {
        aanAdminDatahelper.SetEventFormat(eventFormat);

        SelectRadioOptionByForAttribute(aanAdminDatahelper.EventFormat.eventFormat);

        Continue();

        return new(context);
    }
}

public class EventTitlePage : AanAdminBasePage
{
    protected override string PageTitle => "Event title";

    //protected override By PageHeader => By.CssSelector("#EventTitle");

    private static By EventTitleSelector => By.CssSelector("#eventTitle");

    public EventTitlePage(ScenarioContext context) : base(context) { }

    public EventOutlinePage SubmitEventTitle()
    {
        formCompletionHelper.EnterText(EventTitleSelector, aanAdminDatahelper.EventTitle);

        SelectRandomOption("#EventTypeId");

        SelectRandomOption("#EventRegionId");

        Continue();

        return new(context);
    }

}

public class EventOutlinePage : AanAdminBasePage
{
    protected override string PageTitle => "Event outline";

    //protected override By PageHeader => By.CssSelector("#EventOutline");

    private static By EventOutlineText => By.CssSelector("#eventOutline");

    private static By EventSummaryText => By.CssSelector("#EventSummary p");

    public EventOutlinePage(ScenarioContext context) : base(context) { }

    public IncludeGuestSpeakerPage SubmitEventOutline()
    {
        formCompletionHelper.EnterText(EventOutlineText, aanAdminDatahelper.EventOutline);

        formCompletionHelper.EnterText(EventSummaryText, aanAdminDatahelper.EventSummary);

        Continue();

        return new(context);
    }

}

public class IncludeGuestSpeakerPage : AanAdminBasePage
{
    protected override string PageTitle => "Does the event include guest speakers?";

    //protected override By PageHeader => By.CssSelector("#HasGuestSpeakers");

    public IncludeGuestSpeakerPage(ScenarioContext context) : base(context) { }

    public GuestSpeakersPage SubmitGuestSpeakerAsYes()
    {
        SelectRadioOptionByForAttribute("true");

        Continue();

        return new(context);
    }

    public EventDatePage SubmitGuestSpeakerAsNo()
    {
        SelectRadioOptionByForAttribute("false");

        Continue();

        return new(context);
    }
}

public class GuestSpeakerDetailPage : AanAdminBasePage
{
    protected override string PageTitle => "Guest speaker name";

    //protected override By PageHeader => By.CssSelector("#main-content");

    private static By Name => By.CssSelector("#name");

    private static By JobRoleAndOrganisation => By.CssSelector("#jobRoleAndOrganisation");

    public GuestSpeakerDetailPage(ScenarioContext context) : base(context) { }

    public GuestSpeakersPage AddGuestSpeaker(int i)
    {
        formCompletionHelper.EnterText(Name, $"{i}_{aanAdminDatahelper.GuestSpeakerName}");

        formCompletionHelper.EnterText(JobRoleAndOrganisation, $"{i}_{aanAdminDatahelper.GuestSpeakerRole}");

        Continue();

        return new(context);
    }
}


public class GuestSpeakersPage : AanAdminBasePage
{
    protected override string PageTitle => "Guest Speakers";

    public GuestSpeakersPage(ScenarioContext context) : base(context) { }

    public EventDatePage AddAndDeleteGuestSpeakers(int add)
    {      
        for (int i = 1; i <= add; i++)
        {
            formCompletionHelper.ClickLinkByText("Add Speaker");

            new GuestSpeakerDetailPage(context).AddGuestSpeaker(i);
        }

        int delete = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, add);

        for (int i = 0; i < delete; i++) formCompletionHelper.ClickLinkByText("Delete");

        Continue();

        return new(context);
    }
}

public class EventDatePage : AanAdminBasePage
{
    protected override string PageTitle => "Event date";

    //protected override By PageHeader => By.CssSelector("#DateOfEvent");

    private static By EventDateSelector => By.CssSelector("#dateOfEvent");

    private static By StartHourSelector => By.CssSelector("#StartHour");
    private static By StartMinutesSelector => By.CssSelector("#startMinutes");
    private static By EndHourSelector => By.CssSelector("#EndHour");
    private static By EndMinutesSelector => By.CssSelector("#EndMinutes");

    public EventDatePage(ScenarioContext context) : base(context) { }

    public void SubmitEventDate()
    {
        var startDate = aanAdminDatahelper.EventStartDateAndTime;

        var endDate = aanAdminDatahelper.EventEndDateAndTime;

        formCompletionHelper.EnterText(EventDateSelector, $"{startDate.ToString(DateFormat)}");

        formCompletionHelper.EnterText(StartHourSelector, $"{startDate:HH}");

        formCompletionHelper.EnterText(StartMinutesSelector, $"{startDate:mm}");

        formCompletionHelper.EnterText(EndHourSelector, $"{endDate:HH}");

        formCompletionHelper.EnterText(EndMinutesSelector, $"{endDate:mm}");

        Continue();
    }
}


public class InPersonOrOnlinePage : AanAdminBasePage
{
    protected override string PageTitle => _pageTitle;

    private readonly string _pageTitle;

    private readonly EventFormat _eventFormat;

    private static By LinkInput => By.CssSelector("input#onlineEventLink");

    public InPersonOrOnlinePage(ScenarioContext context, EventFormat eventFormat) : base(context, false)
    {
        _eventFormat = eventFormat;

        _pageTitle = eventFormat == EventFormat.Online ? "Online event link" : "In person event location";

        VerifyPage();
    }

    public IsEventAtSchoolPage SubmitInPersonDetails()
    {
        SubmitInPerson();

        Continue();

        return new(context);
    }

    public EventOrganiserNamePage SubmitOnlineDetails()
    {
        SubmitOnline();

        Continue();

        return new(context);
    }


    public IsEventAtSchoolPage SubmitHybridDetails()
    {
        SubmitInPerson(); 
        
        SubmitOnline();

        Continue();

        return new(context);
    }

    private void SubmitInPerson() => EnterAutoSelect(aanAdminDatahelper.EventInPersonLocation);

    private void SubmitOnline() => formCompletionHelper.EnterText(LinkInput, aanAdminDatahelper.EventOnlineLink);
}

public class IsEventAtSchoolPage : AanAdminBasePage
{
    protected override string PageTitle => "Is this event held at a school?";

    //protected override By PageHeader => By.CssSelector("#main-content");

    public IsEventAtSchoolPage(ScenarioContext context) : base(context) { }

    public NameOfTheSchoolPage SubmitIsEventAtSchoolAsYes()
    {
        SelectRadioOptionByForAttribute("true");

        Continue();

        return new(context);
    }

    public EventOrganiserNamePage SubmitIsEventAtSchoolAsNo()
    {
        SelectRadioOptionByForAttribute("false");

        Continue();

        return new(context);
    }
}

public class NameOfTheSchoolPage : AanAdminBasePage
{
    protected override string PageTitle => "Name of the school";

    //protected override By PageHeader => By.CssSelector("#main-content");

    public NameOfTheSchoolPage(ScenarioContext context) : base(context) { }

    public EventOrganiserNamePage SubmitSchoolName()
    {
        EnterAutoSelect(aanAdminDatahelper.EventSchoolName);

        Continue();

        return new(context);
    }
}


public class EventOrganiserNamePage : AanAdminBasePage
{
    protected override string PageTitle => "Event organiser name";

    //protected override By PageHeader => By.CssSelector("#main-content");

    private static By OrganiserName => By.CssSelector("input#OrganiserName");

    private static By OrganiserEmail => By.CssSelector("input#OrganiserEmail");

    public EventOrganiserNamePage(ScenarioContext context) : base(context) { }

    public EventAttendeesPage SubmitOrganiserName()
    {
        formCompletionHelper.EnterText(OrganiserName, aanAdminDatahelper.EventOrganiserName);

        formCompletionHelper.EnterText(OrganiserEmail, aanAdminDatahelper.EventOrganiserEmail);

        Continue();

        return new(context);
    }
}


public class EventAttendeesPage : AanAdminBasePage
{
    protected override string PageTitle => "How many attendees do you expect at this event?";

    //protected override By PageHeader => By.CssSelector("#main-content");

    private static By NumberOfAttendees => By.CssSelector("input#NumberOfAttendees");

    public EventAttendeesPage(ScenarioContext context) : base(context) { }

    public CheckYourEventPage SubmitEventAttendees()
    {
        formCompletionHelper.EnterText(NumberOfAttendees, aanAdminDatahelper.EventAttendeesNo);

        Continue();

        return new(context);
    }
}

public class CheckYourEventPage : AanAdminBasePage
{
    protected override string PageTitle => "Check your event before publishing";

    public CheckYourEventPage(ScenarioContext context) : base(context) { }

    public SucessfullyPublisedEventPage SubmitEvent()
    {
        Continue();

        return new SucessfullyPublisedEventPage(context);
    }
}


public class SucessfullyPublisedEventPage : AanAdminBasePage
{
    protected override string PageTitle => "You have successfully published a network event";

    public SucessfullyPublisedEventPage(ScenarioContext context) : base(context) { }
}