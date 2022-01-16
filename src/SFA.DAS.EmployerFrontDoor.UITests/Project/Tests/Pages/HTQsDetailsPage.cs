using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public class HTQsDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        // protected override string PageTitle => "Sector-based Work Academy Programme(SWAP)";
        //protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        private By HTQsLink => By.Id("scheme-header-link-higher-technical-qualifications");

        public HTQsDetailsPage(ScenarioContext context) : base(context) => _context = context;


        public HTQsDetailsPage HTQsScheme()
        {
            // if (ApprenticeshipsDetailsPage.WaitUntilAnyElements(ApprenticeshipsLink))
            {
                formCompletionHelper.ClickElement(HTQsLink);
            }
            return new HTQsDetailsPage(_context);
        }
    }
}
