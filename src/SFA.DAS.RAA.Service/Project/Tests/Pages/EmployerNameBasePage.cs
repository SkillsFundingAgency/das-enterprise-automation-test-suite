using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class EmployerNameBasePage : RaaBasePage
    {
        private string _employerName;

        private static By LegalEntityName => By.CssSelector("label[for='new-trading-name']");

        private static By NewTradingName => By.CssSelector("#NewTradingName");

        private static By EmployerDescription => By.CssSelector("#AnonymousName");

        private static By EmployerReason => By.CssSelector("#AnonymousReason");

        public EmployerNameBasePage(ScenarioContext context) : base(context) => _employerName = rAADataHelper.EmployerName;

        public ChooseApprenticeshipLocationPage ChooseRegisteredName()
        {
            SelectRadioOptionByForAttribute(RAAConst.LegalEntityName);

            var entityName = pageInteractionHelper.GetText(LegalEntityName);

            SetEmployerName(EscapePatternHelper.StringEscapePattern(entityName, "(registered name)")?.Trim());

            Continue();
            return new ChooseApprenticeshipLocationPage(context);
        }

        public ChooseApprenticeshipLocationPage ChooseExistingTradingName()
        {
            SelectRadioOptionByForAttribute(RAAConst.ExistingTradingName);
            formCompletionHelper.EnterText(NewTradingName, _employerName);
            SetEmployerName(_employerName);
            Continue();
            return new ChooseApprenticeshipLocationPage(context);
        }

        public ChooseApprenticeshipLocationPage ChooseAnonymous()
        {
            SelectRadioOptionByForAttribute(RAAConst.Anonymous);
            formCompletionHelper.EnterText(EmployerDescription, rAADataHelper.EmployerDescription);
            SetEmployerName(rAADataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerReason, rAADataHelper.EmployerReason);
            Continue();
            return new ChooseApprenticeshipLocationPage(context);
        }

        public EmployerDescriptionPage ChooseEmployerNameForEmployerJourney(string employername)
        {
            return employername switch
            {
                RAAConst.ExistingTradingName => ChooseExistingTradingNameAndGotoEmployerDescriptionPage(),
                RAAConst.Anonymous => ChooseAnonymousAndGotoEmployerDescriptionPage(),
                _ => ChooseRegisteredNameAndGotoEmployerDescriptionPage()
            };
        }

        private EmployerDescriptionPage ChooseRegisteredNameAndGotoEmployerDescriptionPage()
        {
            SelectRadioOptionByForAttribute("legal-entity-name");

            SetLegalEntityAsEmployerName();

            return GoToEmployerDescriptionPage();
        }

        private void SetLegalEntityAsEmployerName()
        {
            var entityName = pageInteractionHelper.GetText(LegalEntityName);

            _employerName = EscapePatternHelper.StringEscapePattern(entityName, "(registered name)")?.Trim();
        }

        private EmployerDescriptionPage ChooseExistingTradingNameAndGotoEmployerDescriptionPage()
        {
            SelectRadioOptionByForAttribute("existing-trading-name");

            formCompletionHelper.EnterText(NewTradingName, _employerName);

            return GoToEmployerDescriptionPage();
        }

        private EmployerDescriptionPage ChooseAnonymousAndGotoEmployerDescriptionPage()
        {
            SelectRadioOptionByForAttribute("anonymous");

            formCompletionHelper.EnterText(EmployerDescription, rAADataHelper.EmployerDescription);

            formCompletionHelper.EnterText(EmployerReason, rAADataHelper.EmployerReason);

            SetLegalEntityAsEmployerName();

            return GoToEmployerDescriptionPage(rAADataHelper.EmployerDescription);
        }

        private EmployerDescriptionPage GoToEmployerDescriptionPage() => GoToEmployerDescriptionPage(_employerName);

        private EmployerDescriptionPage GoToEmployerDescriptionPage(string employerNameAsShownInTheAdvert)
        {
            SetEmployerName(_employerName);
            objectContext.SetEmployerNameAsShownInTheAdvert(employerNameAsShownInTheAdvert);
            Continue();
            return new EmployerDescriptionPage(context);
        }

        private void SetEmployerName(string value) => objectContext.SetEmployerName(value);
    }
}
