using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimApprenticesAccessDeniedPage : InterimApprenticesHomePage
    {
        protected override string PageTitle => "Access denied";
        private static string HomePageLinkText => "Go back to the service home page";

        public InterimApprenticesAccessDeniedPage(ScenarioContext context) : base(context, false) { }

        public void GoBackToTheEASServiceHomePage() => formCompletionHelper.ClickLinkByText(HomePageLinkText);
    }
}