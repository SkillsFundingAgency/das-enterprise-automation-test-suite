using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class MyAccountWithOutPayePage : RegistrationBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "MY ACCOUNT";

        #region Locators
        private By AddYourPAYESchemeLink => By.CssSelector(".das-panel__link");
        #endregion

        public MyAccountWithOutPayePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AddAPAYESchemePage AddYourPAYEScheme()
        {
            formCompletionHelper.Click(AddYourPAYESchemeLink);
            return new AddAPAYESchemePage(_context);
        }
    }
}