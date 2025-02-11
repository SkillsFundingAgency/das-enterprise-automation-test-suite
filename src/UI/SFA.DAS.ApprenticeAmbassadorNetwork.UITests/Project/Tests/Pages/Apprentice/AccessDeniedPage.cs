namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class AccessDeniedPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "You do not have access to this area of the website";

        public void VerifyHomeLink()
        {
            formCompletionHelper.ClickLinkByText("Home");
        }

    }
}



