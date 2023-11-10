namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventOrganiserNamePage : AanAdminBasePage
{
    protected override string PageTitle => "Event organiser name";

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
