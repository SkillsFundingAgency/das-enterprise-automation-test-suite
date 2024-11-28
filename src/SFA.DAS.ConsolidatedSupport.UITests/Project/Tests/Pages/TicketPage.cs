using OpenQA.Selenium;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;
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

        private static By TicketDropdownItem => By.CssSelector("li");

        private static By TicketPublicReply => By.CssSelector("[data-test-id='standalone-ckeditor-public-reply-tab-test-id']");

        private static By TicketInternalNote => By.CssSelector("[data-test-id='standalone-ckeditor-internal-note-tab-test-id']");

        private static string Footer => "[data-garden-id='chrome.footer']";

        private static By MacroMenu => By.CssSelector($"{Footer} [data-garden-id='dropdowns.menu'] li");

        private static By MacroLabel => By.CssSelector($"{Footer} [data-garden-id='forms.input_label'] ");

        private static By MacroInput(string id) => By.CssSelector($"{Footer} input[data-garden-id='dropdowns.input'][id='{id}']");

        public TicketPage(ScenarioContext context) : base(context, false)
        {
            pageInteractionHelper.InvokeAction(() =>
            {
                MultipleVerifyPage([
                    () => VerifyFromMultipleElements(PageHeader, PageTitle),
                    () => VerifyFromMultipleElements(TicketOrganisationName, dataHelper.OrganisationName),
                    () => VerifyFromMultipleElements(TicketOrganisationUserName, dataHelper.OrganisationUserName)]);
            });
        }

        public void VerifyTicketStatus(string expectedstatus) => VerifyElement(TicketStatus(GetTicketStatusClassName(expectedstatus)), expectedstatus.ToUpper());

        public void VerifyDraftComments(string comments) => VerifyElement(() => CommentEditor(), comments, null);

        public void VerifySubmittedComments(string comments) => VerifyElement(() => pageInteractionHelper.FindElements(CommentsSections), comments);

        public void SelectMacroOptions(string answer)
        {
            var label = pageInteractionHelper.FindElement(MacroLabel);

            var forvalue = label.GetDomAttribute("for");

            formCompletionHelper.SendKeys(MacroInput(forvalue), answer);

            pageInteractionHelper.InvokeAction(() =>
            {
                pageInteractionHelper.FindElements(MacroMenu).First(x => x.Text.ContainsCompareCaseInsensitive(answer)).Click();
            });
        }

        public void SelectOptions(string question, string answer)
        {
            var elements = pageInteractionHelper.FindElements(TicketDropdownFields).Where(x => x.Text.ContainsCompareCaseInsensitive(question)).ToList();

            pageInteractionHelper.InvokeAction(() =>
            {
                foreach (var element in elements)
                {
                    var labelElements = element.FindElements(TicketDropdownLabel).ToList();

                    if (labelElements.Count == 1 && (labelElements.Single().Text == question || labelElements.Single().GetDomAttribute("innerText").ContainsCompareCaseInsensitive(question)))
                    {
                        var forvalue = labelElements.Single().GetDomAttribute("for");

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
                SearchTicket();

                incidentNumber = pageInteractionHelper.InvokeAction(() =>
                {
                    var label = pageInteractionHelper.FindElements(TicketDropdownLabel).First(x => x.Text.ContainsCompareCaseInsensitive("Service Now Incident Number"));

                    var forvalue = label.GetDomAttribute("for");

                    var inputElement = pageInteractionHelper.FindElement(TicketDropdownInput(forvalue));

                    return inputElement.GetValueAttribute();
                }, RefreshPage);

                if (!string.IsNullOrEmpty(incidentNumber)) { break; }

                Thread.Sleep(5000);
            }

            return incidentNumber;
        }

        public (HomePage, string) SubmitAsNew() => SubmitStatus(ConsolidateSupportDataHelper.InternalNote, ConsolidateSupportDataHelper.SubmitAsNewComments, "status-badge-new", "Submit as New");

        public (HomePage, string) SubmitAsOpen() => SubmitStatus(ConsolidateSupportDataHelper.InternalNote, ConsolidateSupportDataHelper.SubmitAsOpenComments, "status-badge-open", "Submit as Open");

        public (HomePage, string) SubmitAsPending() => SubmitStatus(ConsolidateSupportDataHelper.PublicReply, ConsolidateSupportDataHelper.SubmitAsPendingComments, "status-badge-pending", "Submit as Pending");

        public (HomePage, string) SubmitAsOnHold()
        {
            SelectOptions("Contact Reason", "Data Lock");
            SelectOptions("Issue Type", "Query");

            SelectMacroOptions("Escalate to Tier 3");

            VerifyDraftComments("Resolver group to assign to");

            SelectOptions("Service Offering", "AS Payments");
            SelectOptions("Resolver Group", "ESFA Apprenticeship Dev Ops");

            return SubmitAsOnHold(ConsolidateSupportDataHelper.SubmitAsOnHoldComments);
        }

        private (HomePage, string) SubmitAsOnHold(string comments) => SubmitStatus(ConsolidateSupportDataHelper.InternalNote, comments, "status-badge-hold", "Submit as On-hold");

        public (HomePage, string) SubmitAsSolved() => SubmitStatus(ConsolidateSupportDataHelper.InternalNote, ConsolidateSupportDataHelper.SubmitAsSolvedComments, "status-badge-solved", "Submit as Solved");

        private (HomePage, string) SubmitStatus(string commentsarea, string comments, string attribute, string text)
        {
            SubmitComments(commentsarea, comments);

            formCompletionHelper.ClickElement(() =>
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(MenuButton));

                var elements = pageInteractionHelper.FindElements(MenuList).Where(x => x?.Text == text).ToList();
                foreach (var element in elements)
                {
                    var outterHtml = element.GetDomAttribute("outerHTML");
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
