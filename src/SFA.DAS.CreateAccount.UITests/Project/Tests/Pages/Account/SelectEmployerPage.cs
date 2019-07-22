using System.Collections.Generic;
using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    public class SelectEmployerPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private const string confirmSchemeButtonid = "continue";
        private const string agreeandcontinueid = "agree_and_continue";
        [FindsBy(How = How.ClassName, Using = "heading-xlarge")] private IWebElement _pageHeader;
        [FindsBy(How = How.Id, Using = "EmployerRef")] private IWebElement _companyHouseNumberInput;
        [FindsBy(How = How.Id, Using = "submit")] private IWebElement _submitButton;
        [FindsBy(How = How.Id, Using = confirmSchemeButtonid)] private IWebElement _confirmSchemeButton;
        [FindsBy(How = How.ClassName, Using = "error-summary-wrapper")] private IWebElement _errorForm;
        [FindsBy(How = How.Id, Using = agreeandcontinueid)] private IWebElement _agreeAndContinueButton;

        private readonly IWebDriver _webdriver;

        public SelectEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webdriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.GetText(_pageHeader) == "Enter your Companies House number";
        }

        internal SelectEmployerPage InputCompanyNumber(string number)
        {
            _formCompletionHelper.EnterText(_companyHouseNumberInput, number);
            return this;
        }

        internal SelectEmployerPage Submit()
        {
            _formCompletionHelper.ClickElement(_submitButton);
            return this;
        }

        internal EmployerAccountHomepage ConfirmScheme()
        {
            _formCompletionHelper.ClickElement(_confirmSchemeButton);
            return new EmployerAccountHomepage(_context);
        }

        internal bool IsErrorsExist()
        {
            return _errorForm.Displayed;
        }

        internal string[] GetErrors()
        {
            if (!IsErrorsExist())
            {
                return new string[0];
            }
            var errors = GetErrorMessagesFragments();
            return errors.Select((fragment) => fragment.Text).ToArray();
        }

        internal SignInGovernmentPage AgreeAndContinue()
        {
            _formCompletionHelper.ClickElement(_agreeAndContinueButton);
            return new SignInGovernmentPage(_context);
        }

        private ICollection<IWebElement> GetErrorMessagesFragments()
        {
            return _webdriver.FindElements(By.XPath(".//ul[@class=\"error-summary-list\"]//a"));
        }
    }
}