using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public class EmployerFrontDoorHomePage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Find training and employment schemes for your business";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private By CookieButton => By.Id("layout-cookie-button-accept");
        private By CloseCookieButton => By.Id("cookie-accept-close-button");

        public EmployerFrontDoorHomePage(ScenarioContext context) : base(context) => _context = context;
        public EmployerFrontDoorHomePage AcceptCookieAndAlert()
        {
            if (pageInteractionHelper.WaitUntilAnyElements(CookieButton))
            {
                formCompletionHelper.ClickElement(CookieButton);
                formCompletionHelper.ClickElement(CloseCookieButton);
            }
            return new EmployerFrontDoorHomePage(_context);
        }
    }
}

