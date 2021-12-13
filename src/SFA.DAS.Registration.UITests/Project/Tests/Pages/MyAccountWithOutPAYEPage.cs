using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class MyAccountWithOutPayePage : RegistrationBasePage
    {
        protected override string PageTitle => "MY ACCOUNT";

        #region Locators
        private By AddYourPAYESchemeLink => By.CssSelector(".das-panel__link");
        #endregion

        public MyAccountWithOutPayePage(ScenarioContext context) : base(context) => VerifyPage();

        public AddAPAYESchemePage AddYourPAYEScheme()
        {
            formCompletionHelper.Click(AddYourPAYESchemeLink);
            return new AddAPAYESchemePage(_context);
        }
    }
}