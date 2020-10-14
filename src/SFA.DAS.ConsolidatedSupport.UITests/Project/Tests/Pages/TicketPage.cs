using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class TicketPage : HomePage
    {
        protected override string PageTitle => dataHelper.Subject;

        protected override By PageHeader => By.CssSelector("[data-test-id='header-tab-title']");

        private By TicketStatus(string statusclass) => By.CssSelector($"[data-test-id='tabs-section-nav-item-ticket'] {statusclass}.ticket_status_label");

        private By TicketOrganisationName => By.CssSelector("span[data-test-id='tabs-nav-item-organizations']");

        private By TicketOrganisationUserName => By.CssSelector("span[data-test-id='tabs-nav-item-users']");

        private By MenuButton => By.CssSelector("[data-test-id='submit_button-menu-button']");

        private By MenuList => By.CssSelector("[data-garden-id='buttons.button_group_view'] ul div div");

        private By CommentEditor => By.CssSelector(".comment_input .content .editor.zendesk-editor--rich-text-comment");

        private By CommentsSections => By.CssSelector(".zd-comment");

        private By TicketCloseButton => By.CssSelector("[data-test-id='close-button']");

        public TicketPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
            VerifyPage(TicketOrganisationName, dataHelper.OrganisationName);
            VerifyPage(TicketOrganisationUserName, dataHelper.OrganisationUserName);
        }

        public void VerifyTicketStatus(string expectedstatus) => VerifyPage(TicketStatus(GetTicketStatusClassName(expectedstatus)), expectedstatus.ToUpper());

        private string GetTicketStatusClassName(string expectedstatus)
        {
            return true switch
            {
                bool _ when expectedstatus.CompareToIgnoreCase("New") => ".new",
                bool _ when expectedstatus.CompareToIgnoreCase("Open") => ".open",
                bool _ when expectedstatus.CompareToIgnoreCase("On-Hold") => ".hold",
                bool _ when expectedstatus.CompareToIgnoreCase("Pending") => ".pending",
                bool _ when expectedstatus.CompareToIgnoreCase("Solved") => ".solved",
                _ => string.Empty,
            };
        }

        public void VerifyComments(string comments) => VerifyPage(() => pageInteractionHelper.FindElements(CommentsSections), comments);

        public HomePage SubmitAsOpen(string comments) => SubmitStatus(comments, "status-badge-open", "Submit as Open");

        public HomePage SubmitAsNew(string comments) => SubmitStatus(comments, "status-badge-new", "Submit as New");

        public HomePage SubmitAsPending(string comments) => SubmitStatus(comments, "status-badge-pending", "Submit as Pending");

        public HomePage SubmitAsOnHold(string comments) => SubmitStatus(comments, "status-badge-hold", "Submit as On-hold");

        public HomePage SubmitAsSolved(string comments) => SubmitStatus(comments, "status-badge-solved", "Submit as Solved");

        private void CloseAllTickets()
        {
            var elements = pageInteractionHelper.FindElements(TicketCloseButton).ToList();
            foreach (var element in elements)
            {
                element.Click();
            }
        }

        private HomePage SubmitStatus(string comments, string attribute, string text)
        {
            formCompletionHelper.EnterText(pageInteractionHelper.FindElements(CommentEditor).First((x) => x.Enabled && x.Displayed), comments);

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

            CloseAllTickets();

            return NavigateToHomePage();
        }
    }
}
