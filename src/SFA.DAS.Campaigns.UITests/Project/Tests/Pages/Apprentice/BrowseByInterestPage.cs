
using TechTalk.SpecFlow;
namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class BrowseByInterestPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Page not found";
        public BrowseByInterestPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}