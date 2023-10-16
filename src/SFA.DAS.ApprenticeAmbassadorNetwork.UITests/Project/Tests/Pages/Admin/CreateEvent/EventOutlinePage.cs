namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventOutlinePage : AanAdminBasePage
{
    protected override string PageTitle => "Event outline";

    private static By EventOutlineText => By.CssSelector("#eventOutline");

    private static By EventSummaryText => By.CssSelector("#EventSummary p");

    public EventOutlinePage(ScenarioContext context) : base(context) { }

    public IncludeGuestSpeakerPage SubmitEventOutline()
    {
        formCompletionHelper.EnterText(EventOutlineText, aanAdminDatahelper.EventOutline);

        formCompletionHelper.EnterText(EventSummaryText, aanAdminDatahelper.EventSummary);

        Continue();

        return new(context);
    }

}
