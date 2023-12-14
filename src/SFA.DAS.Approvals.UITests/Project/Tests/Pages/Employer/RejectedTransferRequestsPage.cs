using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class RejectedTransferRequestsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Rejected transfer requests";

        private static By CohortInfoRow => By.CssSelector("tbody tr");
        private static By CohortEditLink => By.LinkText("Edit");

        public ApproveApprenticeDetailsPage OpenRejectedCohort()
        {
            var cohortRows = pageInteractionHelper.FindElements(CohortInfoRow);
            var cohortEditLinks = pageInteractionHelper.FindElements(CohortEditLink);
            int i = 0;

            foreach (IWebElement cohortRow in cohortRows)
            {
                if ((cohortRow.Text.Contains(objectContext.GetCohortReference())))
                {
                    formCompletionHelper.ClickElement(cohortEditLinks[i]);
                    break;
                }
                i++;
            }
            return new ApproveApprenticeDetailsPage(context);
        }
    }
}

