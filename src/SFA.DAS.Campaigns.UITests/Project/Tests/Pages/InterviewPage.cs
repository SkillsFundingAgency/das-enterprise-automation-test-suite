using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class InterviewPage : CampaingnsBasePage
    {
        protected override string PageTitle => "INTERVIEW";

        public InterviewPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
