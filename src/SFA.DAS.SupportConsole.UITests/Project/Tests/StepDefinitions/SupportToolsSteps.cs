using NUnit.Framework;
using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
       
        [Given(@"Opens the Pause Utility")]
        [When(@"user opens Pause Utility")]
        public void WhenUserOpensPauseUtility()
        {
            new ToolSupportHomePage(_context).ClickPauseApprenticeshipsLink();
        }


        [Given(@"Search for Apprentices using following criteria")]
        [Then(@"following filters should return the expected number of TotalRecords")]
        public void ThenFollowingFiltersShouldReturnTheExpectedNumberOfTotalRecords(Table table)
        {
            var filters = table.CreateSet<filters>();
            int row = 1;

            foreach (var item in filters)
            {
                new SearchForApprenticeshipPage(_context)
                       .EnterEmployerName(item.EmployerName)
                       .EnterProviderName(item.ProviderName)
                       .EnterUkprn(item.Ukprn)
                       .EnterEndDate(item.EndDate)
                       .EnterULNorApprenticeName(item.Uln)
                       .SelectStatus(item.Status)
                       .ClickSubmitButton();

                var actualRecord = new SearchForApprenticeshipPage(_context).GetNumberOfRecordsFound();
                Assert.GreaterOrEqual(actualRecord, item.TotalRecords, $"Validate number of expected recordson row: {row}");
                row++;
            }       
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

    public class filters
    {
        public string EmployerName { get; set; }
        public string ProviderName { get; set; }
        public string Ukprn { get; set; }
        public string EndDate { get; set; }
        public string Uln { get; set; }
        public string Status { get; set; }
        public int? TotalRecords { get; set; }

        	
    }

}
