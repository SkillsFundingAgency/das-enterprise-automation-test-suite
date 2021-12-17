using OpenQA.Selenium;
using System;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public class TLevelsDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

       // protected override string PageTitle => "TLevels: industry placements";
        //protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        private By TLevelssLink => By.Id("scheme-header-t-levels-industry-placements");

        public TLevelsDetailsPage(ScenarioContext context) : base(context) => _context = context;


        public TLevelsDetailsPage TLevelsScheme()
        {
            // if (ApprenticeshipsDetailsPage.WaitUntilAnyElements(ApprenticeshipsLink))
            {
                formCompletionHelper.ClickElement(TLevelssLink);
            }
            return new TLevelsDetailsPage(_context);
        }

    }
}

