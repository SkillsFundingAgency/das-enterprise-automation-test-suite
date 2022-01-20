using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class EmployerNameBasePage : RAAV2CSSBasePage
    {
        private By LegalEntityName => By.CssSelector("label[for='legal-entity-name']");

        private By NewTradingName => By.CssSelector("#NewTradingName");

        private By EmployerDescription => By.CssSelector("#AnonymousName");

        private By EmployerReason => By.CssSelector("#AnonymousReason");

        public EmployerNameBasePage(ScenarioContext context) : base(context) { }

        public ChooseApprenticeshipLocationPage ChooseRegisteredName()
        {
            SelectRadioOptionByForAttribute("legal-entity-name");

            var entityName = pageInteractionHelper.GetText(LegalEntityName);

            SetEmployerName(EscapePatternHelper.StringEscapePattern(entityName, "(registered name)")?.Trim());

            Continue();
            return new ChooseApprenticeshipLocationPage(context);
        }

        public ChooseApprenticeshipLocationPage ChooseExistingTradingName()
        {
            SelectRadioOptionByForAttribute("existing-trading-name");
            formCompletionHelper.EnterText(NewTradingName, rAAV2DataHelper.EmployerTradingName);
            SetEmployerName(rAAV2DataHelper.EmployerTradingName);
            Continue();
            return new ChooseApprenticeshipLocationPage(context);
        }

        public ChooseApprenticeshipLocationPage ChooseAnonymous()
        {
            SelectRadioOptionByForAttribute("anonymous");
            formCompletionHelper.EnterText(EmployerDescription, rAAV2DataHelper.EmployerDescription);
            SetEmployerName(rAAV2DataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerReason, rAAV2DataHelper.EmployerReason);
            Continue();
            return new ChooseApprenticeshipLocationPage(context);
        }

        private void SetEmployerName(string value) => objectContext.SetEmployerName(value);
    }
}
