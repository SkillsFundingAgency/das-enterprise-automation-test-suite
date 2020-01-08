using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SelectYourOrganisationPage : BasePage
    {
        protected override string PageTitle => "Select your organisation";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RegistrationConfig _config;
        private readonly ObjectContext _objectContext;
        #endregion

        private By OrganisationLink() => By.CssSelector("button[type=submit]");

        public SelectYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetRegistrationConfig<RegistrationConfig>();
            VerifyPage();
        }

        public CheckYourDetailsPage SelectYourOrganisation()
        {
            _formCompletionHelper.ClickElement(SearchLinkUrl(_objectContext.GetOrganisationName()));
            return new CheckYourDetailsPage(_context);
        }

        private IWebElement SearchLinkUrl(string searchText) => _pageInteractionHelper.GetLink(OrganisationLink(), searchText);
    }
}
