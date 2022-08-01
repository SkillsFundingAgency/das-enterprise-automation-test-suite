using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ReviewYourCohort : CohortReferenceBasePage
    {
        protected virtual By TotalApprentices => By.CssSelector("table tbody tr");
        protected virtual By TotalCost => By.CssSelector(".dynamic-cost-display .bold-xlarge, .govuk-table__cell > strong");
        protected static By EditApprenticeLink => By.XPath("//a[contains(text(),'Edit')]");
        protected static By ViewApprenticeLink => By.XPath("//a[contains(text(),'View')]");

        protected ReviewYourCohort(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        protected List<IWebElement> TotalNoOfEditableApprentices() => pageInteractionHelper.FindElements(EditApprenticeLink);

        protected List<IWebElement> TotalNoOfViewableApprentices() => pageInteractionHelper.FindElements(ViewApprenticeLink);

        public int TotalNoOfApprentices() => TotalNoOfEditableApprentices().Count;

        public int TotalNoOfViewOnlyApprentices() => TotalNoOfViewableApprentices().Count;

        public string ApprenticeTotalCost() => pageInteractionHelper.GetText(TotalCost);
    }
}
