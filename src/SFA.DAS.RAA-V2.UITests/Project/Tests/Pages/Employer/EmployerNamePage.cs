using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class EmployerNamePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What employer name do you want to go on the vacancy?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NewTradingName => By.CssSelector("#NewTradingName");  

        private By EmployerDescription => By.CssSelector("#AnonymousName");

        private By EmployerReason => By.CssSelector("#AnonymousReason"); 

        public EmployerNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ChooseApprenticeshipLocationPage ChooseRegisteredName()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "legal-entity-name");
            _formCompletionHelper.Click(Continue);
            return new ChooseApprenticeshipLocationPage(_context);
        }

        public ChooseApprenticeshipLocationPage ChooseExistingTradingName()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "existing-trading-name");
            _formCompletionHelper.EnterText(NewTradingName, _dataHelper.EmployerTradingName);
            _formCompletionHelper.Click(Continue);
            return new ChooseApprenticeshipLocationPage(_context);
        }

        public ChooseApprenticeshipLocationPage ChooseAnonymous()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "anonymous");
            _formCompletionHelper.EnterText(EmployerDescription, _dataHelper.EmployerDescription);
            _formCompletionHelper.EnterText(EmployerReason, _dataHelper.EmployerReason);
            _formCompletionHelper.Click(Continue);
            return new ChooseApprenticeshipLocationPage(_context);
        }
    }
}
