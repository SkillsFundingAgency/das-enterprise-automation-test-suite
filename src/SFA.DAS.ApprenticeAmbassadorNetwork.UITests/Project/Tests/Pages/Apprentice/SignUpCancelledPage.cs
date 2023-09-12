namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class SignUpCancelledPage : AanBasePage
    {
        protected override string PageTitle => "You have successfully cancelled your attendance at this event";

        public SignUpCancelledPage(ScenarioContext context) : base(context) => VerifyPage();

        public EventsHubPage AccessEventsHubFromCancelledAttendancePage()
        {
            formCompletionHelper.ClickLinkByText("Events hub");
            return new EventsHubPage(context);
        }

    }
}