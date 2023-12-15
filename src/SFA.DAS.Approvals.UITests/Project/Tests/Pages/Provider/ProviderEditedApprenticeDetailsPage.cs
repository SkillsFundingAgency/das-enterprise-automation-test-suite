using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditedApprenticeDetailsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected override string PageTitle => editedApprenticeDataHelper.ApprenticeEditedFullName;

        protected override string AccessibilityPageTitle => "Provider edit apprentice details";
    }
}
