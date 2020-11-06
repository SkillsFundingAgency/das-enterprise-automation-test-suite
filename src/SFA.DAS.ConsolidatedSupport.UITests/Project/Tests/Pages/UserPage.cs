using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class UserPage : ConsolidatedSupportBasePage
    {
        protected override By PageHeader => By.CssSelector("[data-test-id='tabs-nav-item-users']");

        protected override string PageTitle => dataHelper.NewUserFullName;

        private readonly ScenarioContext _context;

        private By AllRecordsFields => By.CssSelector(".property_box > .ember-view .property");

        private By CustomerRecordFields => By.CssSelector(".customer_record > .ember-view.property");
        
        private By UserLabel => By.CssSelector(".custom-field-label");

        private By SelectElement => By.CssSelector("div.select");

        private By SearchInputElement => By.CssSelector(".zd-searchmenu-base");

        private By TextAreaInputElement => By.CssSelector("input.textarea");

        private By OrganisationTab => By.CssSelector("[data-test-id='tabs-nav-item-organizations']");

        private By OrganisationInputSections => By.CssSelector(".modal-body .clearfix");

        private By OrganisationInputFields => By.CssSelector(".ember-text-field.classic_input");

        private By OrganisationButtons => By.CssSelector(".modal-form-actions .btn");

        private By OptionsButton => By.CssSelector(".ember-view .object_options > .object_options_btn");

        private By ModelButtons => By.CssSelector(".modal-footer .btn");

        public UserPage(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage(() =>
            {
                NavigateToUser();

                return pageInteractionHelper.FindElements(PageHeader);

            }, PageTitle);
        }

        public HomePage DeleteEntity(bool IsOrganisation = false)
        {
            return InvokeAction(() => 
            {
                var element = pageInteractionHelper.FindElements(OptionsButton).First(x => x.Displayed && x.Enabled);

                formCompletionHelper.ClickElement(element);

                formCompletionHelper.ClickLinkByText("Delete");

                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElements(ModelButtons).Single(x => x.Text == "OK"));
            }, IsOrganisation);
        }

        public void CreateOrganisation()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(OrganisationTab), false);

            CreateOrganisation("Name", dataHelper.NewOrgName);
            CreateOrganisation("Domains", dataHelper.NewOrgDomain);

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElements(OrganisationButtons).Single(x => x.Text == "Save"));
        }

        public HomePage VerifyOrganisationName() => InvokeAction(() => VerifyPage(OrganisationTab, dataHelper.NewOrgName, NavigateToOrganisation), true);
    
        public HomePage VerifyOrganisationDomain() => InvokeAction(() => VerifyPage(() => pageInteractionHelper.FindElements(AllRecordsFields), dataHelper.NewOrgDomain.ToLower()), true);

        public HomePage VerifyUserDetails(string question, string answer, bool IsOrganisation = false)
        {
            return InvokeAction(() =>
            {
                var elements = FindElements(question);

                foreach (var element in elements)
                {
                    if (FindlabelElements(element, question))
                    {
                        StringAssert.Contains(answer, element.Text, $"Question {question} is not updated");
                    }
                }
            }, IsOrganisation);
        }

        public HomePage SelectOptions(string question, string answer, bool IsOrganisation = false)
        {
            return InvokeAction(() =>
            {
                var elements = FindElements(question);

                foreach (var element in elements)
                {
                    if (FindlabelElements(element, question))
                    {
                        formCompletionHelper.ClickElement(element.FindElement(SelectElement));

                        element.FindElement(SearchInputElement).SendKeys(answer);

                        element.FindElement(SearchInputElement).SendKeys(Keys.Tab);
                    }
                }
            }, IsOrganisation);
        }

        public HomePage EnterText(string question, string answer, bool IsOrganisation = false)
        {
            return InvokeAction(() => 
            {
                var elements = FindElements(question);

                foreach (var element in elements)
                {
                    if (FindlabelElements(element, question))
                    {
                        formCompletionHelper.ClickElement(element.FindElement(TextAreaInputElement));

                        formCompletionHelper.EnterText(element.FindElement(TextAreaInputElement), answer);

                        element.FindElement(TextAreaInputElement).SendKeys(Keys.Tab);
                    }
                }
            }, IsOrganisation);
        }

        public new HomePage CloseAllTickets()
        {
            base.CloseAllTickets();
            return new HomePage(_context, true);
        }

        private void NavigateToUser() => tabHelper.GoToUrl(UrlConfig.ConsolidatedSupport_BaseUrl, $"agent/#/users/{objectContext.GetUserId()}/tickets");

        private void NavigateToOrganisation() => tabHelper.GoToUrl(UrlConfig.ConsolidatedSupport_BaseUrl, $"agent/#/users/{objectContext.GetUserId()}/organization/tickets");

        private List<IWebElement> FindElements(string question)
        {
            VerifyPage(() => pageInteractionHelper.FindElements(CustomerRecordFields), question);

            return pageInteractionHelper.FindElements(CustomerRecordFields).Where(x => x.Text.ContainsCompareCaseInsensitive(question)).ToList();
        }

        private bool FindlabelElements(IWebElement element, string question)
        {
            var labelElements = element.FindElements(UserLabel).ToList();

            return labelElements.Count == 1 && (labelElements.Single().Text == question || labelElements.Single().GetAttribute("innerText").ContainsCompareCaseInsensitive(question));
        }

        private HomePage InvokeAction(Action action, bool IsOrganisation = false)
        {
            if (IsOrganisation) { NavigateToOrganisation(); }
            else { NavigateToUser(); }
            action.Invoke();
            return CloseAllTickets();
        }

        private void CreateOrganisation(string property, string value)
        {
            var elements = pageInteractionHelper.FindElements(OrganisationInputSections);

            foreach (var element in elements)
            {
                if (element.Text.Contains(property))
                {
                    element.FindElement(OrganisationInputFields).SendKeys(value);
                }
            }
        }
    }
}
