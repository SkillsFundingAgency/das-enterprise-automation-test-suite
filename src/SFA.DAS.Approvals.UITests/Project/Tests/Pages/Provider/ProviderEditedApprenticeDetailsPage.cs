using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditedApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected override string PageTitle => editedApprenticeDataHelper.ApprenticeEditedFullName;

        public ProviderEditedApprenticeDetailsPage(ScenarioContext context) : base(context) { }
    }
}
