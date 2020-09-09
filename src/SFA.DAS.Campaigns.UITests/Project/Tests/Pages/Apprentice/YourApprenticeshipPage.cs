using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class YourApprenticeshipPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Error";

        public YourApprenticeshipPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
