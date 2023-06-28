namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class NetworkHubPage : SignInPage
    {
        protected override string PageTitle => "Your network hub";

        public NetworkHubPage(ScenarioContext context) : base(context) => VerifyPage();

    }
}