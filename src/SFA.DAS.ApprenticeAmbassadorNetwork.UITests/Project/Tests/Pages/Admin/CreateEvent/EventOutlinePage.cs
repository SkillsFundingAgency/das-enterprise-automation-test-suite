namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventOutlinePage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "Event outline";

    private static By EventOutlineText => By.CssSelector("#eventOutline");

    private static By EventSummaryText => By.CssSelector("#EventSummary p");

    public IncludeGuestSpeakerPage SubmitEventOutline()
    {
        EnterEventOutline(aanAdminCreateEventDatahelper);

        return new(context);
    }

    public CheckYourEventPage UpdateEventOutline()
    {
        EnterEventOutline(aanAdminUpdateEventDatahelper);

        return new(context);
    }

    private void EnterEventOutline(AanAdminCreateEventBaseDatahelper datahelper)
    {
        formCompletionHelper.EnterText(EventOutlineText, datahelper.EventOutline);

        formCompletionHelper.EnterText(EventSummaryText, datahelper.EventSummary);

        Continue();
    }

}
