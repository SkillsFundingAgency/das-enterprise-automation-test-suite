using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class SelectYourOrganisationPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        #endregion

        private readonly IWebDriver _webDriver;

        private IWebElement SearchLinkUrl(string searchText) => _webDriver.FindElements(By.CssSelector("button.link-button")).ToList().First(x => x.GetAttribute("innerText") == searchText);

        public SelectYourOrganisationPage(ScenarioContext context): base(context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetProjectConfig<ProjectConfig>();
            VerifyPage();
        }

        protected override string PageTitle => "Select your organisation";

        public CheckYourDetailsPage SelectYourOrganisation()
        {
            _formCompletionHelper.ClickElement(SearchLinkUrl(_config.PP_OrganisationName.ToUpper()));
            return new CheckYourDetailsPage(_context);
        }
    }
}
