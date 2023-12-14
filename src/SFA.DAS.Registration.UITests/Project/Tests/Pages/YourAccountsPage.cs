using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourAccountsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Your accounts";

        #region Locators
        private static By AddNewAccountButton => By.Id("add_new_account");
        private static By OpenLink() => By.CssSelector("table a");

        #endregion

        public YourAccountsPage(ScenarioContext context) : base(context) => VerifyPage();

        public AddAPAYESchemePage AddNewAccount()
        {
            formCompletionHelper.ClickElement(AddNewAccountButton);
            return new AddAPAYESchemePage(context);
        }

        public HomePage GoToHomePage(string organisationName)
        {
            NavigateTo(organisationName);
            return new HomePage(context);
        }

        public HomePage ClickAccountLink(string orgName)
        {
            tableRowHelper.SelectRowFromTable("Open", orgName);
            objectContext.UpdateOrganisationName(orgName);
            return new HomePage(context);
        }

        public HomePage OpenAccount()
        {
            formCompletionHelper.Click(OpenLink());
            return new HomePage(context);
        }

        private void NavigateTo(string organisationName) => formCompletionHelper.ClickElement(SearchLinkUrl(organisationName));

        private IWebElement SearchLinkUrl(string searchText) => pageInteractionHelper.GetLinkContains(OpenLink(), searchText);
    }
}