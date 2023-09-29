using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewApprenticeDetailsPage : CohortReferenceBasePage
    {
        protected static By ViewApprenticeLink => By.CssSelector("a.govuk-link.edit-apprentice");

        protected override string AccessibilityPageTitle => "Employer view apprentice details";

        protected override string PageTitle
        {
            get
            {
                int noOfApprentice = pageInteractionHelper.FindElements(ViewApprenticeLink).Count;
                return noOfApprentice < 2 ? "View apprentice details" : $"View {noOfApprentice} apprentices' details";
            }
        }

        private static By InputBox => By.TagName("input");

        private static By CohortStatus => By.Id("cohortStatus");

        public ViewApprenticeDetailsPage(ScenarioContext context) : base(context) { }

        internal List<IWebElement> GetAllEditBoxes() => pageInteractionHelper.FindElements(InputBox);

        public void ValidateCohortStatus(string status) => pageInteractionHelper.VerifyText(CohortStatus, status);
    }
}
