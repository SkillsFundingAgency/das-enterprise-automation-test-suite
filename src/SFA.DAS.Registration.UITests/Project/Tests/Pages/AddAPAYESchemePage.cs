using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AddAPAYESchemePage : RegistrationBasePage
    {
        protected override string PageTitle => "Add a PAYE Scheme";

        #region Locators
        private static By AddPayeRadioButton => By.CssSelector("label[for=want-to-add-paye-scheme]");
        private static By UseAORNRadioButton => By.CssSelector("label[for=want-to-add-paye-scheme-aorn]");
        protected override By ContinueButton => By.Id("submit-add-a-paye-scheme-button");
        #endregion

        public AddAPAYESchemePage(ScenarioContext context) : base(context) => VerifyPage();

        public UsingYourGovtGatewayDetailsPage AddPaye()
        {
            SelectAddPaye().Continue();

            return new UsingYourGovtGatewayDetailsPage(context);
        }

        public EnterYourPAYESchemeDetailsPage AddAORN()
        {
            SelectAORN().Continue();

            return new EnterYourPAYESchemeDetailsPage(context);
        }

        private AddAPAYESchemePage SelectAddPaye()
        {
            formCompletionHelper.ClickElement(AddPayeRadioButton);
            return this;
        }

        private AddAPAYESchemePage SelectAORN()
        {
            formCompletionHelper.ClickElement(UseAORNRadioButton);
            return this;
        }
    }
}