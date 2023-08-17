using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class OversightAssessmentCompletePage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "outcome saved";

        private static By ConfirmationMessage => By.CssSelector(".govuk-panel__body");

        private static By GoToRoATPApplicationOutcomeLink => By.LinkText("Go to RoATP application outcomes");

        public OversightAssessmentCompletePage(ScenarioContext context, string outcome) : base(context)
        {
            pageInteractionHelper.InvokeAction(() => pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(ConfirmationMessage).ToUpper(), outcome.ToUpper()));
        }

        public OversightLandingPage GoToRoATPAssessorApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPApplicationOutcomeLink);
            return new OversightLandingPage(context);
        }
    }
}
