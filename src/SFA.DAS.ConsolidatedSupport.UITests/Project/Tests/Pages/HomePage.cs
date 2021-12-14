using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class HomePage : ConsolidatedSupportBasePage
    {
        protected override By PageHeader => By.CssSelector("#main_navigation");
        protected override string PageTitle { get; }

        private By BrandingHeader => By.CssSelector("#branding_header");

        private By SearchIcon => By.CssSelector("[data-test-id='header-toolbar-search-button'] svg");

        private By SearchInput => By.CssSelector("[data-test-id='header-toolbar-search-button'] input");

        private By Indicators => By.CssSelector(".indicators");

        private By TicketTable => By.CssSelector("[data-test-id='table_container'] table");

        private By HomeButton => By.CssSelector("#main_navigation [data-original-title='Home']");

        private By AdminButton => By.CssSelector("#main_navigation [data-original-title='Admin']");

        public HomePage(ScenarioContext context, bool navigateTo) : base(context)
        {
            void action() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(HomeButton));

            if (navigateTo) 
            {
                action();
                MultipleVerifyPage(new List<Func<bool>>
                {
                    () => VerifyPage(PageHeader, action),
                    () => VerifyPage(BrandingHeader, action),
                    () => VerifyPage(Indicators, action),
                    () => VerifyPage(TicketTable, action)
                });
            }
        }

        public TicketPage SearchTicket()
        {
            pageInteractionHelper.InvokeAction(() =>
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SearchIcon));
                formCompletionHelper.EnterText(SearchInput, objectContext.GetTicketId());
                formCompletionHelper.SendKeys(SearchInput, Keys.Enter);
            });

            return new TicketPage(context);
        }

        public AdminPage NavigateToAdminPage()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AdminButton));
            return new AdminPage(context);
        }

        protected HomePage NavigateToHomePage() => new HomePage(context, true);
    }
}
