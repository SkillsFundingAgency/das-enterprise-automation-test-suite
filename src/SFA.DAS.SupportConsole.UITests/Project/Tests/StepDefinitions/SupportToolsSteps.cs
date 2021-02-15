using NUnit.Framework;
using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SupportToolsSteps
    {
        private readonly ScenarioContext _context;
        private readonly StepsHelper _stepsHelper;

        public SupportToolsSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new StepsHelper(_context);
        }

        [Given(@"the User is logged into Support Tools")]
        public void GivenTheUserIsLoggedIntoSupportTools()
        {
            _stepsHelper.ValidUserLogsinToSupportTools();

        }

        [Given(@"Open Pause utility")]
        public void GivenOpenPauseUtility()
        {
            new ToolSupportHomePage(_context).ClickPauseApprenticeshipsLink();
        }

        [When(@"selects Search by (.*) and (.*)")]
        public void WhenSelectsSearchByAnd(string employerName, string providerName)
        {
            new SearchForApprenticeshipPage(_context)
                .EnterEmployerName(employerName)
                .EnterProviderName(providerName)
                .ClickSubmitButton();
        }

        [Then(@"(.*) are retreived")]
        public void ThenAreRetreived(int expectedRecords)
        {
            var actualRecord = new SearchForApprenticeshipPage(_context).GetNumberOfRecordsFound();
            Assert.AreEqual(expectedRecords, actualRecord);
        }

        [When(@"User selects all records and click on Pause Apprenticeship button")]
        public void WhenUserSelectsAllRecordsAndClickOnPauseApprenticeshipButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Pause apprenticeships page is displayed with (.*) records")]
        public void ThenPauseApprenticeshipsPageIsDisplayedWithRecords(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should be able to pause them all")]
        public void ThenUserShouldBeAbleToPauseThemAll()
        {
            ScenarioContext.Current.Pending();
        }




    }
}
