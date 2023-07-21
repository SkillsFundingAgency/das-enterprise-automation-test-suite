using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ViewYourCohort : CohortReferenceBasePage
    {
        protected virtual By TotalCost => By.CssSelector(".dynamic-cost-display .bold-xlarge, .govuk-table__cell > strong");
        protected static By ViewApprenticeLink => By.CssSelector("a.govuk-link.edit-apprentice");
        
        protected ViewYourCohort(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        protected List<IWebElement> TotalNoOfViewableApprentices() => pageInteractionHelper.FindElements(ViewApprenticeLink);

        public int TotalNoOfApprentices() => TotalNoOfViewableApprentices().Count;

        public string ApprenticeTotalCost() => pageInteractionHelper.GetText(TotalCost);
    }
}
