using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Helpers;
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
        private readonly By  _firstNameField =By.Id("FirstName");
        private readonly By _lastNameField =By.Id("LastName");
        private readonly By _emailField =By.Id("Email");
        private readonly By _radioButtonApprentice=By.Id("rbApprentice");
        private readonly By _radioButtonEmployAnApprentice = By.Id("rbEmployer");
        private readonly By _radioButtonEmployer=By.Id("rbEmployer");
        private readonly By _checkBoxTAndCs=By.Id("AcceptTandCs");
        private readonly By _noIamHappyToStayOnThisPage = By.Id("alert-countries-stay");
        private readonly By _registerMyInterestButton = By.Id("btn-register-interest-complete");
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
            var runTimeVariable = new RunTimevariable();
            string _email = _randomDataGenerator.GenerateRandomEmail();
            _pageInteractionHelper.IsElementDisplayed(_firstNameField);
            _formCompletionHelper.EnterText(_firstNameField, runTimeVariable.GetEmployerFirstname(FirstName));
            _formCompletionHelper.EnterText(_lastNameField, runTimeVariable.GetEmployerLastname(LastName));
            _formCompletionHelper.EnterText(_emailField, _email);

            return new RegisterMyInterestPage(_context);
         }    
        public RegisterMyInterestPage TickIWantToBecomeAnApprentice()
        {
            _formCompletionHelper.SelectRadioButton(_radioButtonApprentice);
            return new RegisterMyInterestPage(_context);
        }

        public ThanksForSubScribingPage TickIWantToEmployAnApprentice()
        {
            _formCompletionHelper.SelectRadioButton(_radioButtonEmployAnApprentice);
            return new ThanksForSubScribingPage(_context);
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

        public RegisterMyInterestPage RemoveTheAlertBanner()
        {
            _formCompletionHelper.ClickElement(_noIamHappyToStayOnThisPage);
            return new RegisterMyInterestPage(_context);
        }
    }
 }
