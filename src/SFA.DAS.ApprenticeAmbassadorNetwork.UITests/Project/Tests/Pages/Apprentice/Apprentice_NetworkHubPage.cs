namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class Apprentice_NetworkHubPage : SignInPage
    {
        protected override string PageTitle => "Your network hub";

        public Apprentice_NetworkHubPage(ScenarioContext context) : base(context) => VerifyPage();

        public EventsHubPage AccessEventsHub()
        {
            formCompletionHelper.ClickLinkByText("Events hub");
            return new EventsHubPage(context);
        }

    }
}