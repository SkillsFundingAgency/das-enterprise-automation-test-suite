using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
   public class FreeCoursesDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        private By FreeCoursesLink => By.Id("scheme-header-link-free-courses-and-additional-training-for-your-employees");

        public FreeCoursesDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public FreeCoursesDetailsPage FreeCoursesScheme()
        {
            {
                formCompletionHelper.ClickElement(FreeCoursesLink);
            }
            return new FreeCoursesDetailsPage(_context);
        }
    }
}