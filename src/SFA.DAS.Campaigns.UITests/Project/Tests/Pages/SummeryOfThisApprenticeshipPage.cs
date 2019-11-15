using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    public class SummeryOfThisApprenticeshipPage:BasePage
    {
       protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RandomDataGenerator _randomDataGenerator;
        #endregion

        #region Constant
        private const string ExpectedApprenticeshipSummaryHeader = "SUMMARY OF THIS APPRENTICESHIP";
        private const string ProviderPostCode = "CV1 4HS";
        #endregion

        #region Page Objects Elements
        // Hd to use xpath because duplicate id were present on page
        private readonly By _actualSummaryHeader = By.XPath("//h2[@class='heading-l u!-margin-top-0']");
        private readonly By _postcode =By.Id("Postcode");
        private readonly By _providerSearchButton=By.Id("employer-provider-search");
        #endregion
        public SummeryOfThisApprenticeshipPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();

         }
        public SummeryOfThisApprenticeshipPage VerifyTheSummargePage()
        {
            _pageInteractionHelper.VerifyText(_actualSummaryHeader,ExpectedApprenticeshipSummaryHeader);
            return new SummeryOfThisApprenticeshipPage(_context);
        }
        public SummeryOfThisApprenticeshipPage EnterProviderPostCode()
        {
            _formCompletionHelper.EnterText(_postcode,ProviderPostCode);
            return new SummeryOfThisApprenticeshipPage(_context);
        }
        public TrainingProviderResulPage ClickProviderSearchButton()
        {
            _formCompletionHelper.ClickElement(_providerSearchButton);
            return new  TrainingProviderResulPage(_context);
        }

    }
}