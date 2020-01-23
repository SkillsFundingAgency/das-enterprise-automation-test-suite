using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EmployerNamePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What employer name do you want to go on the vacancy?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RegexHelper _regexHelper;
        #endregion

        private By LegalEntityName => By.CssSelector("label[for='legal-entity-name']");

        private By NewTradingName => By.CssSelector("#NewTradingName");  

        private By EmployerDescription => By.CssSelector("#AnonymousName");

        private By EmployerReason => By.CssSelector("#AnonymousReason");

        public EmployerNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _regexHelper = context.Get<RegexHelper>();
        }

        public ChooseApprenticeshipLocationPage ChooseRegisteredName()
        {
            SelectRadioOptionByForAttribute("legal-entity-name");

            var entityName = _pageInteractionHelper.GetText(LegalEntityName);

            SetEmployerName(_regexHelper.Remove(entityName, "(registered name)")?.Trim());

            Continue();
            return new ChooseApprenticeshipLocationPage(_context);
        }

        public ChooseApprenticeshipLocationPage ChooseExistingTradingName()
        {
            SelectRadioOptionByForAttribute("existing-trading-name");
            formCompletionHelper.EnterText(NewTradingName, dataHelper.EmployerTradingName);
            SetEmployerName(dataHelper.EmployerTradingName);
            Continue();
            return new ChooseApprenticeshipLocationPage(_context);
        }

        public ChooseApprenticeshipLocationPage ChooseAnonymous()
        {
            SelectRadioOptionByForAttribute("anonymous");
            formCompletionHelper.EnterText(EmployerDescription, dataHelper.EmployerDescription);
            SetEmployerName(dataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerReason, dataHelper.EmployerReason);
            Continue();
            return new ChooseApprenticeshipLocationPage(_context);
        }

        private void SetEmployerName(string value)
        {
            _objectContext.SetEmployerName(value);
        }
    }
}
