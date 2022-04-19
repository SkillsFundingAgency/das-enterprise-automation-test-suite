using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public abstract class UserOrgBasePage : ConsolidatedSupportBasePage
    {
        protected enum PageTypeEnum
        {
            User,
            Org
        }

        private By OptionsButton => By.CssSelector(".ember-view .object_options > .object_options_btn");

        private By ModelButtons => By.CssSelector(".modal-footer .btn");

        private By CustomerRecordFields => By.CssSelector(".customer_record > .ember-view.property");

        private By UserLabel => By.CssSelector(".custom-field-label");

        private By SelectElement => By.CssSelector("div.select");

        private By SearchInputElement => By.CssSelector(".zd-searchmenu-base");

        private By TextAreaInputElement => By.CssSelector("input.textarea");

        protected abstract PageTypeEnum PageType { get; }

        public UserOrgBasePage(ScenarioContext context, bool navigate) : base(context)
        {
            if (navigate) NavigateTo();

            VerifyPage(() => pageInteractionHelper.FindElements(PageHeader), PageTitle);
        }

        public void SelectOptions(string question, string answer)
        {
            foreach (var element in FindElements(question))
            {
                if (FindlabelElements(element, question))
                {
                    formCompletionHelper.ClickElement(element.FindElement(SelectElement));

                    element.FindElement(SearchInputElement).SendKeys(answer);

                    element.FindElement(SearchInputElement).SendKeys(Keys.Tab);
                }
            }
        }

        public void EnterText(string question, string answer)
        {
            foreach (var element in FindElements(question))
            {
                if (FindlabelElements(element, question))
                {
                    formCompletionHelper.ClickElement(element.FindElement(TextAreaInputElement));

                    formCompletionHelper.EnterText(element.FindElement(TextAreaInputElement), answer);

                    element.FindElement(TextAreaInputElement).SendKeys(Keys.Tab);
                }
            }
        }

        public HomePage DeleteUser() => DeleteEntity();

        public HomePage DeleteOrg() => DeleteEntity();

        protected HomePage VerifyUserDetails(string question, string answer)
        {
            return InvokeAction(() =>
            {
                foreach (var element in FindElements(question))
                    if (FindlabelElements(element, question))
                        StringAssert.Contains(answer, element.Text, $"Question {question} is not updated");
            });
        }

        protected HomePage InvokeAction(Action action)
        {
            NavigateTo();

            action.Invoke();

            return CloseAllTickets();
        }

        protected void NavigateToUser() => NavigateTo($"agent/users/{objectContext.GetUserId()}/tickets");

        protected void NavigateToOrganisation() => NavigateTo($"agent/users/{objectContext.GetUserId()}/organization/tickets");

        protected List<IWebElement> FindElements(string question)
        {
            VerifyElement(() => pageInteractionHelper.FindElements(CustomerRecordFields), question);

            return pageInteractionHelper.FindElements(CustomerRecordFields).Where(x => x.Text.ContainsCompareCaseInsensitive(question)).ToList();
        }

        protected bool FindlabelElements(IWebElement element, string question)
        {
            var labelElements = element.FindElements(UserLabel).ToList();

            return labelElements.Count == 1 && (labelElements.Single().Text == question || labelElements.Single().GetAttribute("innerText").ContainsCompareCaseInsensitive(question));
        }

        private void NavigateTo() { if (PageType == PageTypeEnum.User) NavigateToUser(); else NavigateToOrganisation(); }

        private new HomePage CloseAllTickets()
        {
            base.CloseAllTickets();
            return new HomePage(context, true);
        }

        private HomePage DeleteEntity()
        {
            var element = pageInteractionHelper.FindElements(OptionsButton).First(x => x.Displayed && x.Enabled);

            formCompletionHelper.ClickElement(element);

            formCompletionHelper.ClickLinkByText("Delete");

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElements(ModelButtons).Single(x => x.Text == "OK"));

            return CloseAllTickets();
        }
    }
}
