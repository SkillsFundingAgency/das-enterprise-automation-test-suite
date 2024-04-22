using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class HomePage : ConsolidatedSupportBasePage
    {
        protected override By PageHeader => By.CssSelector("#main_navigation");

        protected override string PageTitle { get; }

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
            NavigateTo();

            return new TicketPage(context);
        }

        protected HomePage NavigateToHomePage() => new(context, true);
    }
}
