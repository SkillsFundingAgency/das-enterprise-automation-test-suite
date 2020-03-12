using OpenQA.Selenium;
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

        public OrganisationDetailsPage ReturnToOrganisationDetailsPage()
        {
            formCompletionHelper.ClickLinkByText("Return to organisation");
            return new OrganisationDetailsPage(_context);
        }
    }
}
