using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages;


namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public abstract class EmployerFrontDoorHeaderBasePage : EmployerFrontDoorVerifyLinks
    {
        readonly ScenarioContext _context;
        public EmployerFrontDoorHeaderBasePage(ScenarioContext context) : base(context) => _context = context;

    }
}
