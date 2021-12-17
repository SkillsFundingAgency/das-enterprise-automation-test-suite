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

        private By ApprenticeshipsLink => By.Id("scheme-header-link-Apprenticeships");

        public EmployerFrontDoorHomePage(ScenarioContext context) : base(context) => _context = context;
        //public ApprenticeshipsDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public EmployerFrontDoorHomePage AcceptCookieAndAlert()
        {
            if (pageInteractionHelper.WaitUntilAnyElements(CookieButton))
            {
                formCompletionHelper.ClickElement(CookieButton);
                formCompletionHelper.ClickElement(CloseCookieButton);
            }
            return new EmployerFrontDoorHomePage(_context);
        }

      /*  public void ApprenticeshipsScheme()
        {
            if (pageInteractionHelper.WaitUntilAnyElements(ApprenticeshipsLink)) 
            {
                formCompletionHelper.ClickElement(ApprenticeshipsLink);
            }
            
        } */
    }
}

