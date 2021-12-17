using OpenQA.Selenium.Support.UI;
using SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers
{
    public class EmployerFrontDoorStepsHelper
    {
        private readonly ScenarioContext _context;

        public EmployerFrontDoorStepsHelper(ScenarioContext context) => _context = context;
        public EmployerFrontDoorHomePage GoToEmployerFrontDoorHomePage() {

            EmployerFrontDoorHomePage homePage = new EmployerFrontDoorHomePage(_context);
            homePage.AcceptCookieAndAlert();
            return homePage;
        }

        public ApprenticeshipsDetailsPage GoToApprenticeshipsDetailsPage()
        {
            
            ApprenticeshipsDetailsPage apprenticeshipsPage = new ApprenticeshipsDetailsPage(_context);
          
          /*  WebDriverWait wait = new WebDriverWait(driver, 100);
            WebElement element = wait.until(ExpectedConditions.elementToBeClickable(By.id("submit"))); */
            
            apprenticeshipsPage.ApprenticeshipsScheme();
            
            return apprenticeshipsPage;
        }

        public TLevelsDetailsPage GoToTLevelsDetailsPage()
        {
            TLevelsDetailsPage tLevelsPage = new TLevelsDetailsPage(_context);
            Thread.Sleep(3000);
            tLevelsPage.TLevelsScheme();
            Thread.Sleep(3000);
            return tLevelsPage;
        }

        public SWAPDetailsPage GoToSWAPDetailsPage()
        {
            SWAPDetailsPage swapPage = new SWAPDetailsPage(_context);
            Thread.Sleep(3000);
            swapPage.SWAPScheme();
            Thread.Sleep(3000);
            return swapPage;
        }

        public SkillsBootcampsDetailsPage GoToSkillsBootcampsDetailsPage()
        {
            SkillsBootcampsDetailsPage bootCampsPage = new SkillsBootcampsDetailsPage(_context);
            bootCampsPage.SkillsBootcampsScheme();
            return bootCampsPage;
        }


        // public ApprenticeshipsHubPage GoToApprenticeshipsHubPage() => GoToEmployerFrontDoorHomePage().NavigateToApprenticeshipsHubPage();

        // public ApprenticeHubPage GoToApprenticeshipHubPage() => GoToEmployerFrontDoorHomePage().NavigateToApprenticeshipHubPage();

        //public EmployerHubPage GoToEmployerHubPage() => GoToEmployerFrontDoorHomePage().NavigateToEmployerHubPage();

        //public InfluencersHubPage GoToInfluencersHubPage() => GoToEmployerFrontDoorHomePage().NavigateToInfluencersHubPage();
    }
}

