using System.Linq;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.PublicSectorOrganization;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    internal class EnterOrganizationNamePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "Name")] private IWebElement _nameInput;
        [FindsBy(How = How.Id, Using = "accept")] private IWebElement _continueButton;

        public EnterOrganizationNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public EnterOrganizationNamePage SetName(string name)
        {
            _formCompletionHelper.EnterText(_nameInput, name);
            return this;
        }

        public OrganizationAddressPage Continue()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new OrganizationAddressPage(_context);
        }

        public FindOrganizationAddressPage ContinueWithFindOrganizationAddress()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new FindOrganizationAddressPage(_context);
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//*[@class=\"error-summary\"]//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}