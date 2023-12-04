namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;


public class EventFormatPage : AanAdminBasePage
{
    protected override string PageTitle => "Event format";

    public EventFormatPage(ScenarioContext context) : base(context) { }

    public EventTitlePage SubmitEventFormat(EventFormat eventFormat)
    {
        aanAdminDatahelper.SetEventFormat(eventFormat);

        SelectEventFormatAndContinue(aanAdminDatahelper.EventFormat.eventFormat);

        return new(context);
    }

    public void ChangeEventFormat(EventFormat eventFormat)
    {
        aanAdminDatahelper.SetChangedEventFormat(eventFormat);

        SelectEventFormatAndContinue(aanAdminDatahelper.ChangedEventFormat.eventFormat);
    }

    private void SelectEventFormatAndContinue(string value) { SelectRadioOptionByForAttribute(value); Continue(); }
    }
