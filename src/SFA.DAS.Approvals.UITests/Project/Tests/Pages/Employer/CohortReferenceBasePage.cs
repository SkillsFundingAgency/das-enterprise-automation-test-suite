using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public abstract class CohortReferenceBasePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RegexHelper _regexHelper;
        #endregion

        private By Instructions => By.CssSelector(".instructionSent tbody");

        public CohortReferenceBasePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _regexHelper = context.Get<RegexHelper>();
            VerifyPage();
        }

        public string CohortReference()
        {
            var reference = _pageInteractionHelper.GetRowData(Instructions, "Cohort reference");
            return _regexHelper.GetCohortReference(reference);
        }
    }
}