using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RegisterMyInterestSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private AssessmentAndCertificationPage assessmentAndCertificationPage;
        private RegisterMyInterestPage  registerMyInterestPage;
        private RegisterMyInterestSuccessPage  registerMyInterestSuccessPage;
        #endregion
        public RegisterMyInterestSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }
        [Given(@"I Click On The Register My Interest Button")]
        public void GivenIClickOnTheRegisterMyInterestButton()
        {
            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.LaunchRegisterMyInterestPage();
            TestContext.Progress.WriteLine("Navigating to Register My Interest page");
            
        }
        
        [Given(@"I Enter My First Name, Last Name And Email")]
        public void GivenIEnterMyFirstNameLastNameAndEmail()
        {
            registerMyInterestPage = new RegisterMyInterestPage(_context);
            registerMyInterestPage.EnterDetail();
        }
        
        [Given(@"I Tick The Radio Button For I Want to Become An Apprentice")]
        public void GivenITickTheRadioButtonForIWantToBecomeAnApprentice()
        {
            registerMyInterestPage = new RegisterMyInterestPage(_context);
            registerMyInterestPage.TickIWantToBecomeAnApprentice();
        }
        
        [Given(@"I Tick The Check Box for To Recieve More Information Via Email")]
        public void GivenITickTheCheckBoxForToRecieveMoreInformationViaEmail()
        {
            registerMyInterestPage = new RegisterMyInterestPage(_context);
            registerMyInterestPage.CheckTheTAndCsCheckBox();
        }
        
        [Given(@"I Click The Register My Interest Button")]
        public void GivenIClickTheRegisterMyInterestButton()
        {
           registerMyInterestPage = new RegisterMyInterestPage(_context);
            registerMyInterestPage.ClickOnRegisterMyInterest();
        }
        
        [Then(@"I Should Recieve a Success Message")]
        public void ThenIShouldRecieveASuccessMessage()
        {
            registerMyInterestSuccessPage = new RegisterMyInterestSuccessPage(_context);
            registerMyInterestSuccessPage.ValidateTheSuccessHeader();
        }
    }
}
