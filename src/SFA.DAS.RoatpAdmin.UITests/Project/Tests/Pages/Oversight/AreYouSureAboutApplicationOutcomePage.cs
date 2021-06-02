using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public abstract class AreYouSureAboutApplicationOutcomePage : RoatpNewAdminBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".govuk-button");

        protected abstract string OversightAssessmentMessage { get; }

        public AreYouSureAboutApplicationOutcomePage(ScenarioContext context) : base(context) => _context = context;

        public OversightAssessmentCompletePage SelectYesAskAndContinueOutcomePage()
        {
            SelectRadioOptionByForAttribute("Confirm");
            Continue();
            return new OversightAssessmentCompletePage(_context, OversightAssessmentMessage);
        }
    }
}
