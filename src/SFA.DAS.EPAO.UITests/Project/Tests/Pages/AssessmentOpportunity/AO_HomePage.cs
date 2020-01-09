using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity
{
    public class AO_HomePage : BasePage
    {
        protected override string PageTitle => "Find an assessment opportunity";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        #region Locators
        private By ApprovedTab => By.Id("tab_approved");
        private By InDevelopmentTab => By.Id("tab_in-development");
        private By ProposedTab => By.Id("tab_proposed");
        private By TabHeader => By.CssSelector(".govuk-heading-m");
        private By AbattoirWorkerApprovedStandardLink => By.LinkText("Abattoir worker");
        private By BlacksmithInDevelopmentStandardLink => By.LinkText("Blacksmith");
        private By EquineAthleteProposedStandard => By.LinkText("Equine Athlete");
        #endregion

        public AO_HomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public void IsApprovedTabDisplayed() => _pageInteractionHelper.IsElementDisplayed(ApprovedTab);

        public string GetApprovedTabHeaderText() => _pageInteractionHelper.GetText(TabHeader);

        public AO_ApprovedStandardDetailsPage ClickOnAbattoirWorkerApprovedStandardLink()
        {
            _formCompletionHelper.Click(AbattoirWorkerApprovedStandardLink);
            return new AO_ApprovedStandardDetailsPage(_context);
        }

        public AO_HomePage ClickInDevelopmentTab()
        {
            _formCompletionHelper.Click(InDevelopmentTab);
            return this;
        }

        public AO_InDevelopmentStandardDetailsPage ClickOnBlacksmithInDevelopmentStandardLink()
        {
            _formCompletionHelper.Click(BlacksmithInDevelopmentStandardLink);
            return new AO_InDevelopmentStandardDetailsPage(_context);
        }

        public AO_HomePage ClickInProposedTab()
        {
            _formCompletionHelper.Click(ProposedTab);
            return this;
        }

        public AO_ProposedStandardDetailsPage ClickOnEquineAthleteProposedStandard()
        {
            _formCompletionHelper.Click(EquineAthleteProposedStandard);
            return new AO_ProposedStandardDetailsPage(_context);
        }
    }
}
