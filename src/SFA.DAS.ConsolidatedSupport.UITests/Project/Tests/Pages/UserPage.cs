using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
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

        private By UserFields => By.CssSelector(".customer_record > .ember-view.property");
        
        private By UserLabel => By.CssSelector(".custom-field-label");

        private By SelectElement => By.CssSelector("div.select");

        private By SearchInputElement => By.CssSelector(".zd-searchmenu-base");

        private By TextAreaInputElement => By.CssSelector("input.textarea");

        public UserPage(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage(() =>
            {
                tabHelper.GoToUrl(UrlConfig.ConsolidatedSupport_BaseUrl, $"agent/#/users/{objectContext.GetUserId()}/tickets");

                return pageInteractionHelper.FindElements(PageHeader);

            }, PageTitle);
        }

        public void VerifyUserDetails(string question, string answer)
        {
            var elements = FindElements(question);

            foreach (var element in elements)
            {
                if (FindlabelElements(element, question))
                {
                    StringAssert.Contains(answer, element.Text, $"Question {question} is not updated");
                }
            }
        }

        public void SelectOptions(string question, string answer)
        {
            var elements = FindElements(question);

            foreach (var element in elements)
            {
                if (FindlabelElements(element, question))
                {
                    var select = element.FindElement(SelectElement);
                    
                    select.Click();

                    element.FindElement(SearchInputElement).SendKeys(answer);

                    element.FindElement(SearchInputElement).SendKeys(Keys.Tab);
                }
            }
        }

        public void EnterText(string question, string answer)
        {
            var elements = FindElements(question);

            foreach (var element in elements)
            {
                if (FindlabelElements(element, question))
                { 
                    element.FindElement(TextAreaInputElement).Click();

                    element.FindElement(TextAreaInputElement).SendKeys(answer);
                }
            }
        }

        public new HomePage CloseAllTickets()
        {
            base.CloseAllTickets();
            return new HomePage(_context, true);
        }

        private List<IWebElement> FindElements(string question)
        {
            VerifyPage(() => pageInteractionHelper.FindElements(UserFields), question);

            return pageInteractionHelper.FindElements(UserFields).Where(x => x.Text.ContainsCompareCaseInsensitive(question)).ToList();
        }

        private bool FindlabelElements(IWebElement element, string question)
        {
            var labelElements = element.FindElements(UserLabel).ToList();

            return labelElements.Count == 1 && (labelElements.Single().Text == question || labelElements.Single().GetAttribute("innerText").ContainsCompareCaseInsensitive(question));
        }
    }
}
