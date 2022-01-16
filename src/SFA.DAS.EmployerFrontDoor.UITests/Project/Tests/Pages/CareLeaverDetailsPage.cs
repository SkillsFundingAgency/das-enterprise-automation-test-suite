using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public class CareLeaverDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        // protected override string PageTitle => "Sector-based Work Academy Programme(SWAP)";
        //protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        private By CareLeaverLink => By.Id("scheme-header-link-care-leaver-covenant");

        public CareLeaverDetailsPage(ScenarioContext context) : base(context) => _context = context;


        public CareLeaverDetailsPage CareLeaverScheme()
        {
            // if (ApprenticeshipsDetailsPage.WaitUntilAnyElements(ApprenticeshipsLink))
            {
                formCompletionHelper.ClickElement(CareLeaverLink);
            }
            return new CareLeaverDetailsPage(_context);
        }
    }
}
