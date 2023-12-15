using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_FindAnApprenticeshipHomePage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Find an apprenticeship";

        public FAA_MyApplicationsHomePage MyApplications()
        {
            formCompletionHelper.ClickLinkByText("My applications");
            return new FAA_MyApplicationsHomePage(context);
        }

        public FAA_SettingsPage Settings()
        {
            formCompletionHelper.ClickLinkByText("Settings");
            return new FAA_SettingsPage(context);
        }
    }
}
