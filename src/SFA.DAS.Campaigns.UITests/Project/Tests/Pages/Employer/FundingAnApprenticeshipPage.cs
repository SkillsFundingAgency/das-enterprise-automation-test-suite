using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class FundingAnApprenticeshipPage : EmployerBasePage
    {
        protected override string PageTitle => "FUNDING AN APPRENTICESHIP";

        #region Page Object Element
        private readonly By _subHeading5 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Apprenticeships in Scotland, Northern Ireland and Wales')]");
        private readonly By _continueButton = By.XPath("//button[contains(@class, 'button') and contains(text(), 'Continue')]");
        private readonly ScenarioContext _context;
        #endregion

        public FundingAnApprenticeshipPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyHeadings();
        }

        private void VerifyHeadings()
        { 
            pageInteractionHelper.VerifyText(_subHeading5, "APPRENTICESHIPS IN SCOTLAND, NORTHERN IRELAND AND WALES");
        }

        public FundingAnApprenticeshipForNonLevyEmployerPage ClickContinueButton()
        {
            formCompletionHelper.ClickElement(_continueButton);
            return new FundingAnApprenticeshipForNonLevyEmployerPage(_context);
        }
    }
}
