using System.Linq;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.PublicSectorOrganization;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations
{
    public class AddAnOrganizationPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//form/section[1]")]
        private IWebElement _сompaniesHouseNumerRadioBtn;
        [FindsBy(How = How.XPath, Using = ".//form/section[2]")]
        private IWebElement _publicSectorOrganizationRadioBtn;
        [FindsBy(How = How.XPath, Using = ".//form/section[3]")]
        private IWebElement _registeredCharityRadioBtn;
        [FindsBy(How = How.XPath, Using = ".//form/section[4]")]
        private IWebElement _otherRadioBtn;
        [FindsBy(How = How.Id, Using = "CompaniesHouseNumber")] private IWebElement _companiesNumberInput;
        [FindsBy(How = How.Id, Using = "PublicBodyName")] private IWebElement _publicOrganizationNameInput;
        [FindsBy(How = How.Id, Using = "CharityRegistrationNumber")] private IWebElement _charityNumberInput;
        [FindsBy(How = How.Id, Using = "addOrganisation")] private IWebElement _continueButton;

        public AddAnOrganizationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.IsElementDisplayed(_continueButton);
        }

        internal UsingYourGovtGatewayDetailsPage SetByCompaniesHouseNumber(string number)
        {
            _formCompletionHelper.EnterText(_companiesNumberInput, number);
            _formCompletionHelper.ClickElement(_continueButton);
            return new UsingYourGovtGatewayDetailsPage(WebBrowserDriver);
        }

        internal AddAnOrganizationPage SetByPublicSector(string organizationName)
        {
            _formCompletionHelper.SelectRadioButton(_publicSectorOrganizationRadioBtn);
            _formCompletionHelper.EnterText(_publicOrganizationNameInput, organizationName);
            return this;
        }

        internal UsingYourGovtGatewayDetailsPage SetByCharityNumber(string number)
        {
            _formCompletionHelper.SelectRadioButton(_registeredCharityRadioBtn);
            _formCompletionHelper.EnterText(_charityNumberInput, number);
            _formCompletionHelper.ClickElement(_continueButton);
            return new UsingYourGovtGatewayDetailsPage(WebBrowserDriver);
        }

        internal EnterOrganizationNamePage SetByOtherOrganization()
        {
            _formCompletionHelper.SelectRadioButton(_otherRadioBtn);
            _formCompletionHelper.ClickElement(_continueButton);
            return new EnterOrganizationNamePage(WebBrowserDriver);
        }

        internal FindOrganizationAddressPage ContinueWithExistingOrganization()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new FindOrganizationAddressPage(WebBrowserDriver);
        }

        internal PublicSectorSearchPage ContinueWithNonExistingOrganization()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new PublicSectorSearchPage(WebBrowserDriver);
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//ul[@class=\"error-summary-list\"]//a"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}