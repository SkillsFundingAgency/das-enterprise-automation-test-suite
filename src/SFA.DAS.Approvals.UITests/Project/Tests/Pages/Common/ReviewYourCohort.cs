using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ReviewYourCohort : CohortReferenceBasePage
    {
        protected virtual By TotalApprentices => By.CssSelector("table tbody tr");

        protected virtual By TotalCost => By.CssSelector(".dynamic-cost-display .bold-xlarge, .govuk-table__cell > strong");

        public ReviewYourCohort(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        protected List<IWebElement> TotalNoOfEditableApprentices() => pageInteractionHelper.GetLinks("Edit");

        public int TotalNoOfApprentices() => TotalNoOfEditableApprentices().Count;

        public string ApprenticeTotalCost() => pageInteractionHelper.GetText(TotalCost);
    }
}
