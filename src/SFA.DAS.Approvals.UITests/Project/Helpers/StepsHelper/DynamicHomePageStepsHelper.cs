using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class DynamicHomePageStepsHelper
    {
        private readonly ScenarioContext _context;
        DynamicHomePages _dynamicHomePages;

        public DynamicHomePageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _dynamicHomePages = new DynamicHomePages(_context);
        }
        public void DynamicHomePageTriageJourney()
        {
            _dynamicHomePages.StartNowToReserveFunding()
                .YesToCourse()
                .YesToTrainingProviderToDeliver()
                .YesWillTrainingStartInSixMonths()
                .YesSetupForExistingEmployee()
                .YesContinueToReserveFunding()
                .ClickReserveFundingButton();
        }
        public void DynamicHomePageGoToHome()
        {
            _dynamicHomePages.GoToHomePage();
        }
        public void DynamicHomePageVerifyContinueOnHomePagePanel()
        {
            _dynamicHomePages.VerifyReserveFundingPanel();
        }
    }
}