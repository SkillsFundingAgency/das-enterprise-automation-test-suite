using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class TicketPage : DashboardPage
    {
        protected override string PageTitle => dataHelper.Subject;

        protected override By PageHeader => By.CssSelector("[data-test-id='header-tab-title']");

        private By TicketWorkspace => By.CssSelector(".workspace");

        private By TicketStatus => By.CssSelector("[data-test-id='tabs-section-nav-item-ticket'] .ticket_status_label");

        private By TicketOrganisationName => By.CssSelector("span[data-test-id='tabs-nav-item-organizations']");

        private By TicketOrganisationUserName => By.CssSelector("span[data-test-id='tabs-nav-item-users']");

        private By MenuButton => By.CssSelector("[data-test-id='submit_button-menu-button']");

        private By MenuList => By.CssSelector("[data-garden-id='buttons.button_group_view'] ul div div");

        public TicketPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
            VerifyPage(TicketOrganisationName, dataHelper.OrganisationName);
            VerifyPage(TicketOrganisationUserName, dataHelper.OrganisationUserName);
        }

        public void VerifyTicketStatus(string expectedstatus)
        {
            VerifyElement(() =>
            {
                var elements = pageInteractionHelper.FindElements(TicketWorkspace).ToList();
                foreach (var element in elements)
                {
                    var outterHtml = element.GetAttribute("outerHTML");
                    var classlist = element.GetAttribute("class");
                    if (!classlist.ContainsCompareCaseInsensitive("apps") && !outterHtml.ContainsCompareCaseInsensitive("display:none;"))
                    {
                        return element.FindElement(TicketStatus);
                    }
                }

                throw new NotFoundException(TicketWorkspace.ToString());


            }, expectedstatus, null);
        }

        public void SubmitAsOpen() => SubmitStatus("status-badge-open", "Submit as Open");

        public void SubmitAsNew() => SubmitStatus("status-badge-new", "Submit as New");

        public void SubmitAsPending() => SubmitStatus("status-badge-pending", "Submit as Pending");

        public void SubmitAsOnHold() => SubmitStatus("status-badge-hold", "Submit as On-hold");

        public void SubmitAsSolved() => SubmitStatus("status-badge-solved", "Submit as Solved");

        private void SubmitStatus(string attribute, string text)
        {
            formCompletionHelper.ClickElement(() =>
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(MenuButton));

                var elements = pageInteractionHelper.FindElements(MenuList).Where(x => x?.Text == text).ToList();
                foreach (var element in elements)
                {
                    var outterHtml = element.GetAttribute("outerHTML");
                    if (!string.IsNullOrEmpty(outterHtml) && outterHtml.Contains(attribute) && !outterHtml.ContainsCompareCaseInsensitive("tooltip"))
                    {
                        return element;
                    }
                }
                return null;
            });
        }
    }
}
