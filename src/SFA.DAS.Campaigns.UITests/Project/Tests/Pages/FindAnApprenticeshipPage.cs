using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class FindAnApprenticeshipPage : CampaingnsBasePage
    {
        protected override string PageTitle => "FIND AN APPRENTICESHIP";

        public FindAnApprenticeshipPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
