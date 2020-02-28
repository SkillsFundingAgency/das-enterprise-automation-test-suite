using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class FindOrganisationAddressPage : RegistrationBasePage
    {
        protected override string PageTitle => "Find organisation address";
        private readonly ScenarioContext _context;

        #region Locators
        private By EnterAddressManullyLink => By.LinkText("Enter address manually");
        #endregion

        public FindOrganisationAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EnterYourOrganisationsAddressPage ClickEnterAddressManullyLink()
        {
            formCompletionHelper.Click(EnterAddressManullyLink);
            return new EnterYourOrganisationsAddressPage(_context);
        }
    }
}
