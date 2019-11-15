using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    public class FindTheRightApprenticeshipResultPage: BasePage
    {
        protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RandomDataGenerator _randomDataGenerator;
        #endregion

        #region Constants
        private const string ExpectedSearchResultPageHeader = "SEARCH RESULT";
        private const string ExpectedSearchResultText = "All apprenticeships";
        #endregion

        #region Page Objects Elements
        // Hd to use xpath because duplicate id were present on page
        private readonly By _actualSearchResultPageHeader = By.ClassName("heading-xl");
        private readonly By _actualSearchResultText =By.ClassName("das-search-results__header-results-header-text");

        private readonly By _firstNameField =By.XPath("(//input[@id='FirstName'])[2]");
        private readonly By _lastNameField =By.XPath("(//input[@id='LastName'])[2]");
        private readonly By _emailField =By.XPath("(//input[@id='Email'])[2]");
        private readonly By _radioButtonApprentice=By.XPath("(//input[@id='rbApprentice'])[2]");
        private readonly By _radioButtonEmployer=By.XPath("(//input[@id='rbEmployer'])[2]");
        private readonly By _checkBoxTAndCs=By.XPath("(//input[@id='AcceptTandCs'])[2]");
        private readonly By _registerMyInterestButton = By.XPath("(//button [@id='btn-register-interest-complete'])[2]");
        #endregion
        public FindTheRightApprenticeshipResultPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();

         }

        public FindTheRightApprenticeshipResultPage CheckSearchResultPageHeader()
        {
            _pageInteractionHelper.VerifyText(_actualSearchResultPageHeader,ExpectedSearchResultPageHeader);
            return new FindTheRightApprenticeshipResultPage(_context);
        }

        public FindTheRightApprenticeshipResultPage VerifyTheSearchResult()
        {
            _pageInteractionHelper.VerifyText(_actualSearchResultText,ExpectedSearchResultText);
            return new FindTheRightApprenticeshipResultPage(_context);
        }

    }
}