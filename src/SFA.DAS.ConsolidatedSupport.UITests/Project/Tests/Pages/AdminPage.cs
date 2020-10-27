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

        public AdminPage(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage();
            
            VerifyPage(PeopleLink);

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PeopleLink));
        }

        public UserPage NavigateToUserPage() => new UserPage(_context);
    }
}
