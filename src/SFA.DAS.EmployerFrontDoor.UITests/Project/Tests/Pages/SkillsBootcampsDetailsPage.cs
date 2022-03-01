using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public class SkillsBootcampsDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        private By SkillsBootcampsLink => By.Id("scheme-header-link-skills-bootcamps");

        public SkillsBootcampsDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public SkillsBootcampsDetailsPage SkillsBootcampsScheme()
        {
            {
                formCompletionHelper.ClickElement(SkillsBootcampsLink);
            }
            return new SkillsBootcampsDetailsPage(_context);
        }
    }
}