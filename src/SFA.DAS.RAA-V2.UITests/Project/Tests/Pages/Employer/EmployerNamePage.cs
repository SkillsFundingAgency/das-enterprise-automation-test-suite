using OpenQA.Selenium;
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
            SelectRadioOptionByForAttribute("legal-entity-name");
            Continue();
            return new ChooseApprenticeshipLocationPage(_context);
        }

        public ChooseApprenticeshipLocationPage ChooseExistingTradingName()
        {
            SelectRadioOptionByForAttribute("existing-trading-name");
            formCompletionHelper.EnterText(NewTradingName, dataHelper.EmployerTradingName);
            Continue();
            return new ChooseApprenticeshipLocationPage(_context);
        }

        public ChooseApprenticeshipLocationPage ChooseAnonymous()
        {
            SelectRadioOptionByForAttribute("anonymous");
            formCompletionHelper.EnterText(EmployerDescription, dataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerReason, dataHelper.EmployerReason);
            Continue();
            return new ChooseApprenticeshipLocationPage(_context);
        }
    }
}
