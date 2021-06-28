using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderConfirmEmployerNonLevyPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm employer";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SaveAndContinueButton = By.XPath("//button[contains(text(),'Save and continue')]");

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ProviderConfirmEmployerNonLevyPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderApprenticeshipTrainingPage ConfirmNonLevyEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-yes");
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderApprenticeshipTrainingPage(_context);
        }

        internal ProviderReviewYourCohortPage ConfirmEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-true");            
            formCompletionHelper.ClickElement(ContinueButton);
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}
