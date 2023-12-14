using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YouCantApproveThisApprenticeRequestUntilPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-notification-banner__heading");
        protected override string PageTitle => "You can’t approve this apprentice request until:";

        protected virtual By Reference => By.CssSelector("dd.das-definition-list__definition:nth-child(4)");

        protected override By ContinueButton => By.CssSelector("#submitCohort button");

        private static By DraftSaveAndSubmit => By.Id("continue-button");

        public YouCantApproveThisApprenticeRequestUntilPage(ScenarioContext context) : base(context) { }

        public DynamicHomePages DraftReturnToHomePage()
        {
            var cohortReference = pageInteractionHelper.GetText(Reference);

            objectContext.SetCohortReference(cohortReference);

            SelectRadioOptionByForAttribute("radio-home");

            formCompletionHelper.ClickElement(DraftSaveAndSubmit);

            return new DynamicHomePages(context);
        }

    }
}