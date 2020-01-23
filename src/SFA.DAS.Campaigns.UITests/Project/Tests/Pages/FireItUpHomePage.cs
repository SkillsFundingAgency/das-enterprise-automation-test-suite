using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class FireItUpHomePage : BasePage
    {
        protected override string PageTitle => "FIRE\r\nIT UP";

        #region Constants
        private const string ExpectedApprenticesHeaderSupportText = "BLAZE YOUR OWN TRAIL AND BECOME AN APPRENTICE";
        private const string ExpectedEmployersHeaderSupportText = "FIRE UP YOUR BUSINESS WITH AN APPRENTICE";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private  RegisterMyInterestPage registerMyInterestPage;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.ClassName("homepage-title");
        private readonly By _apprenticeMenu = By.Id("link-nav-apprentice");
        private readonly By _employerMenu = By.Id("link-nav-employer");
        private readonly By _parentPage =By.Id("link-nav-parents");
        private readonly By _registerMyInterestButton =By.Id("btn-register-interest-header");
        private readonly By _cookieButton = By.Id("link-cookie-accept");
        private readonly By _findAnApprenticeLink = By.Id("link-nav-apprentice");
        private readonly By _ApprenticesHeaderSupportText = By.ClassName("launcher__heading");
        private readonly By _EmployersHeaderSupportText = By.XPath("//*[@classname='launcher__heading']//*[text()='Fire up your business with an apprentice']");
        private readonly By _yourApprenticeshipLink = By.Id("link-nav-app-step-5");
        private readonly By _assessmentAndCertificationApprenticeLink = By.Id("link-nav-app-step-6");
        private readonly By _inetrviewLink = By.Id("link-nav-app-step-4");
        private readonly By _applicationLink = By.Id("link-nav-app-step-3");
        private readonly By _whatIsAnApprenticeshipLink = By.Id("link-nav-app-step-1");
        private readonly By _myinterestsLink = By.Id("link-nav-app-interests");
        private readonly By _whatAreTheBenefitsForMeLink = By.Id("link-nav-app-benefits");
        private readonly By _realStoriesLink = By.Id("link-nav-app-real-stories");
        private readonly By _howMuchIsItGoingToCostLink =By.Id("link-nav-employer");
        private readonly By _theRightApprenticeshipLink =By.Id("link-nav-emp-step-2");
        private readonly By _chooseATrainingProviderLink =By.Id("link-nav-emp-step-3");
        private readonly By _hireAnApprenticeLink =By.Id("link-nav-emp-step-4");
        private readonly By _preparingAndMonitoringLink =By.Id("link-nav-emp-step-5");
        private readonly By _assessmentAndCertificationEmployerLink =By.Id("link-nav-emp-step-6");
        private readonly By _findTheRightApprenticeshipLink =By.Id("link-nav-employer-4");
        private readonly By _howDoTheyWork = By.Id("link-nav-employer-2");
        private readonly By _fundingAnApprenticeshipLink = By.Id("link-nav-emp-step-1");
        private readonly By _settingUp = By.Id("link-nav-employer-3");
        private readonly By _areApprenticeshipRightForYou = By.Id("link-nav-employer-1");
        private readonly By _theCallingLink = By.XPath("//div[@class='thecalling-section__panel']/div[1]/h2");
        #endregion

        public FireItUpHomePage(ScenarioContext context) : base(context)
        {
            _context=context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal void ClickOnCookieContinueButton()
        {
            _formCompletionHelper.ClickElement(_cookieButton);
        }

        internal void VerifyApprenticesHeaderSupportText()
        {
            _pageInteractionHelper.VerifyPage(_ApprenticesHeaderSupportText, ExpectedApprenticesHeaderSupportText);
        }

        internal void VerifyEmployersHeaderSupportText()
        {
            _pageInteractionHelper.VerifyPage(_EmployersHeaderSupportText, ExpectedEmployersHeaderSupportText);
        }

        internal void LaunchApprenticeMenu()
        {
            _pageInteractionHelper.FocusTheElement(_apprenticeMenu);
        }

        internal void ClickOnFindAnApprenticeLink()
        {
            _formCompletionHelper.ClickElement(_findAnApprenticeLink);
        }

        internal void ClickOnYourApprenticeshipLink()
        {
            _formCompletionHelper.ClickElement(_yourApprenticeshipLink);
        }

        internal void ClickOnAssessmentAndCertificationApprenticeLink()
        {
            _formCompletionHelper.ClickElement(_assessmentAndCertificationApprenticeLink);
        }

        internal void ClickOnInterviewLink()
        {
            _formCompletionHelper.ClickElement(_inetrviewLink);
        }

        internal void ClickOnApplicationLink()
        {
            _formCompletionHelper.ClickElement(_applicationLink);
        }

        internal void ClickOnWhatIsAnApprenticeshipLink()
        {
            _formCompletionHelper.ClickElement(_whatIsAnApprenticeshipLink);
        }

        internal void ClickOnMyInterestsLink()
        {
            _formCompletionHelper.ClickElement(_myinterestsLink);
        }

        internal void ClickOnWhatAreTheBenefitsForMeLink()
        {
            _formCompletionHelper.ClickElement(_whatAreTheBenefitsForMeLink);
        }

        internal void ClickOnRealStoriesLink()
        {
            _formCompletionHelper.ClickElement(_realStoriesLink);
        }

         internal EmployerMenuOptionPage LaunchEmployerMenu()
         {
            _formCompletionHelper.ClickElement(_employerMenu);
            return new EmployerMenuOptionPage(_context);
         }

        internal HowMuchIsItGoingToCostPage ClickOnHowMuchIsItGoingToCostLink()
        {
            _formCompletionHelper.ClickElement(_howMuchIsItGoingToCostLink);
            return new HowMuchIsItGoingToCostPage(_context);
        }

        internal TheRightApprenticeshipPage ClickTheRightApprenticeshipLink()
        {
            _formCompletionHelper.ClickElement(_theRightApprenticeshipLink);
            return new TheRightApprenticeshipPage(_context);
        }
        internal ChoosingATrainingProviderPage ClickChoosingATrainingProviderLink()
        {
            _formCompletionHelper.ClickElement(_chooseATrainingProviderLink);
            return new ChoosingATrainingProviderPage(_context);
        }
        internal HireAnApprenticePage ClicKHireAnApprenticeLink()
        {
            _formCompletionHelper.ClickElement(_hireAnApprenticeLink);
            return new HireAnApprenticePage(_context);
        }

        internal HowMuchIsItGoingToCostPage ClickOnFundingAnApprenticeshipLink()
        {
            _formCompletionHelper.ClickElement(_fundingAnApprenticeshipLink);
            return new HowMuchIsItGoingToCostPage(_context);
        }
        internal PreparingAndMonitoringPage ClickPreparingAndMonitoringLink()
        {
             _formCompletionHelper.ClickElement(_preparingAndMonitoringLink);
            return new PreparingAndMonitoringPage(_context);
        }
        internal HelpShapeTheirCareerPage LaunchParentPage()
         {
           _formCompletionHelper.ClickElement(_parentPage);
            return new HelpShapeTheirCareerPage(_context);
         }
        internal RegisterMyInterestPage LaunchRegisterMyInterestPage()
         {
           _formCompletionHelper.ClickElement( _registerMyInterestButton);
            return new RegisterMyInterestPage(_context);
         }
        internal FindTheRightApprenticeshipPage ClickFindTheRightApprenticeshipPage()
        {
            _formCompletionHelper.ClickElement(_findTheRightApprenticeshipLink);
            return new FindTheRightApprenticeshipPage(_context);
        }
        internal EmployerAssessmentAndCertificationPage ClickOnAssessmentAndCertificationEmployerLink()
        {
            _formCompletionHelper.ClickElement(_assessmentAndCertificationEmployerLink);
            return new EmployerAssessmentAndCertificationPage(_context);
        }

        internal EmployerMenuOptionPage FocusOnEmployerHowDoTheyWorkMenu()
        {
            _pageInteractionHelper.FocusTheElement(_howDoTheyWork);
            return new EmployerMenuOptionPage(_context);
        }

        internal EmployerMenuOptionPage FocusOnEmployerSettingUpMenue()
        {
            _pageInteractionHelper.FocusTheElement(_settingUp);
            return new EmployerMenuOptionPage(_context);
        }
        internal EmployerMenuOptionPage FocusOnEmployerAreApprenticeshipRightForYouMenue()
        {
            _pageInteractionHelper.FocusTheElement(_areApprenticeshipRightForYou);
            return new EmployerMenuOptionPage(_context);
        }
        internal JamalTheCallingPage ClickOnTheCallingLink()
        {
            registerMyInterestPage = new RegisterMyInterestPage(_context);
            registerMyInterestPage.RemoveTheAlertBanner();
            _formCompletionHelper.ClickElement(_theCallingLink);
            return new JamalTheCallingPage(_context);
        }
    }
}
