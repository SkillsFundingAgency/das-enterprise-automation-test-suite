using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeRealStoriesPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Error";

        public ApprenticeRealStoriesPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader,PageTitle);
        }       
    }
}
