using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class EmployerNamePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What employer name do you want to go on the vacancy?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
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
        }

        public ChooseApprenticeshipLocationPage ChooseRegisteredName()
        {
            SelectRadioOptionByForAttribute("legal-entity-name");
            var entityName = _pageInteractionHelper.GetText(LegalEntityName);
            SetEmployerName(entityName);
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
