using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class CohortReferenceBasePage : ApprovalsBasePage
    {
        private By Instructions => By.CssSelector(".govuk-summary-list__row, .instructionSent tbody");
        private By KeyIdentifier => By.CssSelector(".govuk-summary-list__key, tr > td");

        public CohortReferenceBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }
    
        public string CohortReference()
        {
            var reference = pageInteractionHelper.GetRowData(Instructions, KeyIdentifier, "Reference", "Cohort reference");
            return regexHelper.GetCohortReference(reference);
        }

        public string CohortReferenceFromUrl()
        {
            var url = pageInteractionHelper.GetUrl();
            return regexHelper.GetCohortReferenceFromUrl(url);
        }
    }
}