using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages
{
    public class AP_PR1_SearchForYourOrganisationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Search for your organisation";
        private readonly ScenarioContext _context;

        #region Locators
        private By SearchTextBox => By.Id("SearchString");
        #endregion

        public AP_PR1_SearchForYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_PR2_SearchResultsForPage EnterOrgNameAndSearchInSearchForYourOrgPage()
        {
            formCompletionHelper.EnterText(SearchTextBox, "Brunel");
            Continue();
            return new AP_PR2_SearchResultsForPage(_context);
        }
    }
}
