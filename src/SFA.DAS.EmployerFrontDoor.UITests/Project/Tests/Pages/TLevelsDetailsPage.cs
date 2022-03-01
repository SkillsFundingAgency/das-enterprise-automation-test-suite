using OpenQA.Selenium;
using System;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public class TLevelsDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        private By TLevelsLink => By.Id("scheme-header-t-levels-industry-placements");

        public TLevelsDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public TLevelsDetailsPage TLevelsScheme()
        {
            {
                formCompletionHelper.ClickElement(TLevelsLink);
            }
            return new TLevelsDetailsPage(_context);
        }
    }
}