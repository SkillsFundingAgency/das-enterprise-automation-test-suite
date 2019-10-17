using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDeleteCohortPage : BasePage
    {
        protected override string PageTitle => "Cohort deleted";

        protected override By PageHeader => By.CssSelector(".green-box-alert");

        public ProviderDeleteCohortPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
