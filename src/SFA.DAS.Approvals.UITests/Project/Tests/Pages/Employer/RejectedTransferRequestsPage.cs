using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class RejectedTransferRequestsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Rejected transfer requests";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CohortInfoRow => By.CssSelector("tbody tr");
        private By CohortEditLink => By.LinkText("Edit");

        public RejectedTransferRequestsPage(ScenarioContext context) : base(context) => _context = context;

        public ReviewYourCohortPage OpenRejectedCohort()
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
            return new ReviewYourCohortPage(_context);
        }
    }
}

