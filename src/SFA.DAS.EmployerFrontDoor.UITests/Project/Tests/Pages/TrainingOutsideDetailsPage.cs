using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
   public class TrainingOutsideDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        // protected override string PageTitle => "Sector-based Work Academy Programme(SWAP)";
        //protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        private By TrainingOutsideLink => By.Id("scheme-header-link-training-outside-of-employment");

        public TrainingOutsideDetailsPage(ScenarioContext context) : base(context) => _context = context;


        public TrainingOutsideDetailsPage TrainingOutsideScheme()
        {
            // if (ApprenticeshipsDetailsPage.WaitUntilAnyElements(ApprenticeshipsLink))
            {
                formCompletionHelper.ClickElement(TrainingOutsideLink);
            }
            return new TrainingOutsideDetailsPage(_context);
        }
    }
}
