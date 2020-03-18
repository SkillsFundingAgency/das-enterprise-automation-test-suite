using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public abstract class OrganisationSectionsBasePage : EPAOAdmin_BasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OrganisationSectionsBasePage(ScenarioContext context) : base(context) => _context = context;

        protected OrganisationDetailsPage ReturnToOrganisationDetailsPage(Action action)
        {
            action();
            return new OrganisationDetailsPage(_context);
        }
    }
}
