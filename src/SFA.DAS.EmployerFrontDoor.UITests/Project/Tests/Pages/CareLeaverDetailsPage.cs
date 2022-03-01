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

        private By CareLeaverLink => By.Id("scheme-header-link-care-leaver-covenant");

        public CareLeaverDetailsPage(ScenarioContext context) : base(context) => _context = context;


        public CareLeaverDetailsPage CareLeaverScheme()
        {
            {
                formCompletionHelper.ClickElement(CareLeaverLink);
            }
            return new CareLeaverDetailsPage(_context);
        }
    }
}
