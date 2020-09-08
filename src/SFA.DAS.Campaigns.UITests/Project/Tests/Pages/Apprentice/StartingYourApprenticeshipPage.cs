using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class StartingYourApprenticeshipPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Page not found";

        public StartingYourApprenticeshipPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
