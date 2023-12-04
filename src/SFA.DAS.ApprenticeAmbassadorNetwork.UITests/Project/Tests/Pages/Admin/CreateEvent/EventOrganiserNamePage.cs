namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventOrganiserNamePage : AanAdminBasePage
{
    protected override string PageTitle => "Event organiser name";

    private static By OrganiserName => By.CssSelector("input#OrganiserName");

    private static By OrganiserEmail => By.CssSelector("input#OrganiserEmail");

    public EventOrganiserNamePage(ScenarioContext context) : base(context) { }

    public EventAttendeesPage SubmitOrganiserName()
    {
        EnterOrganiserName(aanAdminCreateEventDatahelper);

        return new(context);
    }

    public CheckYourEventPage UpdateOrganiserName()
    {
        EnterOrganiserName(aanAdminUpdateEventDatahelper);

        return new(context);
    }

    private void EnterOrganiserName(AanAdminCreateEventBaseDatahelper datahelper)
    {
        formCompletionHelper.EnterText(OrganiserName, datahelper.EventOrganiserName);

        formCompletionHelper.EnterText(OrganiserEmail, datahelper.EventOrganiserEmail);

        Continue();
    }
}
