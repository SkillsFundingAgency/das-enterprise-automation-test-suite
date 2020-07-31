using NUnit.Framework;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Admin;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.AR_Admin;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.StepDefinitions
{
    [Binding]
    public class AdminSteps
    {
        private readonly ScenarioContext _context;
        private readonly AR_LoginStepsHelper _aR_LoginStepsHelper;

        public AdminSteps(ScenarioContext context)
        {
            _context = context;
            _aR_LoginStepsHelper = new AR_LoginStepsHelper(context);
        }

        [Given(@"the Admin Successfully Logs into appliation")]
        public void GivenTheAdminSuccessfullyLogsIntoAppliation() => GoToApprenticeRedundancyAdminHomePage();
        private ApprenticeMatchingDashBoardPage GoToApprenticeRedundancyAdminHomePage()
        {
            _aR_LoginStepsHelper.SubmitValidLoginDetails();
            return new ApprenticeMatchingDashBoardPage(_context);
        }

        [Given(@"Downloads Apprentice Data")]
        public void GivenDownloadsApprenticeData()
        {
            ApprenticeMatchingDashBoardPage apprenticeMatchingDashBoardPage = new ApprenticeMatchingDashBoardPage(_context);
            apprenticeMatchingDashBoardPage.SelectApprenticeReportAndConfirmDates().SelectCSVFileAndDownload();
        }

        [Given(@"Downloads Employers Data")]
        public void GivenDownloadsEmployersData()
        {
            ApprenticeMatchingDashBoardPage apprenticeMatchingDashBoardPage = new ApprenticeMatchingDashBoardPage(_context);
            apprenticeMatchingDashBoardPage.SelectEmployerReportAndConfirmDates().SelectCSVFileAndDownload();
        }

        [Given(@"Downloads Marketo Apprentice Data")]
        public void GivenDownloadsMarketoApprenticeData()
        {
            ApprenticeMatchingDashBoardPage apprenticeMatchingDashBoardPage = new ApprenticeMatchingDashBoardPage(_context);
            apprenticeMatchingDashBoardPage.SelectApprenticeReportAndConfirmDates().SelectMarketoFileAndDownload();
        }

        [Given(@"Downloads Marketo Employer Data")]
        public void GivenDownloadsMarketoEmployerData()
        {
            ApprenticeMatchingDashBoardPage apprenticeMatchingDashBoardPage = new ApprenticeMatchingDashBoardPage(_context);
            apprenticeMatchingDashBoardPage.SelectEmployerReportAndConfirmDates().SelectMarketoFileAndDownload();
        }

        [When(@"the Admin do not complete all the mandatory fields")]
        public void WhenTheAdminDoNotCompleteAllTheMandatoryFields()
        {
            ApprenticeMatchingDashBoardPage apprenticeMatchingDashBoardPage = new ApprenticeMatchingDashBoardPage(_context);
            apprenticeMatchingDashBoardPage.ContinueWithoutSelectingReportAndDate();
        }

        [Then(@"Errors displayed for not completing the mandatory information on Admin Download")]
        public void ThenErrorsDisplayedForNotCompletingTheMandatoryInformationOnAdminDownload()
        {
            List<string> expectedApprenticeErrorMessages = new List<string>
            {
               "Select if you want to download the employer or apprentice matching report activity",
               "Enter a matching report 'from' date",
               "Enter a matching report 'to' date",
               "Select a file type",
            };
            ApprenticeMatchingDashBoardPage _apprenticeMatchingDashBoardPage = new ApprenticeMatchingDashBoardPage(_context);
            var actualMessages = _apprenticeMatchingDashBoardPage.GetErrorMessages();

            Assert.IsTrue(expectedApprenticeErrorMessages.All(x => actualMessages.Contains(x)), $"Not all Admin error messages are found");
        }
    }
}
