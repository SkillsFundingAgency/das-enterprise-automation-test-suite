using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
  public class ApprenticeshipsDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;


        //protected override string PageTitle => "Apprenticeships";
        //protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        //private By CookieButton => By.Id("layout-cookie-button-accept");

        //private By CloseCookieButton => By.Id("cookie-accept-close-button");

        private By ApprenticeshipsLink => By.Id("scheme-header-link-apprenticeships");

        public ApprenticeshipsDetailsPage(ScenarioContext context) : base(context) => _context = context;


        public ApprenticeshipsDetailsPage ApprenticeshipsScheme()
        {
           // if (ApprenticeshipsDetailsPage.WaitUntilAnyElements(ApprenticeshipsLink))
            {
                formCompletionHelper.ClickElement(ApprenticeshipsLink);
            }
            return new ApprenticeshipsDetailsPage(_context);
        }
    }
}
