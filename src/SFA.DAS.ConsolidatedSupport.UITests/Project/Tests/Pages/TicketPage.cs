using OpenQA.Selenium;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class TicketPage : HomePage
    {
        protected override string PageTitle => dataHelper.Subject;

        protected override By PageHeader => By.CssSelector("[data-test-id='header-tab-title']");

       private static By FindParent => By.XPath("..");

       private static By TicketStatus(string statusclass) => By.CssSelector($"[data-test-id='tabs-section-nav-item-ticket'] {statusclass}.ticket_status_label");

       private static By TicketOrganisationName => By.CssSelector("span[data-test-id='tabs-nav-item-organizations']");

       private static By TicketOrganisationUserName => By.CssSelector("span[data-test-id='tabs-nav-item-users']");

       private static By MenuButton => By.CssSelector("[data-test-id='submit_button-menu-button']");

       private static By MenuList => By.CssSelector("[data-garden-id='buttons.button_group_view'] ul div div");

       private static By CommentEditorSelector => By.CssSelector("[data-test-id='standalone-rich-text-ckeditor']");

       private static By CommentsSections => By.CssSelector(".zd-comment");

       private static By TicketDropdownFields => By.CssSelector("[data-garden-id='forms.field']");

       private static By TicketDropdownLabel => By.CssSelector("[data-garden-id='forms.input_label']");

       private static By TicketDropdownSelect => By.CssSelector("[data-garden-id='dropdowns.select']");

       private static By TicketDropdownInput(string id) => By.CssSelector($"input[id='{id}']");

       private static By TicketFormsInput => By.CssSelector("[data-garden-id='forms.input']");

       private static By TicketDropdownItem => By.CssSelector("li");

       private static By TicketPublicReply => By.CssSelector("[data-test-id='standalone-ckeditor-public-reply-tab-test-id']");

       private static By TicketInternalNote => By.CssSelector("[data-test-id='standalone-ckeditor-internal-note-tab-test-id']");

        public TicketPage(ScenarioContext context) : base(context, false)
        {
            MultipleVerifyPage(
            [
                () => VerifyPage(() => pageInteractionHelper.FindElements(PageHeader), PageTitle),
                () => VerifyPage(() => pageInteractionHelper.FindElements(TicketOrganisationName), dataHelper.OrganisationName),
                () => VerifyPage(() => pageInteractionHelper.FindElements(TicketOrganisationUserName), dataHelper.OrganisationUserName)
            ]);
        }

        public void VerifyTicketStatus(string expectedstatus) => VerifyElement(TicketStatus(GetTicketStatusClassName(expectedstatus)), expectedstatus.ToUpper());

        public void VerifyDraftComments(string comments) => VerifyElement(() => CommentEditor(), comments, null);

        public void VerifySubmittedComments(string comments) => VerifyElement(() => pageInteractionHelper.FindElements(CommentsSections), comments);

        public void SelectOptions(string question, string answer)
        {
            var elements = pageInteractionHelper.FindElements(TicketDropdownFields).Where(x => x.Text.ContainsCompareCaseInsensitive(question)).ToList();

            pageInteractionHelper.InvokeAction(() => 
            {
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
            });
        }

        public string GetServiceNowTicket()
        {
            string incidentNumber = string.Empty;

            for (int i = 0; i < 20; i++)
            {
                var element = pageInteractionHelper.FindElements(TicketDropdownLabel).First(x => x.Text.ContainsCompareCaseInsensitive("Service Now Incident Number"));

                element.Click();

                var parentElement = element.FindElement(FindParent);

                var inputElement = parentElement.FindElement(TicketFormsInput);

                incidentNumber = inputElement.GetAttribute("value");

                if (!string.IsNullOrEmpty(incidentNumber)) { break; }

                SubmitComments(dataHelper.InternalNote, dataHelper.SubmitAsWaitingForIncNum);

                Thread.Sleep(5000);

                CloseAllTickets();

                NavigateToHomePage();

                SearchTicket();
            }
            
            return incidentNumber;
        }

        public (HomePage, string) SubmitAsNew() => SubmitStatus(dataHelper.InternalNote, dataHelper.SubmitAsNewComments, "status-badge-new", "Submit as New");

        public (HomePage, string) SubmitAsOpen() => SubmitStatus(dataHelper.InternalNote, dataHelper.SubmitAsOpenComments, "status-badge-open", "Submit as Open");

        public (HomePage, string) SubmitAsPending() => SubmitStatus(dataHelper.PublicReply, dataHelper.SubmitAsPendingComments, "status-badge-pending", "Submit as Pending");

        public (HomePage, string) SubmitAsOnHold()
        {
            SelectOptions("Contact Reason", "Data Lock");
            SelectOptions("Issue Type", "Query");
            SelectOptions("Apply macro", "Escalate to Tier 3");

            VerifyDraftComments("Resolver group to assign to");

            SelectOptions("Service Offering", "AS Payments");
            SelectOptions("Resolver Group", "ESFA Apprenticeship Dev Ops");

            return SubmitStatus(dataHelper.InternalNote, dataHelper.SubmitAsOnHoldComments, "status-badge-hold", "Submit as On-hold");
        }

        public (HomePage, string) SubmitAsSolved() => SubmitStatus(dataHelper.InternalNote, dataHelper.SubmitAsSolvedComments, "status-badge-solved", "Submit as Solved");

        private (HomePage, string) SubmitStatus(string commentsarea, string comments, string attribute, string text)
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

            return (NavigateToHomePage(), comments);
        }

        private void SubmitComments(string commentsarea, string comments)
        {
            formCompletionHelper.ClickElement(() => CommentsSection(commentsarea));
            
            formCompletionHelper.ClickElement(() => CommentEditor());

            formCompletionHelper.EnterText(CommentEditor(), comments);
        }

        private IWebElement CommentsSection(string commentsarea) => pageInteractionHelper.FindElements(commentsarea == "Public reply" ? TicketPublicReply : TicketInternalNote).First(x => x.Enabled && x.Displayed);

        private IWebElement CommentEditor() => pageInteractionHelper.FindElements(CommentEditorSelector).First(x => x.Enabled && x.Displayed);

        private static string GetTicketStatusClassName(string status)
        {
            return true switch
            {
                bool _ when status.IsNew() => ".new",
                bool _ when status.IsOpen() => ".open",
                bool _ when status.IsOnHold() => ".hold",
                bool _ when status.IsPending() => ".pending",
                bool _ when status.IsSolved() => ".solved",
                _ => string.Empty,
            };
        }
    }
}
