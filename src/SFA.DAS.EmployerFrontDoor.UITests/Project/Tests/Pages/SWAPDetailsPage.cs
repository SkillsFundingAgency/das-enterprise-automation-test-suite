using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
   public class SWAPDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        // protected override string PageTitle => "Sector-based Work Academy Programme(SWAP)";
        //protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        private By SWAPLink => By.Id("scheme-header-link-sector-based-work-academy-programme-swap");

        public SWAPDetailsPage(ScenarioContext context) : base(context) => _context = context;


        public SWAPDetailsPage SWAPScheme()
        {
           // if (ApprenticeshipsDetailsPage.WaitUntilAnyElements(ApprenticeshipsLink))
            {
                formCompletionHelper.ClickElement(SWAPLink);
            }
            return new SWAPDetailsPage(_context);
        }
    }
}
