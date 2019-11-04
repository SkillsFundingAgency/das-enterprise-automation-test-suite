using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class OrganisationSearchPage : BasePage
    {
        protected override string PageTitle => "Search for your organisation";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RegistrationConfig _config;
        private readonly ObjectContext _objectContext;
        #endregion

        private By SearchInput => By.Id("searchTerm");

        private By SearchButton => By.CssSelector("input.govuk-button");


        public OrganisationSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetRegistrationConfig<RegistrationConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public SelectYourOrganisationPage SearchForAnOrganisation()
        {
            EnterOrganisationName()
                .Search();
                return new SelectYourOrganisationPage(_context);
        }


        private OrganisationSearchPage EnterOrganisationName()
        {
            _formCompletionHelper.EnterText(SearchInput, _objectContext.GetOrganisationName());
            return this;
        }

        private OrganisationSearchPage Search()
        {
            _formCompletionHelper.ClickElement(SearchButton);
            return this;
        }
    }
}
