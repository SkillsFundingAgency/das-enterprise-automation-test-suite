namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class EventTitlePage : AanAdminBasePage
{
    protected override string PageTitle => "Event title";

    private static By EventTitleSelector => By.CssSelector("#eventTitle");

    public EventTitlePage(ScenarioContext context) : base(context) { }

    public EventOutlinePage SubmitEventTitle()
    {
        formCompletionHelper.EnterText(EventTitleSelector, aanAdminDatahelper.EventTitle);

        SelectRandomOption("#EventTypeId");

        SelectRandomOption("#EventRegionId");

        Continue();

        return new(context);
    }

}
