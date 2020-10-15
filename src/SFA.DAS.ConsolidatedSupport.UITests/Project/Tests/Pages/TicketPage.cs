using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class TicketPage : HomePage
    {
        protected override string PageTitle => dataHelper.Subject;

        protected override By PageHeader => By.CssSelector("[data-test-id='header-tab-title']");

        private By FindParent => By.XPath("..");

        private By TicketStatus(string statusclass) => By.CssSelector($"[data-test-id='tabs-section-nav-item-ticket'] {statusclass}.ticket_status_label");

        private By TicketOrganisationName => By.CssSelector("span[data-test-id='tabs-nav-item-organizations']");

        private By TicketOrganisationUserName => By.CssSelector("span[data-test-id='tabs-nav-item-users']");

        private By MenuButton => By.CssSelector("[data-test-id='submit_button-menu-button']");

        private By MenuList => By.CssSelector("[data-garden-id='buttons.button_group_view'] ul div div");

        private By CommentEditorSelector => By.CssSelector(".comment_input .content .editor.zendesk-editor--rich-text-comment");

        private By CommentsSections => By.CssSelector(".zd-comment");

        private By TicketCloseButton => By.CssSelector("[data-test-id='close-button']");

        private By TicketDropdownFields => By.CssSelector("[data-garden-id='dropdowns.field']");

        private By TicketDropdownLabel => By.CssSelector("[data-garden-id='dropdowns.label']");

        private By TicketFormsLabel => By.CssSelector("[data-garden-id='forms.text_label']");

        private By TicketDropdownSelect => By.CssSelector("[data-garden-id='dropdowns.select']");

        private By TicketDropdownInput(string id) => By.CssSelector($"input[id='{id}']");

        private By TicketFormsInput => By.CssSelector("[data-garden-id='forms.input']");

        private By TicketDropdownItem => By.CssSelector("li");

        private By TicketPublicReply => By.CssSelector(".track-id-publicComment");

        private By TicketInternalNote => By.CssSelector(".track-id-privateComment");

        public TicketPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
            VerifyPage(TicketOrganisationName, dataHelper.OrganisationName);
            VerifyPage(TicketOrganisationUserName, dataHelper.OrganisationUserName);
        }

        public void VerifyTicketStatus(string expectedstatus) => VerifyPage(TicketStatus(GetTicketStatusClassName(expectedstatus)), expectedstatus.ToUpper());

        public void VerifyDraftComments(string comments) => VerifyElement(() => CommentEditor(), comments, null);

        public void VerifySubmittedComments(string comments) => VerifyPage(() => pageInteractionHelper.FindElements(CommentsSections), comments);

        public void SelectOptions(string question, string answer)
        {
            var elements = pageInteractionHelper.FindElements(TicketDropdownFields).Where(x => x.Text.ContainsCompareCaseInsensitive(question)).ToList();

            foreach (var element in elements)
            {
                var labelElements = element.FindElements(TicketDropdownLabel).ToList();

                if (labelElements.Count == 1 && (labelElements.Single().Text == question || labelElements.Single().GetAttribute("innerText").ContainsCompareCaseInsensitive(question)))
                {
                    var forvalue = labelElements.Single().GetAttribute("for");

                    element.FindElement(TicketDropdownSelect).Click();

                    formCompletionHelper.SendKeys(TicketDropdownInput(forvalue), answer);

                    var parentElement = element.FindElement(FindParent);

                    var selection = parentElement.FindElements(TicketDropdownItem).First(x => x.Text.ContainsCompareCaseInsensitive(answer));

                    selection.Click();
                }
            }
        }

        public string GetServiceNowTicket()
        {
            string incidentNumber = string.Empty;

            for (int i = 0; i < 20; i++)
            {
                var element = pageInteractionHelper.FindElements(TicketFormsLabel).First(x => x.Text.ContainsCompareCaseInsensitive("Service Now Incident Number"));

                element.Click();

                var parentElement = element.FindElement(FindParent);

                var inputElement = parentElement.FindElement(TicketFormsInput);

                incidentNumber = inputElement.GetAttribute("value");

                if (!string.IsNullOrEmpty(incidentNumber)) { break; }

                Thread.Sleep(5000);

                CloseAllTickets();

                NavigateToHomePage();

                SearchTicket();
            }
            
            return incidentNumber;
        }


        public HomePage SubmitAsOpen() => SubmitStatus("Internal note", dataHelper.SubmitAsOpenComments, "status-badge-open", "Submit as Open");

        public HomePage SubmitAsNew() => SubmitStatus("Internal note", dataHelper.SubmitAsNewComments, "status-badge-new", "Submit as New");

        public HomePage SubmitAsPending() => SubmitStatus("Public reply", dataHelper.SubmitAsPendingComments, "status-badge-pending", "Submit as Pending");

        public HomePage SubmitAsOnHold() => SubmitStatus("Internal note", dataHelper.SubmitAsOnHoldComments, "status-badge-hold", "Submit as On-hold");

        public HomePage SubmitAsSolved() => SubmitStatus("Internal note", dataHelper.SubmitAsSolvedComments, "status-badge-solved", "Submit as Solved");

        private HomePage SubmitStatus(string commentsarea, string comments, string attribute, string text)
        {
            SubmitComments(commentsarea, comments);

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

            return NavigateToHomePage();
        }

        private void SubmitComments(string commentsarea, string comments)
        {
            formCompletionHelper.ClickElement(() => CommentsSection(commentsarea));

            formCompletionHelper.EnterText(CommentEditor(), comments);
        }

        private IWebElement CommentsSection(string commentsarea) => pageInteractionHelper.FindElements(commentsarea == "Public reply" ? TicketPublicReply : TicketInternalNote).First(x => x.Enabled && x.Displayed);

        private IWebElement CommentEditor() => pageInteractionHelper.FindElements(CommentEditorSelector).First(x => x.Enabled && x.Displayed);

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

        private void CloseAllTickets()
        {
            pageInteractionHelper.InvokeAction(() =>
            {
                var elements = pageInteractionHelper.FindElements(TicketCloseButton).ToList();
                foreach (var element in elements)
                {
                    element.Click();
                }
            });
        }

    }
}
