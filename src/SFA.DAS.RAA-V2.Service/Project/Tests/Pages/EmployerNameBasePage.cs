using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class EmployerNameBasePage : RAAV2CSSBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By LegalEntityName => By.CssSelector("label[for='legal-entity-name']");

        private By NewTradingName => By.CssSelector("#NewTradingName");

        private By EmployerDescription => By.CssSelector("#AnonymousName");

        private By EmployerReason => By.CssSelector("#AnonymousReason");

        public EmployerNameBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ChooseApprenticeshipLocationPage ChooseRegisteredName()
        {
            SelectRadioOptionByForAttribute("legal-entity-name");

            var entityName = _pageInteractionHelper.GetText(LegalEntityName);

            SetEmployerName(EscapePatternHelper.StringEscapePattern(entityName, "(registered name)")?.Trim());

            Continue();
            return new ChooseApprenticeshipLocationPage(_context);
        }

        public ChooseApprenticeshipLocationPage ChooseExistingTradingName()
        {
            SelectRadioOptionByForAttribute("existing-trading-name");
            formCompletionHelper.EnterText(NewTradingName, rAAV2DataHelper.EmployerTradingName);
            SetEmployerName(rAAV2DataHelper.EmployerTradingName);
            Continue();
            return new ChooseApprenticeshipLocationPage(_context);
        }

        public ChooseApprenticeshipLocationPage ChooseAnonymous()
        {
            SelectRadioOptionByForAttribute("anonymous");
            formCompletionHelper.EnterText(EmployerDescription, rAAV2DataHelper.EmployerDescription);
            SetEmployerName(rAAV2DataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerReason, rAAV2DataHelper.EmployerReason);
            Continue();
            return new ChooseApprenticeshipLocationPage(_context);
        }

        private void SetEmployerName(string value) => _objectContext.SetEmployerName(value);
    }
}
