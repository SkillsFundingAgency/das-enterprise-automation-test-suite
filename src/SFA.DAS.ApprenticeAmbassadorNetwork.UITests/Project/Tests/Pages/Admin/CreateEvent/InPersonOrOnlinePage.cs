namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class InPersonOrOnlinePage : AanAdminBasePage
{
    protected override string PageTitle => _pageTitle;

    private readonly string _pageTitle;

    private static By LinkInput => By.CssSelector("input#onlineEventLink");

    public InPersonOrOnlinePage(ScenarioContext context, EventFormat eventFormat) : base(context, false)
    {
        _pageTitle = eventFormat == EventFormat.Online ? "Online event link" : "In person event location";

        VerifyPage();
    }

    public IsEventAtSchoolPage SubmitInPersonDetails(string location = null)
    {
        SubmitInPerson(location);

        Continue();

        return new(context);
    }

    public EventOrganiserNamePage SubmitOnlineDetails()
    {
        SubmitOnline();

        Continue();

        return new(context);
    }


    public IsEventAtSchoolPage SubmitHybridDetails(string location = null)
    {
        SubmitInPerson(location);

        SubmitOnline();

        Continue();

        return new(context);
    }

    public CheckYourEventPage ContinueToCheckYourEventPage(EventFormat neweventFormat)
    {
        if (neweventFormat == EventFormat.InPerson)
        {
            SubmitInPerson();
        }
        else if (neweventFormat == EventFormat.Online)
        {
            SubmitOnline();
        }
        else
        {
            SubmitInPerson();

            SubmitOnline();
        }

        Continue();

        return new(context);
    }

    private void SubmitInPerson(string location = null)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            SelectAutoDropDown(aanAdminCreateEventDatahelper.EventInPersonLocation);
        }
        else
        {
            SelectAutoDropDown(location, true);
        }
    }

    private void SubmitOnline() => formCompletionHelper.EnterText(LinkInput, aanAdminCreateEventDatahelper.EventOnlineLink);
}
