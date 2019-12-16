using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionHomePage
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        #endregion

        public StepDefinitionHomePage(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Given(@"I navigate to Fire It Up home page")]
        public void NavigateToGovUkHomePage()
        {
            var url = _configuration.CA_BaseUrl;
            TestContext.Progress.WriteLine("Navigating to Fire It Up home page");
            _webDriver.Url = url;

            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.ClickOnCookieContinueButton();
            fireItUpHomePage.VerifyApprenticesHeaderSupportText();
        }

        [Given(@"I launch the Find An Apprentice page")]
        public void LaunchFindAnApprenticePage()
        {
            TestContext.Progress.WriteLine("Navigating to Find An Apprenticeship page");
            fireItUpHomePage.ClickOnFindAnApprenticeLink();
        }

        [Given(@"I launch the Your Apprenticeship page")]
        public void LaunchYourApprenticeshipPage()
        {
            fireItUpHomePage.LaunchApprenticeMenu();
            TestContext.Progress.WriteLine("Navigating to Your Apprenticeship page");
            fireItUpHomePage.ClickOnYourApprenticeshipLink();
        }

        [Given(@"I launch the Assessment And Certification page")]
        public void LaunchAssessmentAndCertificationPage()
        {
            fireItUpHomePage.LaunchApprenticeMenu();
            TestContext.Progress.WriteLine("Navigating to Assessment And Certification page");
            fireItUpHomePage.ClickOnAssessmentAndCertificationApprenticeLink();
        }

        [Given(@"I launch the Interview page")]
        public void LaunchInterviewPage()
        {
            fireItUpHomePage.LaunchApprenticeMenu();
            TestContext.Progress.WriteLine("Navigating to Interview page");
            fireItUpHomePage.ClickOnInterviewLink();
        }

        [Given(@"I launch the Application page")]
        public void LaunchApplicationPage()
        {
            fireItUpHomePage.LaunchApprenticeMenu();
            TestContext.Progress.WriteLine("Navigating to Application page");
            fireItUpHomePage.ClickOnApplicationLink();
        }

        [Given(@"I launch the What Is An Apprenticeship page")]
        public void LaunchWhatIsAnApprenticeshipPage()
        {
            fireItUpHomePage.LaunchApprenticeMenu();
            TestContext.Progress.WriteLine("Navigating to What Is An Apprenticeship page");
            fireItUpHomePage.ClickOnWhatIsAnApprenticeshipLink();
        }

        [Given(@"I launch the My Interests page")]
        public void LaunchMyInterestsPage()
        {
            fireItUpHomePage.LaunchApprenticeMenu();
            TestContext.Progress.WriteLine("Navigating to My Interests page");
            fireItUpHomePage.ClickOnMyInterestsLink();
        }

        [Given(@"I launch the What Are The Benefits For Me page")]
        public void LaunchWhatAreTheBenefitsForMePage()
        {
            TestContext.Progress.WriteLine("Navigating to What Are The Benefits For Me page");
            fireItUpHomePage.ClickOnWhatAreTheBenefitsForMeLink();
        }

        [Given(@"I launch the Real Stories page")]
        public void LaunchRealStoriesPage()
        {
            TestContext.Progress.WriteLine("Navigating to Real Stories page");
            fireItUpHomePage.ClickOnRealStoriesLink();
        }

    }
}