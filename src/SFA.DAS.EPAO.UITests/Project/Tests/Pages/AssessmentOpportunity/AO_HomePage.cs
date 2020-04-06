using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity
{
    public class AO_HomePage : EPAO_BasePage
    {
        protected override string PageTitle => "Find an assessment opportunity";
        private readonly ScenarioContext _context;

        #region Locators
        private By ApprovedTab => By.Id("tab_approved");
        private By InDevelopmentTab => By.Id("tab_in-development");
        private By ProposedTab => By.Id("tab_proposed");
        private By TabHeader => By.CssSelector(".govuk-heading-m");
        private By AbattoirWorkerApprovedStandardLink => By.LinkText("Abattoir worker");
        private By BookbinderInDevelopmentStandardLink => By.LinkText("Bookbinder");
        private By ClinicalScientistProposedStandard => By.LinkText("Clinical scientist");
        #endregion

        public AO_HomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public bool IsApprovedTabDisplayed() => pageInteractionHelper.IsElementDisplayed(ApprovedTab);

        public string GetApprovedTabHeaderText() => pageInteractionHelper.GetText(TabHeader);

        public AO_ApprovedStandardDetailsPage ClickOnAbattoirWorkerApprovedStandardLink()
        {
            formCompletionHelper.Click(AbattoirWorkerApprovedStandardLink);
            return new AO_ApprovedStandardDetailsPage(_context);
        }

        public AO_HomePage ClickInDevelopmentTab()
        {
            formCompletionHelper.Click(InDevelopmentTab);
            return this;
        }

        public AO_InDevelopmentStandardDetailsPage ClickOnInDevelopmentStandardLink()
        {
            formCompletionHelper.Click(BookbinderInDevelopmentStandardLink);
            return new AO_InDevelopmentStandardDetailsPage(_context);
        }

        public AO_HomePage ClickInProposedTab()
        {
            formCompletionHelper.Click(ProposedTab);
            return this;
        }

        public AO_ProposedStandardDetailsPage ClickOnAProposedStandard()
        {
            formCompletionHelper.Click(ClinicalScientistProposedStandard);
            return new AO_ProposedStandardDetailsPage(_context);
        }
    }
}
