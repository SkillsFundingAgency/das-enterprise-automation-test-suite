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

        // protected override string PageTitle => "Skills Bootcamps";
        //protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        private By SkillsBootcampsLink => By.Id("scheme-header-link-skills-bootcamps");

        public SkillsBootcampsDetailsPage(ScenarioContext context) : base(context) => _context = context;


        public SkillsBootcampsDetailsPage SkillsBootcampsScheme()
        {
            // if (ApprenticeshipsDetailsPage.WaitUntilAnyElements(ApprenticeshipsLink))
            {
                formCompletionHelper.ClickElement(SkillsBootcampsLink);
            }
            return new SkillsBootcampsDetailsPage(_context);
        }
    }
}
