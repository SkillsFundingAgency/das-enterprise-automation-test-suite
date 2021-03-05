using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using SFA.DAS.SupportConsole.UITests.Project.Models;
using SFA.DAS.SupportConsole.UITests.Project.SqlHelpers;
using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SupportToolsSteps
    {
        private readonly ScenarioContext _context;
        private readonly StepsHelper _stepsHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        public SupportToolsSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new StepsHelper(_context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
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

        [Given(@"Opens the Resume Utility")]
        public void GivenOpensTheResumeUtility()
        {
            new ToolSupportHomePage(_context).ClickResumeApprenticeshipsLink();
        }

        [Given(@"Opens the Stop Utility")]
        public void GivenOpensTheStopUtility()
        {
            new ToolSupportHomePage(_context).ClickStopApprenticeshipsLink();
        }


        [Given(@"Search for Apprentices using following criteria")]
        [Then(@"following filters should return the expected number of TotalRecords")]
        public void ThenFollowingFiltersShouldReturnTheExpectedNumberOfTotalRecords(Table table)
        {
            var filters = table.CreateSet<Filters>();
            int row = 1;

            foreach (var item in filters)
            {
                new SearchForApprenticeshipPage(_context, false)
                       .EnterEmployerName(item.EmployerName)
                       .EnterProviderName(item.ProviderName)
                       .EnterUkprn(item.Ukprn)
                       .EnterEndDate(item.EndDate)
                       .EnterULNorApprenticeName(item.Uln)
                       .SelectStatus(item.Status)
                       .ClickSubmitButton();

                var actualRecord = new SearchForApprenticeshipPage(_context, false).GetNumberOfRecordsFound();
                Assert.GreaterOrEqual(actualRecord, item.TotalRecords, $"Validate number of expected recordson row: {row}");
                row++;
            }       
        }


        [When(@"User selects all records and click on Pause Apprenticeship button")]
        public void WhenUserSelectsAllRecordsAndClickOnPauseApprenticeshipButton()
        {
            UpdateStatusInDb(new SearchForApprenticeshipPage(_context, false).GetULNsFromApprenticeshipTable())
                    .ClickSubmitButton()
                    .SelectAllRecords()
                    .ClickPauseButton();  
        }

        [When(@"User selects all records and click on Resume Apprenticeship button")]
        public void WhenUserSelectsAllRecordsAndClickOnResumeApprenticeshipButton()
        {
           UpdateStatusInDb(new SearchForApprenticeshipPage(_context, false).GetULNsFromApprenticeshipTable())
                    .ClickSubmitButton()
                    .SelectAllRecords()
                    .ClickResumeButton();  
        }

        [When(@"User selects all records and click on Stop Apprenticeship button")]
        public void WhenUserSelectsAllRecordsAndClickOnStopApprenticeshipButton()
        {
            UpdateStatusInDb(new SearchForApprenticeshipPage(_context, false).GetULNsFromApprenticeshipTable())
                    .ClickSubmitButton()
                    .SelectAllRecords()
                    .ClickStopButton();
        }

        [Then(@"User should be able to stop all the records")]
        public void ThenUserShouldBeAbleToStopAllTheRecords()
        {
            var ststusList = new StopApprenticeshipsPage(_context)
                                    .ClickStopBtn()
                                    .ValidateErrorMessage()
                                    .EnterStopDate()
                                    .ClickSetButton()
                                    .ClickStopBtn()
                                    .GetStatusColumn();

            ValidateStopSuccessful(ststusList);
        }


        [Then(@"User should be able to pause all the live records")]
        public void ThenUserShouldBeAbleToPauseAllTheLiveRecords()
        {
            var ststusList = new PauseApprenticeshipsPage(_context)
                                .ClickPauseBtn()
                                .GetStatusColumn();

            ValidatePausedSuccessful(ststusList);
        }

        [Then(@"User should be able to resume all the paused records")]
        public void ThenUserShouldBeAbleToResumeAllThePausedRecords()
        {
            var ststusList = new ResumeApprenticeshipsPage(_context)
                               .ClickResumeBtn()
                               .GetStatusColumn();

            ValidateResumeSuccessful(ststusList);
        }

        private SearchForApprenticeshipPage UpdateStatusInDb(List<IWebElement> UlnList)
        {
            int i = 0;
            foreach (var uln in UlnList)
            {
                if (i >= 0 && i < 4)
                    _commitmentsSqlDataHelper.UpdateApprenticeshipStatus(uln.Text, 1);
                else if (i == 4 || i == 5 || i == 6)
                    _commitmentsSqlDataHelper.UpdateApprenticeshipStatus(uln.Text, 2);
                else if (i == 7 || i == 8)
                    _commitmentsSqlDataHelper.UpdateApprenticeshipStatus(uln.Text, 3);
                else
                    _commitmentsSqlDataHelper.UpdateApprenticeshipStatus(uln.Text, 4);

                i++;
            }

            return new SearchForApprenticeshipPage(_context, false);
        }

        private void ValidatePausedSuccessful(List<IWebElement> StatusList)
        {
            Assert.IsTrue(StatusList.Count == 10, "Validate total number of records");

            int i = 0;
            foreach (var status in StatusList)
            {
                if (i >= 0 && i < 4)
                    Assert.IsTrue(status.Text == "Submitted successfully");
                else if (i == 4|| i == 5 || i == 6)
                    Assert.IsTrue(status.Text == "Paused - Only Active record can be paused");
                else if (i == 7 || i == 8)
                    Assert.IsTrue(status.Text == "Stopped - Only Active record can be paused");
                else
                    Assert.IsTrue(status.Text == "Completed - Only Active record can be paused");

                i++;
            }

        }

        private void ValidateResumeSuccessful(List<IWebElement> StatusList)
        {
            Assert.IsTrue(StatusList.Count == 10, "Validate total number of records");

            int i = 0;
            foreach (var status in StatusList)
            {
                if (i >= 0 && i < 4)
                    Assert.IsTrue(status.Text == "Live - Only paused record can be activated" || status.Text == "WaitingToStart - Only paused record can be activated", "Resuming a Live Record");
                else if (i == 4 || i == 5 || i == 6)
                    Assert.IsTrue(status.Text == "Submitted successfully", "Resuming a Paused Record");
                else if (i == 7 || i == 8)
                    Assert.IsTrue(status.Text == "Stopped - Only paused record can be activated", "Resuming a Stopped Record");
                else
                    Assert.IsTrue(status.Text == "Completed - Only paused record can be activated", "Resuming a Stopped Record");

                i++;
            }

        }

        private void ValidateStopSuccessful(List<IWebElement> StatusList)
        {
            Assert.IsTrue(StatusList.Count == 10, $"Validate total number of records. Expected: 10 | Actual {StatusList.Count}");

            int i = 0;
            foreach (var status in StatusList)
            {
                if (i >= 0 && i < 7)
                    Assert.IsTrue(status.Text == "Submitted successfully", $"validation failed at index [{i}]. Expected was [Submitted successfully]  but actual value displayed is [{status.Text}]");
                else
                    Assert.IsTrue(status.Text == "Apprenticeship must be Active or Paused. Unable to stop apprenticeship", $"validation failed at index [{i}]. Expected was [Apprenticeship must be Active or Paused. Unable to stop apprenticeship]  but actual value displayed is [{status.Text}]");

                i++;
            }

        }

    }

}