using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangeYourEmailAddressPage : RegistrationBasePage
    {
        protected override string PageTitle => "Change your email address";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.CssSelector(".button[value='Continue']");
        private By AddressFirstLineTextBox => By.Id("AddressFirstLine");
        #endregion

        public ChangeYourEmailAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}