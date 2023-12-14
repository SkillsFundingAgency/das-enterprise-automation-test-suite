namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;


public class EventFormatPage : AanAdminBasePage
{
    protected override string PageTitle => "Choose an event format";

    public EventFormatPage(ScenarioContext context) : base(context) { }

    public EventTitlePage SubmitEventFormat(EventFormat eventFormat)
    {
        aanAdminCreateEventDatahelper.SetEventFormat(eventFormat);

        SelectEventFormatAndContinue(aanAdminCreateEventDatahelper.EventFormat.eventFormat);

        return new(context);
    }

    public void ChangeEventFormat(EventFormat eventFormat)
    {
        aanAdminUpdateEventDatahelper.SetEventFormat(eventFormat);

        SelectEventFormatAndContinue(aanAdminUpdateEventDatahelper.EventFormat.eventFormat);
    }

    private void SelectEventFormatAndContinue(string value) { SelectRadioOptionByForAttribute(value); Continue(); }
    }
