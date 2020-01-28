using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD2_SearchResultsForPage : EPAO_BasePage
    {
        protected override string PageTitle => "Search results for";
        private readonly ScenarioContext _context;

        #region Locators
        private By OrgLink = By.XPath("//button[text()='BRUNEL UNIVERSITY LONDON']");
        #endregion

        public AP_OD2_SearchResultsForPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD3_SelectOrganisationTypePage ClickOrgLinkFromSearchResultsForPage()
        {
            formCompletionHelper.Click(OrgLink);
            Continue();
            return new AP_OD3_SelectOrganisationTypePage(_context);
        }
    }
}
