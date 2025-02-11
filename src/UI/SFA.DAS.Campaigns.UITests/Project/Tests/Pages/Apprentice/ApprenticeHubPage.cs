using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeHubPage(ScenarioContext context) : ApprenticeBasePage(context)
    {
        protected override string PageTitle => "Apprentices";

        protected override By PageHeader => PageHeaderTag;

        protected static By SetUpService => By.CssSelector("a[href*='create-account']");

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToApprenticeshipHubPage());

        public SetUpServicePage NavigateToSetUpServiceAccountPage()
        {
            formCompletionHelper.ClickElement(SetUpService);
            return new SetUpServicePage(context);
        }
    }
}
