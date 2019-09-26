using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ReviewYourCohort : BasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        #endregion

        protected virtual By TotalApprentices => By.CssSelector("table tbody tr");

        protected virtual By TotalCost => By.CssSelector(".dynamic-cost-display .bold-xlarge");


        public ReviewYourCohort(ScenarioContext context) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public int TotalNoOfApprentices()
        {
            return pageInteractionHelper.FindElements(TotalApprentices).Count;
        }

        public string ApprenticeTotalCost()
        {
            return pageInteractionHelper.GetText(TotalCost);
        }
    }
}
