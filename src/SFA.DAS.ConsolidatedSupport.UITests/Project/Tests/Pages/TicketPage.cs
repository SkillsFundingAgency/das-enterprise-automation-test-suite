using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class TicketPage : DashboardPage
    {
        protected override string PageTitle => dataHelper.Subject;

        private By TicketStatus => By.CssSelector("[data-test-id='tabs-section-nav-item-ticket'] .ticket_status_label");

        protected override By PageHeader => By.CssSelector("[data-test-id='header-tab-title']");

        private By MenuButton => By.CssSelector("[data-test-id='submit_button-menu-button']");

        private By MenuList => By.CssSelector("[data-garden-id='buttons.button_group_view'] ul div div");

        public TicketPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }

        public string GetTicketStatus() => pageInteractionHelper.GetText(TicketStatus);

        public void SelectAsOpen()
        {
            pageInteractionHelper.InvokeAction(() =>
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(MenuButton));
                var elementText = pageInteractionHelper.FindElements(MenuList).ToList();
                int i = 0;
                foreach (var item in elementText)
                {
                    i++;
                    objectContext.Set($"{i}-{item.GetAttribute("class")}", $"{item.TagName}-{item.Text}-{item.GetAttribute("outerHTML")}");
                }
            });
        }
    }
}
