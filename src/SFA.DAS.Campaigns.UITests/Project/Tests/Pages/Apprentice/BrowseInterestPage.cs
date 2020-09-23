using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class BrowseInterestPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Page not found";
        public BrowseInterestPage(ScenarioContext context): base(context) 
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}