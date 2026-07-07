using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewApprenticeDetailsPage(ScenarioContext context) : CohortReferenceBasePage(context)
    {
        private const string ViewApprenticeDetailsTitle = "View apprentice details";
        private const string ViewLearnerDetailsTitle = "View learner details";
        private const string ViewApprenticesDetailsTitleFormat = "View {0} apprentices' details";
        private const string ViewLearnersDetailsTitleFormat = "View {0} learners' details";

        protected static By ViewApprenticeLink => By.CssSelector("a.govuk-link.edit-apprentice");

        protected override string AccessibilityPageTitle => "Employer view learner details";

        protected override string PageTitle
        {
            get
            {
                int noOfApprentice = pageInteractionHelper.FindElements(ViewApprenticeLink).Count;
                if (noOfApprentice >= 2)
                {
                    var viewApprenticesDetailsTitle = string.Format(ViewApprenticesDetailsTitleFormat, noOfApprentice);
                    var viewLearnersDetailsTitle = string.Format(ViewLearnersDetailsTitleFormat, noOfApprentice);
                    var (isViewApprenticesDetailsPage, _) = pageInteractionHelper.CheckText(PageHeader, viewApprenticesDetailsTitle);

                    return isViewApprenticesDetailsPage ? viewApprenticesDetailsTitle : viewLearnersDetailsTitle;
                }

                var (isViewApprenticeDetailsPage, _) = pageInteractionHelper.CheckText(PageHeader, ViewApprenticeDetailsTitle);
                return isViewApprenticeDetailsPage ? ViewApprenticeDetailsTitle : ViewLearnerDetailsTitle;
            }
        }

        private static By InputBox => By.TagName("input");

        private static By CohortStatus => By.Id("cohortStatus");

        internal List<IWebElement> GetAllEditBoxes() => pageInteractionHelper.FindElements(InputBox);

        public void ValidateCohortStatus(string status) => pageInteractionHelper.VerifyText(CohortStatus, status);
    }
}
