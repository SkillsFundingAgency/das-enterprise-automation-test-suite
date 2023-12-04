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

    private void SubmitInPerson() => SelectAutoDropDown(aanAdminDatahelper.EventInPersonLocation);

    private void SubmitOnline() => formCompletionHelper.EnterText(LinkInput, aanAdminDatahelper.EventOnlineLink);
}
