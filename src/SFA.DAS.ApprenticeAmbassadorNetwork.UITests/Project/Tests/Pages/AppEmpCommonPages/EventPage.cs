namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class EventPage : AanBasePage
{
    protected override string PageTitle => "";

    private static By CancelAttendanceLink => By.XPath("//button[text()='Cancel your attendance']");
    private static By InPersonEventTag => By.XPath("//strong[contains(@class,'govuk-tag app-tag app-tag--InPerson')]");
    private static By OnlineEventTag => By.XPath("//strong[contains(@class,'govuk-tag app-tag app-tag--Online')]");
    private static By HybridEventTag => By.XPath("//strong[contains(@class,'govuk-tag app-tag app-tag--Hybrid')]");

    public EventPage(ScenarioContext context) : base(context) => VerifyPage();

    public SignUpConfirmationPage SignupForEvent()
    {
        Continue();
        return new SignUpConfirmationPage(context);
    }

    public SignUpCancelledPage CancelYourAttendance()
    {
        formCompletionHelper.ClickElement(CancelAttendanceLink);
        return new SignUpCancelledPage(context);
    }

    public EventPage VerifyInPersonEventTag()
    {
        pageInteractionHelper.IsElementDisplayed(InPersonEventTag);
        return new EventPage(context);
    }

    public EventPage VerifyOnlineEventTag()
    {
        pageInteractionHelper.IsElementDisplayed(OnlineEventTag);
        return new EventPage(context);
    }

    public EventPage VerifyHybridEventTag()
    {
        pageInteractionHelper.IsElementDisplayed(HybridEventTag);
        return new EventPage(context);
    }
}