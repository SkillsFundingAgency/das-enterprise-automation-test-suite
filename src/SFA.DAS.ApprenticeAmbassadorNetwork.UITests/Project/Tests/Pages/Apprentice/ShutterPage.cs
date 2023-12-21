namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class ShutterPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "You do not meet the necessary criteria to join the network as an apprentice ambassador";

        public void VerifyApprenticePortalLink()
        {
            formCompletionHelper.ClickLinkByText("Back to the apprenticeship portal");
        }

    }
}



