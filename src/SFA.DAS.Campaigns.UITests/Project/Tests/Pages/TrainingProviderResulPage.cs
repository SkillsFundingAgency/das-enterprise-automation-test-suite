using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    public class TrainingProviderResulPage :BasePage
    {
       protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RandomDataGenerator _randomDataGenerator;
        #endregion

        #region Constant
        private const string ExpectedProviderText = "There are";
        private const string ProviderPostCode = "CV1 4HS";
        #endregion

        #region Page Objects Elements
        // Hd to use xpath because duplicate id were present on page
        private readonly By _actualProviderText = By.XPath("//div[@class='page']/p[1]");
        private readonly By _firstApprenticeship = By.XPath("//button[@class='das-search-result__favourite-button--unchecked']");
        private readonly By _secondApprenticeship = By.XPath("//button[@class='das-search-result__favourite-button--unchecked']");
        #endregion
        public TrainingProviderResulPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();

         }

        public TrainingProviderResulPage VerifyProviderResult()
        {
            ExtractNumber();
            _pageInteractionHelper.VerifyText(_actualProviderText, ExpectedProviderText);
            return new TrainingProviderResulPage(_context);
        }

        public void ExtractNumber()
        {
         bool testflag = false;
        String _providerResultString = _pageInteractionHelper.GetText(_actualProviderText);
        string  _providerCount = "";
        char[] singleChar = _providerResultString.ToCharArray();
        foreach (char ch in singleChar)
        {
            if (char.IsDigit(ch))
            {

                _providerCount = _providerCount + ch.ToString();
                    testflag  = true;
            }
            else 
            {
                if (testflag)
                    {
                        break;
                    }
            }
        }

        int _numberOfProviders = Convert.ToInt32( _providerCount);
        if (_numberOfProviders <= 0)
            {
                throw new Exception("No Provider found");
            }
                
        }
        public TrainingProviderResulPage AddApprenticeshiptoFavouriteShortList()
        {

            _formCompletionHelper.ClickElement(_firstApprenticeship);
            _formCompletionHelper.ClickElement(_secondApprenticeship);
            return new TrainingProviderResulPage(_context);
        }
    }
}