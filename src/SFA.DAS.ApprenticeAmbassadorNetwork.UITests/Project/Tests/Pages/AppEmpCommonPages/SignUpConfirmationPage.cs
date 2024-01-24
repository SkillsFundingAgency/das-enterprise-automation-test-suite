namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class SignUpConfirmationPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "You have successfully signed up to this event";

    public EventsHubPage AccessEventsHub()
    {
        formCompletionHelper.ClickLinkByText("Events hub");
        return new EventsHubPage(context);
    }
}