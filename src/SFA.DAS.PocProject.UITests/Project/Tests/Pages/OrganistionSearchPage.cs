using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class OrganistionSearchPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        #endregion

        private By SearchInput => By.Id("searchTerm");

        private By SearchButton => By.CssSelector("input.button");


        public OrganistionSearchPage(ScenarioContext context) : base(context)
        {
            _config = context.Get<ProjectSpecificConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => "Search for your organisation";

        public CheckYourDetailspage SearchForAnOrganisation()
        {
            EnterOrganisationName()
                .Search();
                return new CheckYourDetailspage(_context);
        }


        private OrganistionSearchPage EnterOrganisationName()
        {
            _formCompletionHelper.EnterText(SearchInput, "ESFA");
            return this;
        }

        private OrganistionSearchPage Search()
        {
            _formCompletionHelper.ClickElement(SearchButton);
            return this;
        }
    }
}
