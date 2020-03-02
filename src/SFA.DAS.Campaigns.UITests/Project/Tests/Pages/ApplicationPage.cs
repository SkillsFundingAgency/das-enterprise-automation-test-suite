using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ApplicationPage : CampaingnsBasePage
    {
        protected override string PageTitle => "APPLICATION";

        public ApplicationPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
