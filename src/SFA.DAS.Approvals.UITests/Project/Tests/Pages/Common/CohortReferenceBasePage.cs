using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class CohortReferenceBasePage : ApprovalsBasePage
    {
        private By Instructions => By.CssSelector(".govuk-summary-list__row, .instructionSent tbody");
        private By KeyIdentifier => By.CssSelector(".govuk-summary-list__key, tr > td");

        protected CohortReferenceBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }
    
        public string CohortReference() => RegexHelper.GetCohortReference(pageInteractionHelper.GetRowData(Instructions, KeyIdentifier, "Reference", "Cohort reference"));

        public string CohortReferenceFromUrl() => RegexHelper.GetCohortReferenceFromUrl(pageInteractionHelper.GetUrl());
    }
}