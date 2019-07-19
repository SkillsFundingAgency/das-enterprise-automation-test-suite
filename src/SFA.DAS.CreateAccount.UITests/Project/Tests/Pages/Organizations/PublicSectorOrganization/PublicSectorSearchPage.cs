using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.PublicSectorOrganization
{
    internal class PublicSectorSearchPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'add it manually here\')]")] private IWebElement _addManuallyButton;

        public PublicSectorSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public FindOrganizationAddressPage PickFirstOrganization()
        {
            var link = WebBrowserDriver.FindElement(By.XPath(".//ol[@class=\"search-results\"]/li[1]//button"));
            _formCompletionHelper.ClickElement(link);
            return new FindOrganizationAddressPage(_context);
        }

        public string GetFirstOrganizationName()
        {
            var link = WebBrowserDriver.FindElement(By.XPath(".//ol[@class=\"search-results\"]/li[1]"));
            _formCompletionHelper.ClickElement(link);
            return link.Text;
        }

        public EnterOrganizationNamePage SetOrganizationManually()
        {
            _formCompletionHelper.ClickElement(_addManuallyButton);
            return new EnterOrganizationNamePage(_context);
        }
    }
}