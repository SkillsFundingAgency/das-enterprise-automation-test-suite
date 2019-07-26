using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
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
        private readonly ProjectSpecificConfig _config;
        #endregion

        private By SearchLinkUrl(string searchText) => By.LinkText(searchText);

        public SelectYourOrganisationPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetConfigSection<ProjectSpecificConfig>();
            VerifyPage();
        }

        protected override string PageTitle => "Select your organisation";

        public CheckYourDetailspage OpenSearchLink()
        {
            _formCompletionHelper.ClickElement(SearchLinkUrl(_config.OrganisationName));
            return new CheckYourDetailspage(_context);
        }

    }
}
