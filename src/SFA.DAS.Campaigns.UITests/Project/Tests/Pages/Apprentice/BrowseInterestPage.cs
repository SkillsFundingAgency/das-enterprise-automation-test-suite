using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class BrowseInterestPage : ApprenticeBasePage
    {
        private ScenarioContext context;

        public BrowseInterestPage(ScenarioContext context): base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}