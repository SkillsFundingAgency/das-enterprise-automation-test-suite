namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventDatePage : AanAdminBasePage
{
    protected override string PageTitle => "Event date";

    private static By EventDateSelector => By.CssSelector("#dateOfEvent");

    private static By StartHourSelector => By.CssSelector("#StartHour");
    private static By StartMinutesSelector => By.CssSelector("#startMinutes");
    private static By EndHourSelector => By.CssSelector("#EndHour");
    private static By EndMinutesSelector => By.CssSelector("#EndMinutes");

    public EventDatePage(ScenarioContext context) : base(context) { }

    public void SubmitEventDate()
    {
        EnterEventDate(aanAdminCreateEventDatahelper);
    }

    public CheckYourEventPage UpdateEventDate()
    {
        EnterEventDate(aanAdminUpdateEventDatahelper);

        return new CheckYourEventPage(context);
    }

    private void EnterEventDate(AanAdminCreateEventBaseDatahelper datahelper)
    {
        var startDate = datahelper.EventStartDateAndTime;

        var endDate = datahelper.EventEndDateAndTime;

        formCompletionHelper.EnterText(EventDateSelector, $"{startDate.ToString(DateFormat)}");

        formCompletionHelper.EnterText(StartHourSelector, $"{startDate:HH}");

        formCompletionHelper.EnterText(StartMinutesSelector, $"{startDate:mm}");

        formCompletionHelper.EnterText(EndHourSelector, $"{endDate:HH}");

        formCompletionHelper.EnterText(EndMinutesSelector, $"{endDate:mm}");

        Continue();
    }
}
