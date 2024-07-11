using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class SelectAStandardVersionPage(ScenarioContext context, bool verifyPage = true) : ApprovalsBasePage(context, verifyPage)
    {
        protected override string PageTitle => "Select a standard version";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ApprenticeDetailsPage GoBackToApprenticeDetailsPage()
        {
            tabHelper.NavigateBrowserBack();
            return new ApprenticeDetailsPage(context);
        }

        public ProviderApprenticeDetailsPage GoBackToProviderApprenticeDetailsPage()
        {
            tabHelper.NavigateBrowserBack();
            return new ProviderApprenticeDetailsPage(context);
        }
    }
}
