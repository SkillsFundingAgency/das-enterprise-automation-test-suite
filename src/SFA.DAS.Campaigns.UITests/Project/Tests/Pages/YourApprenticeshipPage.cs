using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class YourApprenticeshipPage : CampaingnsBasePage
    {
        protected override string PageTitle => "YOUR APPRENTICESHIP";

        public YourApprenticeshipPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
