using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourAccountsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Your accounts";
        private readonly ScenarioContext _context;

        #region Locators
        private By AddNewAccountButton => By.Id("add_new_account");
        private By OpenLink() => By.CssSelector("table a");
        private By AccountLink(string orgName) => By.XPath($"//span[@class='vh' and contains(text(), '{orgName}')]");

        #endregion

        public YourAccountsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UsingYourGovtGatewayDetailsPage AddNewAccount()
        {
            formCompletionHelper.ClickElement(AddNewAccountButton);
            return new UsingYourGovtGatewayDetailsPage(_context);
        }

        public HomePage GoToHomePage(string organisationName)
        {
            NavigateTo(organisationName);
            return new HomePage(_context);
        }

        public HomePage ClickAccountLink(string orgName)
        {
            formCompletionHelper.Click(AccountLink(orgName));
            objectContext.UpdateOrganisationName(orgName);
            return new HomePage(_context);
        }

        public HomePage OpenAccount()
        {
            formCompletionHelper.Click(OpenLink());
            return new HomePage(_context);
        }

        private void NavigateTo(string organisationName) => formCompletionHelper.ClickElement(SearchLinkUrl(organisationName));

        private IWebElement SearchLinkUrl(string searchText) => pageInteractionHelper.GetLinkContains(OpenLink(), searchText);
    }
}