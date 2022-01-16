using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
   public class EmpPrisonersDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        // protected override string PageTitle => "TLevels: industry placements";
        //protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        private By EmpPrisonersLink => By.Id("scheme-header-link-employing-prisoners-and-prison-leavers");

        public EmpPrisonersDetailsPage(ScenarioContext context) : base(context) => _context = context;


        public EmpPrisonersDetailsPage EmpPrisonersScheme()
        {
            // if (ApprenticeshipsDetailsPage.WaitUntilAnyElements(ApprenticeshipsLink))
            {
                formCompletionHelper.ClickElement(EmpPrisonersLink);
            }
            return new EmpPrisonersDetailsPage(_context);
        }
    }
}
