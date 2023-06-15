namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class AccessDeniedPage : AanBasePage
    {
        protected override string PageTitle => "You do not have access to this area of the website";

        public AccessDeniedPage(ScenarioContext context) : base(context) => VerifyPage();

        public void VerifyHomeLink()
        {
            formCompletionHelper.ClickLinkByText("Home");
        }

    }
}



