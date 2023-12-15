using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewApprenticePage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected override string PageTitle => "View apprentice details";

        private static By ViewApprenticeLink => By.CssSelector("a.govuk-link.edit-apprentice");

        public ViewApprenticeDetailsPage ClickViewApprenticeLink()
        {
            formCompletionHelper.ClickElement(ViewApprenticeLink);
            return new ViewApprenticeDetailsPage(context);
        }
    }
}
