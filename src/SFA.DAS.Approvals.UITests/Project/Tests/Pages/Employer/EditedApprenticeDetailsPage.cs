using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditedApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => editedApprenticeDataHelper.ApprenticeEditedFullName;
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public EditedApprenticeDetailsPage(ScenarioContext context) : base(context) { }
    }
}