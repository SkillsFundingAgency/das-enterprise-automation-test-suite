using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class OrganisationListPage : ConsolidatedSupportBasePage
    {
        protected override By PageHeader => By.CssSelector("[data-test-id='organization-lists-header']");

        protected override string PageTitle => "Organisations";

        private By SearchOrganisationInput => By.CssSelector("[data-test-id='search-input']");

        private By ResultCount => By.CssSelector("[data-test-id='results-count']");

        private By Tickets => By.CssSelector("[data-garden-id='tables.cell'] > [href*='/tickets']");
        
        private By OrganisationButton => By.CssSelector("#main_navigation [data-original-title='Organisations']");

        public OrganisationListPage(ScenarioContext context) : base(context) { formCompletionHelper.ClickElement(OrganisationButton); VerifyPage(); }

        public int NoOfOrganisation()
        {
            SearchOrganisation();

            if (pageInteractionHelper.GetText(ResultCount) == "0 results") return 0;

            return pageInteractionHelper.FindElements(Tickets).ToList().Count;
        }

        public DeleteOrgPage NavigateToOrgPage()
        {
            formCompletionHelper.ClickElement(() => { Search(); return pageInteractionHelper.FindElement(Tickets); }); 
            
            return new DeleteOrgPage(context);
        }

        private void SearchOrganisation()
        {
            formCompletionHelper.EnterText(SearchOrganisationInput, dataHelper.NewOrgNameWithOutSuffix);

            Search();

            VerifyPage(ResultCount, "result");
        }

        private void Search() { formCompletionHelper.ClickElement(SearchOrganisationInput); formCompletionHelper.SendKeys(SearchOrganisationInput, Keys.Enter); }
    }
}
