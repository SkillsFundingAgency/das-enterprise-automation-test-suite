using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAA_V2.Service.Project.Helpers;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class EmployerNameBasePage : RAAV2CSSBasePage
    {
        private readonly string _employerName;

        private By LegalEntityName => By.CssSelector("label[for='legal-entity-name']");

        private By NewTradingName => By.CssSelector("#NewTradingName");

        private By EmployerDescription => By.CssSelector("#AnonymousName");

        private By EmployerReason => By.CssSelector("#AnonymousReason");

        public EmployerNameBasePage(ScenarioContext context) : base(context) => _employerName = rAAV2DataHelper.EmployerName;

        public ChooseApprenticeshipLocationPage ChooseRegisteredName()
        {
            SelectRadioOptionByForAttribute(RAAV2Const.LegalEntityName);

            var entityName = pageInteractionHelper.GetText(LegalEntityName);

            SetEmployerName(EscapePatternHelper.StringEscapePattern(entityName, "(registered name)")?.Trim());

            Continue();
            return new ChooseApprenticeshipLocationPage(context);
        }

        public ChooseApprenticeshipLocationPage ChooseExistingTradingName()
        {
            SelectRadioOptionByForAttribute(RAAV2Const.ExistingTradingName);
            formCompletionHelper.EnterText(NewTradingName, _employerName);
            SetEmployerName(_employerName);
            Continue();
            return new ChooseApprenticeshipLocationPage(context);
        }

        public ChooseApprenticeshipLocationPage ChooseAnonymous()
        {
            SelectRadioOptionByForAttribute(RAAV2Const.Anonymous);
            formCompletionHelper.EnterText(EmployerDescription, rAAV2DataHelper.EmployerDescription);
            SetEmployerName(rAAV2DataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerReason, rAAV2DataHelper.EmployerReason);
            Continue();
            return new ChooseApprenticeshipLocationPage(context);
        }

        public EmployerDescriptionPage ChooseEmployerNameForEmployerJourney(string employername)
        {
            return employername switch
            {
                RAAV2Const.ExistingTradingName => ChooseExistingTradingNameAndGotoEmployerDescriptionPage(),
                RAAV2Const.Anonymous => ChooseAnonymousAndGotoEmployerDescriptionPage(),
                _ => ChooseRegisteredNameAndGotoEmployerDescriptionPage()
            };
        }

        private EmployerDescriptionPage ChooseRegisteredNameAndGotoEmployerDescriptionPage()
        {
            SelectRadioOptionByForAttribute("legal-entity-name");

            var entityName = pageInteractionHelper.GetText(LegalEntityName);

            SetEmployerName(EscapePatternHelper.StringEscapePattern(entityName, "(registered name)")?.Trim());

            Continue();

            return new EmployerDescriptionPage(context);
        }

        private EmployerDescriptionPage ChooseExistingTradingNameAndGotoEmployerDescriptionPage()
        {
            SelectRadioOptionByForAttribute("existing-trading-name");

            formCompletionHelper.EnterText(NewTradingName, _employerName);

            SetEmployerName(_employerName);

            Continue();

            return new EmployerDescriptionPage(context);
        }

        private EmployerDescriptionPage ChooseAnonymousAndGotoEmployerDescriptionPage()
        {
            SelectRadioOptionByForAttribute("anonymous");
            formCompletionHelper.EnterText(EmployerDescription, _employerName);
            SetEmployerName(_employerName);
            formCompletionHelper.EnterText(EmployerReason, rAAV2DataHelper.EmployerReason);
            Continue();
            return new EmployerDescriptionPage(context);
        }

        private void SetEmployerName(string value) => objectContext.SetEmployerName(value);
    }
}
