using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
   public class TraineeshipsDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        private By TraineeshipsLink => By.Id("scheme-header-link-traineeships");

        public TraineeshipsDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public TraineeshipsDetailsPage TraineeshipsScheme()
        {
            {
                formCompletionHelper.ClickElement(TraineeshipsLink);
            }
            return new TraineeshipsDetailsPage(_context);
        }
    }
}
