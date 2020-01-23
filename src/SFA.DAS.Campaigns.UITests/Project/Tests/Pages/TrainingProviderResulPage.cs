using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions;
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
        private const string ExpectedProviderText = "We've found";
        private const string ProviderPostCode = "CV1 4HS";
        
        #endregion

        #region Page Objects Elements
        private readonly By _actaulProviderName=By.XPath("//h1[@class='heading-xl hero-heading__heading hero-heading__heading-l']");
        private readonly By _actualProviderText = By.XPath("//div[@class='das-search-results__header']/p");
        private readonly By _providerCount = By.Id("fat-tp-search-result-count");
        private readonly By _firstApprenticeship = By.XPath("//button[@class='das-search-result__favourite-button--unchecked']");
        private readonly By _secondApprenticeship = By.XPath("//button[@class='das-search-result__favourite-button--unchecked']");
        private readonly By _firstProvider = By.XPath("//button[@class='das-search-result__favourite-button--unchecked']");
        private readonly By _secondProvider = By.XPath("//button[@class='das-search-result__favourite-button--unchecked']");
        private readonly By _thirddProvider = By.XPath("//button[@class='das-search-result__favourite-button--unchecked']");
        private readonly By _saveApprenticeshipButton=By.XPath("//a[@class='button button--sparks button-employer']");
        private readonly By _providerTitleLink=By.XPath("//a[@class='link']");
        private readonly By _actualProviderTitle=By.XPath("//a[@class='link']");
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
            // bool testflag = false;
            String _providerResultString = _pageInteractionHelper.GetText(_providerCount);
         
            //string  _providerCount = "";
            //char[] singleChar = _providerResultString.ToCharArray();
            //foreach (char ch in singleChar)
            //{
            //    if (char.IsDigit(ch))
            //    {

            //        _providerCount = _providerCount + ch.ToString();
            //            testflag  = true;
            //    }
            //    else 
            //    {
            //        if (testflag)
            //            {
            //                break;
            //            }
            //    }
            //}

        
        int _numberOfProviders = int.Parse(_providerResultString);
        if (_numberOfProviders <= 0)
            {
                throw new Exception("No Provider found");
            }
                
        }
        public TrainingProviderResulPage AddFavouriteShortList()
        {
            
            _formCompletionHelper.ClickElement(_firstApprenticeship);
            _formCompletionHelper.ClickElement(_secondApprenticeship);
            return new TrainingProviderResulPage(_context);
        }

        public TrainingProviderResulPage ClickOnSaveApprenticeshipButton()
        {
            _formCompletionHelper.ClickElement(_saveApprenticeshipButton);
            return new TrainingProviderResulPage(_context);
        }

        public TrainingProviderResulPage ClickOnProviderTitleLink()
        {
             
            RunTimeVariable._providerTitleStored = _pageInteractionHelper.GetText(_providerTitleLink);
            _formCompletionHelper.ClickElement(_providerTitleLink);
            return new TrainingProviderResulPage(_context);
        }
        public TrainingProviderResulPage AddProviderToFavouriteShortList()
        {

            _formCompletionHelper.ClickElement(_firstProvider);
            _formCompletionHelper.ClickElement(_secondProvider);
            _formCompletionHelper.ClickElement(_thirddProvider);
            return new TrainingProviderResulPage(_context);
        }
        public TrainingProviderResulPage VerifyTrainingProviderNameFromTitle()
        {
            _pageInteractionHelper.VerifyText(_actaulProviderName,RunTimeVariable._providerTitleStored);
            return new TrainingProviderResulPage(_context);
        }
    }
}