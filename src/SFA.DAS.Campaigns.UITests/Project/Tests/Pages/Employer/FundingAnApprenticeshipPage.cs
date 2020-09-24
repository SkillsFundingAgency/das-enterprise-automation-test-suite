using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class FundingAnApprenticeshipPage : EmployerBasePage
    {
        protected override string PageTitle => "Page not found";

        #region Page Object Element

        private readonly By __levyPayingEmployer= By.Id("levyPayerYes");
        private readonly By _nonLevyPayingEmployer = By.Id("levyPayerNo");
        private readonly By _notSure = By.Id("levyPayerDontKnow");
        private readonly By _continueButton = By.XPath("//button[contains(@class, 'button') and contains(text(), 'Continue')]");
        private readonly ScenarioContext _context;
        #endregion

        public FundingAnApprenticeshipPage(ScenarioContext context) : base(context)
        {
            _context = context;
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }

        public NonLevyPayingEmployerPage NavigateToNonLevyEmployerPage()
        {
            formCompletionHelper.SelectCheckbox(_nonLevyPayingEmployer);
            formCompletionHelper.ClickElement(_continueButton);
            return new NonLevyPayingEmployerPage(_context);
        }
        public LevyingPayingEmployerPage NavigateToLevyEmployerPage()
        {
            formCompletionHelper.SelectCheckbox(__levyPayingEmployer);
            formCompletionHelper.ClickElement(_continueButton);
            return new LevyingPayingEmployerPage(_context);
        }
        public NotSureLevyPayingEmployerPage NavigateToNotSureLevyEmployerPage()
        {
            formCompletionHelper.SelectCheckbox(_nonLevyPayingEmployer);
            formCompletionHelper.ClickElement(_continueButton);
            return new NotSureLevyPayingEmployerPage(_context);
        }
    }
}
