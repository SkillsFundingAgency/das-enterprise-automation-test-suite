using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EnterYourOrganisationsAddressPage : RegistrationBasePage
    {
        protected override string PageTitle => "Enter your organisation's address";
        private readonly ScenarioContext _context;
        private readonly RegistrationDataHelper _registrationDataHelper;

        #region Locators
        protected override By ContinueButton => By.CssSelector(".button[value='Continue']");
        private By AddressFirstLineTextBox => By.Id("AddressFirstLine");
        private By TownOrCityTextBox => By.Id("TownOrCity");
        private By PostcodeTextBox => By.Id("Postcode");
        private By ErrorMessageAboveAddressLine1TextBox => By.XPath("//span[text()='Enter house number or name, building or street']");
        private By ErrorMessageAboveCityTextBox => By.XPath("//span[text()='Enter town or city']");
        private By ErrorMessageAbovePostcodeTextBox => By.XPath("//span[text()='Enter a valid postcode']");
        private By AddressLine1ErrorMessageAtHeader => By.LinkText("Enter house number or name, building or street");
        private By CityErrorMessageAtHeader => By.LinkText("Enter town or city");
        private By PostCodeErrorMessageAtHeader => By.LinkText("Enter a valid postcode");
        #endregion

        public EnterYourOrganisationsAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            VerifyPage();
        }

        public CheckYourDetailsPage EnterAddressDetailsAndContinue()
        {
            formCompletionHelper.EnterText(AddressFirstLineTextBox, _registrationDataHelper.FirstLineAddressForManualEntry);
            formCompletionHelper.EnterText(TownOrCityTextBox, _registrationDataHelper.CityNameForManualEntry);
            formCompletionHelper.EnterText(PostcodeTextBox, _registrationDataHelper.PostCodeForManualEntry);
            Continue();
            return new CheckYourDetailsPage(_context);
        }

        public EnterYourOrganisationsAddressPage ClickContinueWithOutEnteringDetailsInEnterYourOrganisationsAddressPage()
        {
            Continue();
            return this;
        }

        public EnterYourOrganisationsAddressPage VerifyErrorMessagesInEnterYourOrganisationsAddressPage()
        {
            VerifyPage(ErrorMessageAboveAddressLine1TextBox);
            VerifyPage(ErrorMessageAboveCityTextBox);
            VerifyPage(ErrorMessageAbovePostcodeTextBox);
            VerifyPage(AddressLine1ErrorMessageAtHeader);
            VerifyPage(CityErrorMessageAtHeader);
            VerifyPage(PostCodeErrorMessageAtHeader);
            return this;
        }
    }
}
