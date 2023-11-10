namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;


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
