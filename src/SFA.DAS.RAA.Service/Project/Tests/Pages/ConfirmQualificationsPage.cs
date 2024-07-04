using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ConfirmQualificationsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Qualifications";

        public FutureProspectsPage ConfirmQualificationsAndGoToFutureProspectsPage()
        {
            formCompletionHelper.ClickLinkByText("Save and continue");
            return new FutureProspectsPage(context);
        }
    }
}
