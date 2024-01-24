using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest
{
    public class ThanksForSubscribingPage(ScenarioContext context) : CampaingnsVerifyLinks(context)
    {
        protected override string PageTitle => "Thank you for signing up";
    }
}
