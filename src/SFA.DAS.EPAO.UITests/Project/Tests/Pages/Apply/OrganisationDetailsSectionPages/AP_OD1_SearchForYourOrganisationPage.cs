using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD1_SearchForYourOrganisationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Search for your organisation";
        private readonly ScenarioContext _context;

        #region Locators
        private By SearchTextBox => By.Id("SearchString");
        #endregion

        public AP_OD1_SearchForYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD2_SearchResultsForPage EnterOrgNameAndSearchInSearchForYourOrgPage()
        {
            formCompletionHelper.EnterText(SearchTextBox, "Brunel");
            Continue();
            return new AP_OD2_SearchResultsForPage(_context);
        }
    }
}
