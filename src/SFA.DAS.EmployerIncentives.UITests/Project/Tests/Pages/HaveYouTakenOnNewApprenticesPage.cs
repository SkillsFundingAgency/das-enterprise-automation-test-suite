using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class HaveYouTakenOnNewApprenticesPage : EIBasePage
    {
        protected override string PageTitle => "Have you taken on new apprentices that joined your payroll after 1 August 2020?";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public HaveYouTakenOnNewApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public YouCannotApplyForThisGrantYetPage SelectYesAndContinueForNoEligibleApprenticesScenario()
        {
            SelectRadioOptionByForAttribute("HasTakenOnNewApprentices");
            formCompletionHelper.Click(ContinueButton);
            return new YouCannotApplyForThisGrantYetPage(_context);
        }

        public YouCannotApplyForThisGrantYetPage SelectNoAndContinueForNoEligibleApprenticesScenario()
        {
            SelectRadioOptionByForAttribute("HasTakenOnNewApprentices-2");
            formCompletionHelper.Click(ContinueButton);
            return new YouCannotApplyForThisGrantYetPage(_context);
        }
    }
}
