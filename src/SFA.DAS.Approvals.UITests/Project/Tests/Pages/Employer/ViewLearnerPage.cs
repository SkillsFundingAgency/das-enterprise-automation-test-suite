using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewLearnerPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl, .govuk-heading-l");
        protected override string PageTitle
        {
            get
            {
                const string viewApprenticeDetailsTitle = "View apprentice details";
                const string viewLearnerDetailsTitle = "View learner details";

                var (isViewApprenticeDetailsPage, _) = pageInteractionHelper.CheckText(PageHeader, viewApprenticeDetailsTitle);
                return isViewApprenticeDetailsPage ? viewApprenticeDetailsTitle : viewLearnerDetailsTitle;
            }
        }

        private static By ViewApprenticeLink => By.CssSelector("a.govuk-link.edit-apprentice");

        public ViewLearnerDetailsPage ClickViewApprenticeLink()
        {
            formCompletionHelper.ClickElement(ViewApprenticeLink);
            return new ViewLearnerDetailsPage(context);
        }
    }
}
