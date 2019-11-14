using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class CohortReferenceBasePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RegexHelper _regexHelper;
        #endregion

        private By Instructions => By.CssSelector(".govuk-summary-list__row, .instructionSent tbody");
        private By KeyIdentifier => By.CssSelector(".govuk-summary-list__key, tr > td");

        public CohortReferenceBasePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _regexHelper = context.Get<RegexHelper>();
        }

        public string CohortReference()
        {
            var reference = _pageInteractionHelper.GetRowData(Instructions, KeyIdentifier, "Reference", "Cohort reference");
            return _regexHelper.GetCohortReference(reference);
        }

        public string CohortReferenceFromUrl()
        {
            var url = _pageInteractionHelper.GetUrl();
            return _regexHelper.GetCohortReferenceFromUrl(url);
        }
    }
}