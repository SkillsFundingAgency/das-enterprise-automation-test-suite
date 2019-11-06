using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal class RegisterMyInterestPage : BasePage
    {
        protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RandomDataGenerator _randomDataGenerator;
        #endregion

        #region Constants
        private const string ExpectedHelpShapeTheirCareerHeader = "REGSITER MY INTEREST";
        private const string FirstName = "John";
        private const string LastName = "Brown";
        #endregion

        #region Page Objects Elements
        private readonly By _helpShapeTheirCareerHeader = By.ClassName("heading-xl");
       // private readonly By _firstNameField =By.Id("FirstName");
        private readonly By _firstNameField =By.XPath("(//input[@id='FirstName'])[2]");
        private readonly By _lastNameField =By.XPath("(//input[@id='LastName'])[2]");
        //private readonly By _lastNamFied = By.Id("LastName");
        private readonly By _emailField =By.XPath("(//input[@id='Email'])[2]");
        private readonly By _radioButtonApprentice=By.XPath("(//input[@id='rbApprentice'])[2]");
        private readonly By _radioButtonEmployer=By.XPath("(//input[@id='rbEmployer'])[2]");
        //private readonly By _checkBoxTAndCs=By.XPath("(input[@id='AcceptTandCs'])[2]");
        private readonly By _checkBoxTAndCs=By.XPath("(//input[@id='AcceptTandCs'])[2]");
        //(//input[@id='btn-register-interest-complete'])[2]
        private readonly By _registerMyInterestButton = By.XPath("(//button [@id='btn-register-interest-complete'])[2]");
        #endregion

        public RegisterMyInterestPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();

         }

         public RegisterMyInterestPage EnterDetail()
         {
            string _first = _randomDataGenerator.GenerateRandomAlphabeticString(4);
            string _lastchar =_randomDataGenerator.GenerateRandomAlphabeticString(4);
            string _email = _randomDataGenerator.GenerateRandomEmail();
            //_pageInteractionHelper.IsElementPresent(_checkBoxTAndCs);
            _pageInteractionHelper.IsElementDisplayed(_firstNameField);
            _formCompletionHelper.EnterText(_firstNameField,FirstName + _first);
             _formCompletionHelper.EnterText(_lastNameField,LastName + _lastchar);
             _formCompletionHelper.EnterText(_emailField, _email);
             return new RegisterMyInterestPage(_context);
         }    
        public RegisterMyInterestPage TickIWantToBecomeAnApprentice()
        {
            _formCompletionHelper.SelectRadioButton(_radioButtonApprentice);
            return new RegisterMyInterestPage(_context);
        }

        public RegisterMyInterestPage TickIWantToEmployAnApprentice()
        {
            _formCompletionHelper.SelectRadioButton(_radioButtonApprentice);
            return new RegisterMyInterestPage(_context);
        }
        public RegisterMyInterestPage CheckTheTAndCsCheckBox()
        {
            _formCompletionHelper.SelectRadioButton(_checkBoxTAndCs);
            return new RegisterMyInterestPage(_context);
        }

        public RegisterMyInterestSuccessPage ClickOnRegisterMyInterest()
        {
            _formCompletionHelper.ClickElement(_registerMyInterestButton);
            return new RegisterMyInterestSuccessPage(_context);
        }
    }
 }
