namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventAttendeesPage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "How many attendees do you expect at this event?";

    private static By NumberOfAttendees => By.CssSelector("input#NumberOfAttendees");

    public CheckYourEventPage SubmitEventAttendees()
    {
        EnterEventAttendees(aanAdminCreateEventDatahelper);

        return new(context);
    }

    public CheckYourEventPage UpdateEventAttendees()
    {
        EnterEventAttendees(aanAdminUpdateEventDatahelper);

        return new(context);
    }

    private void EnterEventAttendees(AanAdminCreateEventBaseDatahelper datahelper)
    {
        formCompletionHelper.EnterText(NumberOfAttendees, datahelper.EventAttendeesNo);

        Continue();
    }
}
