using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class FundingAnApprenticeshipPage(ScenarioContext context) : EmployerBasePage(context)
    {
        protected override string PageTitle => "Funding an apprenticeship";

        #region Page Object Element

        private readonly By __levyPayingEmployer = By.Id("levyPayerYes");
        private readonly By _nonLevyPayingEmployer = By.Id("levyPayerNo");
        private readonly By _continueButton = By.XPath("//button[contains(@class, 'button') and contains(text(), 'Continue')]");

        #endregion

        public NonLevyPayingEmployerPage NavigateToNonLevyEmployerPage()
        {
            formCompletionHelper.SelectCheckbox(_nonLevyPayingEmployer);
            formCompletionHelper.ClickElement(_continueButton);
            return new NonLevyPayingEmployerPage(context);
        }

        public LevyingPayingEmployerPage NavigateToLevyEmployerPage()
        {
            formCompletionHelper.SelectCheckbox(__levyPayingEmployer);
            formCompletionHelper.ClickElement(_continueButton);
            return new LevyingPayingEmployerPage(context);
        }

        public NotSureLevyPayingEmployerPage NavigateToNotSureLevyEmployerPage()
        {
            formCompletionHelper.SelectCheckbox(_nonLevyPayingEmployer);
            formCompletionHelper.ClickElement(_continueButton);
            return new NotSureLevyPayingEmployerPage(context);
        }
    }
}
