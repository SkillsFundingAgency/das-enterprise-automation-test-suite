using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class AssesmentAndCertificationPage : CampaingnsBasePage
    {
        protected override string PageTitle => "ASSESSMENT AND CERTIFICATION";

        public AssesmentAndCertificationPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
