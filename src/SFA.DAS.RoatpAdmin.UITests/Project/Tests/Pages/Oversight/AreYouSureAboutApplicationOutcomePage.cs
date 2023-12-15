using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public abstract class AreYouSureAboutApplicationOutcomePage(ScenarioContext context) : RoatpNewAdminBasePage(context)
    {
        protected override By ContinueButton => By.CssSelector(".govuk-button");

        protected abstract string OversightAssessmentMessage { get; }

        public OversightAssessmentCompletePage SelectYesAskAndContinueOutcomePage()
        {
            SelectRadioOptionByForAttribute("Confirm");
            Continue();
            return new OversightAssessmentCompletePage(context, OversightAssessmentMessage);
        }
    }
}
