using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ReviewYourCohort : CohortReferenceBasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        #endregion

        protected virtual By TotalApprentices => By.CssSelector("table tbody tr");

        protected virtual By TotalCost => By.CssSelector(".dynamic-cost-display .bold-xlarge, .govuk-table__cell > strong");

        public ReviewYourCohort(ScenarioContext context) : base(context) => pageInteractionHelper = context.Get<PageInteractionHelper>();

        protected List<IWebElement> TotalNoOfEditableApprentices() => pageInteractionHelper.GetLinks("Edit");

        public int TotalNoOfApprentices() => TotalNoOfEditableApprentices().Count;

        public string ApprenticeTotalCost() => pageInteractionHelper.GetText(TotalCost);
    }
}
