using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Admin;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.AR_Admin;
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
            apprenticeMatchingDashBoardPage.SelectApprenticeReportAndDownload();
        }

        [Given(@"Downloads Employers Data")]
        public void GivenDownloadsEmployersData()
        {
            ApprenticeMatchingDashBoardPage apprenticeMatchingDashBoardPage = new ApprenticeMatchingDashBoardPage(_context);
            apprenticeMatchingDashBoardPage.SelectEmployerReportAndDownload();
        }

    }
}
