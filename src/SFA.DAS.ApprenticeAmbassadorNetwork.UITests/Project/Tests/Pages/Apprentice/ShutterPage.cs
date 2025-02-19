namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class ShutterPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Talk to your line manager before continuing";

        public void VerifyApprenticePortalLink()
        {
            formCompletionHelper.ClickLinkByText("continue to join the Apprenticeship Ambassador Network");
        }

    }
}



