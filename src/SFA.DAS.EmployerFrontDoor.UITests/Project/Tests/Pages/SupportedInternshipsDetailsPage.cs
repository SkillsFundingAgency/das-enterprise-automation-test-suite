using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public class SupportedInternshipsDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        // protected override string PageTitle => "Sector-based Work Academy Programme(SWAP)";
        //protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        private By SupportedInternshipsLink => By.Id("scheme-header-link-supported-internships");

        public SupportedInternshipsDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public SupportedInternshipsDetailsPage SupportedInternshipsScheme()
        {
            // if (ApprenticeshipsDetailsPage.WaitUntilAnyElements(ApprenticeshipsLink))
            {
                formCompletionHelper.ClickElement(SupportedInternshipsLink);
            }
            return new SupportedInternshipsDetailsPage(_context);
        }

    }
}
