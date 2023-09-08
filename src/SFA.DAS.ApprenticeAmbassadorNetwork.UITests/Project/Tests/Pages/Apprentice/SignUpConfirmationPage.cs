namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class SignUpConfirmationPage : AanBasePage
    {
        protected override string PageTitle => "You have successfully signed up to this event";

        public SignUpConfirmationPage(ScenarioContext context) : base(context) => VerifyPage();

        public EventsHubPage AccessEventsHub()
        {
            formCompletionHelper.ClickLinkByText("Events hub");
            return new EventsHubPage(context);
        }

    }
}