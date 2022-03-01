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

        private By ApprenticeshipsLink => By.Id("scheme-header-link-apprenticeships");

        public ApprenticeshipsDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeshipsDetailsPage ApprenticeshipsScheme()
        {
          
            {
                formCompletionHelper.ClickElement(ApprenticeshipsLink);
            }
            return new ApprenticeshipsDetailsPage(_context);
        }
    }
}
