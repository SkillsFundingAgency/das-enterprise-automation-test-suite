using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmQualificationsPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "Qualifications";

        public FutureProspectsPage ConfirmQualificationsAndGoToFutureProspectsPage()
        {
            formCompletionHelper.ClickLinkByText("Save and continue");
            return new FutureProspectsPage(context);
        }
    }
}
