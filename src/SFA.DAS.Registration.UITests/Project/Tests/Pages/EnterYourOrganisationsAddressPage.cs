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
    }
}
