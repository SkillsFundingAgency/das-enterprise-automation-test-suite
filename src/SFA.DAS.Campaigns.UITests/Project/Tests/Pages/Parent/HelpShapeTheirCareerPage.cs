using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Parent
{
    public class HelpShapeTheirCareerPage : CampaingnsPage
    {
        protected override string PageTitle => "Help shape their career";

        public HelpShapeTheirCareerPage(ScenarioContext context) : base(context)
        {
            //pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
