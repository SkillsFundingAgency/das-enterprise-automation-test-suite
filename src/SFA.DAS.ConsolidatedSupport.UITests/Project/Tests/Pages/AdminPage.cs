using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class AdminPage : ConsolidatedSupportBasePage
    {
        protected override By PageHeader => By.CssSelector(".admin .pane.left.section");

        protected override string PageTitle => "ADMIN HOME";

        private readonly ScenarioContext _context;

        private By PeopleLink => By.CssSelector("a[href='/agent/admin/people']");

        private By SearchOrganisationsLink => By.CssSelector("a[href='/organizations']");

        private By NewOrgLink => By.CssSelector("a[href*='organizations']");

        private By SearchInput => By.CssSelector("input[id='query']");

        private By SearchButton => By.CssSelector("input[id='buttonsubmit']");

        public AdminPage(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage();

            VerifyPage(PeopleLink);
        }

        public UserPage NavigateToUserPage()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PeopleLink));
            return new UserPage(_context);
        }

        public int NoOfOrganisation()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PeopleLink));
            VerifyPage(SearchOrganisationsLink);
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SearchOrganisationsLink));
            formCompletionHelper.EnterText(SearchInput, dataHelper.NewOrgName);
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SearchButton));
            return pageInteractionHelper.GetLinks(NewOrgLink, dataHelper.NewOrgName).Count;
        }

        public OrgPage NavigateToOrgPage()
        {
            formCompletionHelper.ClickLinkByText(NewOrgLink, dataHelper.NewOrgName);
            return new OrgPage(_context);
        }
    }
}
