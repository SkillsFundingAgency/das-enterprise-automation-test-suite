namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventOutlinePage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "Event outline";

    private static By EventOutlineText => By.XPath("//textarea[@id='EventOutline']");

    private static By EventSummaryText => By.CssSelector("div[aria-label='Editor editing area: main']");

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
