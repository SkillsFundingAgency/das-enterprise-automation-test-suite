using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CheckAssessmentAndCertificationLinkSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private AssessmentAndCertificationPage assessmentAndCertificationPage;
        private EmployerAssessmentAndCertificationPage employerAssessmentAndCertificationPage;
        #endregion
        public CheckAssessmentAndCertificationLinkSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }
        [Given(@"I launch Assessment And Certification page")]
        public void GivenILaunchAssessmentAndCertificationPage()
        {
            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.FocusOnEmployerHowDoTheyWorkMenu();
            TestContext.Progress.WriteLine("Navigating to Assessment And Certification page");
            fireItUpHomePage.ClickOnAssessmentAndCertificationEmployerLink();
        }
        
        [Then(@"I verify the title for Assessment And Certification page")]
        public void ThenIVerifyTheTitleForAssessmentAndCertificationPage()
        {
            employerAssessmentAndCertificationPage= new EmployerAssessmentAndCertificationPage(_context);
            employerAssessmentAndCertificationPage.CheckEmployerAssessmentAndCertificationContent();
        }
    }
}
