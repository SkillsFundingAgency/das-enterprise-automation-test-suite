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

        private static By SearchIcon => By.CssSelector("[data-test-id='header-toolbar-search-button'] svg");

        private static By SearchInput => By.CssSelector("[data-test-id='header-toolbar-search-button'] input");

        private static By BrandingHeader => By.CssSelector("#branding_header");

        private static By Indicators => By.CssSelector(".indicators");

        private static By TicketTable => By.CssSelector("[data-test-id='table_container'] table");


        public HomePage(ScenarioContext context, bool navigateTo) : base(context)
        {
            void action() => ClickHomeButton();

            if (navigateTo) 
            {
                action();
                MultipleVerifyPage(
                [
                    () => VerifyPage(PageHeader, action),
                    () => VerifyPage(BrandingHeader, action),
                    () => VerifyPage(Indicators, action),
                    () => VerifyPage(TicketTable, action)
                ]);
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

        protected HomePage NavigateToHomePage() => new(context, true);
    }
}
