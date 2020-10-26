using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class AdminPage : ConsolidatedSupportBasePage
    {
        protected override By PageHeader => By.CssSelector(".admin .pane.left.section");

        protected override string PageTitle => "ADMIN HOME";

        private readonly ScenarioContext _context;

        private By PeopleLink => By.CssSelector("a[href='/agent/admin/people']");

        private By Query => By.CssSelector("#query");

        private By Buttonsubmit => By.CssSelector("#buttonsubmit");

        private By UserLink(string userid) => By.CssSelector($"a[href*='/users/{userid}/tickets']");

        public AdminPage(ScenarioContext context) : base(context)
        {
            _context = context;
            
            VerifyPage();
            
            VerifyPage(PeopleLink);

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PeopleLink));
        }
    }
}
