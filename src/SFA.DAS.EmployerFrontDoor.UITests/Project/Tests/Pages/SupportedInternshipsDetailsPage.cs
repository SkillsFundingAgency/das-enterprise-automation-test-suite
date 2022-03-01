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

        private By SupportedInternshipsLink => By.Id("scheme-header-link-supported-internships");

        public SupportedInternshipsDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public SupportedInternshipsDetailsPage SupportedInternshipsScheme()
        {
            {
                formCompletionHelper.ClickElement(SupportedInternshipsLink);
            }
            return new SupportedInternshipsDetailsPage(_context);
        }

    }
}