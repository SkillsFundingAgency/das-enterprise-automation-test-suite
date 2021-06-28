using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimApprenticesAccessDeniedPage : InterimApprenticesHomePage
    {
        protected override string PageTitle => "Access denied";
        private string HomePageLinkText => "Go back to the service home page";

        public InterimApprenticesAccessDeniedPage(ScenarioContext context) : base(context, true) { }

        public void GoBackToTheEASServiceHomePage()
        {
            formCompletionHelper.ClickLinkByText(HomePageLinkText);
        }
    }
}