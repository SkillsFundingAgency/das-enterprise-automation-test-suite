using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System.Linq;
using TechTalk.SpecFlow;
using static SFA.DAS.EmployerIncentives.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EISteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EILevyUser _eILevyUser;
        private SelectApprenticesShutterPage _selectApprenticesShutterPage;
        private QualificationQuestionPage _qualificationQuestionPage;
        private QualificationQuestionShutterPage _qualificationQuestionShutterPage;
        private EmployerAgreementShutterPage _employerAgreementShutterPage;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly MultipleAccountUser _multipleAccountUser;
        private ViewApplicationsShutterPage _viewApplicationsShutterPage;
        private EINavigationHelper _eINavigationHelper;
        private string email;

        public EISteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _multipleAccountUser = _context.GetUser<MultipleAccountUser>();
            _eILevyUser = _context.GetUser<EILevyUser>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _homePageStepsHelper = new EmployerHomePageStepsHelper(_context);
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(_context);
            _eINavigationHelper = new EINavigationHelper(_context);
        }

        [When(@"the Employer switches to an account without apprentices")]
        public void WhenTheEmployerSwitchesToAnAccountWithoutApprentices()
        {
            var secondOrganisationName = _multipleAccountUser.SecondOrganisationName;

            var yourAccountPage = new HomePage(_context, true).GoToYourAccountsPage();

            _objectContext.UpdateOrganisationName(secondOrganisationName);

            yourAccountPage.GoToHomePage(secondOrganisationName);
        }

        [Given(@"the Employer logins using existing multiple account user")]
        public void GivenTheEmployerLoginsUsingExistingMultipleAccountUser() => _multipleAccountsLoginHelper.Login(_multipleAccountUser, true);

        [Then(@"Access to EI Hub is denied to the Employer")]
        public void ThenAccessToEIHubIsDeniedToTheEmployer() =>
            new HomePageFinancesSection(_context).AccessEIHubLinkRedirectsToAccessDeniedPage().GoBackToTheServiceHomePage();

        [Then(@"the Employer is able to navigate to EI application Select apprentices page")]
        public void TheEmployeIsAbleToNavigateToEIApplicationSelectApprenticesPage() => _qualificationQuestionPage.SelectYesAndContinueForEligibleApprenticesScenario();

        [Then(@"the Employer is able to submit the EI Application")]
        public void ThenTheEmployerIsAbleToSubmitTheEIApplication()
        {
            SubmitEiApplicationWithOutBankDetails()
                .ChooseYesAndContinue()
                .ContinueToAddBankDetails()
                .ContinueToOrgDetailsPage()
                .ContinueToAddressDetailsPage()
                .SubmitAddressDetails(email)
                .SubmitBankDetails()
                .SubmitSubmitterDetails(email)
                .SubmitSummaryPage()
                .ReturnToEasPage()
                .ReturnToAccountHomePage();

            _homePageStepsHelper.GotoEmployerHomePage();
        }

        [Then(@"the Employer is able to submit the EI Application without VRF")]
        public void ThenTheEmployerIsAbleToSubmitTheEIApplicationWithoutVRF()
        {
            SubmitEiApplicationWithOutBankDetails()
                .ChooseNoAndContinue()
                .NavigateToViewApplicationsPage();
        }

        [Then(@"the Employer is able to submit the EI Application without submitting bank details")]
        public void ThenTheEmployerIsAbleToSubmitTheEIApplicationWithoutSubmittingBankDetails() => SubmitEiApplicationWithOutBankDetails();

        [Then(@"Earnings data is populated for the Employer")]
        public void ThenEarningsDataIsPopulatedForTheEmployer()
        {
            var startMonth = _objectContext.GetEIStartMonth();
            var startYear = _objectContext.GetEIStartYear();
            var ageCategory = _objectContext.GetEIAgeCategoryAsOfAug2020();
            _context.Get<EISqlHelper>().VerifyEarningData(email, startMonth, startYear, ageCategory);
        }

        [Then(@"the Employer is able to view EI applications")]
        public void ThenTheEmployerIsAbleToViwEIApplications()
        {
            _homePageStepsHelper.GotoEmployerHomePage();
            new HomePageFinancesSection(_context).NavigateToEIHubPage().NavigateToEIViewApplicationsPage();
        }

        [When(@"the Employer navigates back to Qualification page for (Single|Multiple) entity account")]
        [When(@"the Employer Initiates EI Application journey for (Single|Multiple) entity account")]
        [When(@"the Employer Initiates EI Application journey for (Single|Multiple) entity account again")]
        [Then(@"the Employer is able to navigate to EI start page for (Single|Multiple) entity account")]
        public void TheEmployerInitiatesEIApplicationJourneyForSingleEntityAccount(Entities entities)
        {
            var homePageFinancesSection = new HomePageFinancesSection(_context);

            if (entities == Entities.Single)
                _qualificationQuestionPage = _eINavigationHelper.NavigateToEISelectApprenticesPage();
            else if (entities == Entities.Multiple)
                _qualificationQuestionPage = homePageFinancesSection.NavigateToChooseOrgPage().SelectFirstEntityInChooseOrgPageAndContinue().ClickApplyLinkOnEIHubPage().ClickStartNowButtonInEIApplyPage();
        }

        [Then(@"Select apprentices shutter page is displayed for selecting Yes option in Qualification page")]
        public void ThenSelectApprenticesShutterPageIsDisplayedForSelectingYesOptionInQualificationPage() =>
            _selectApprenticesShutterPage = _qualificationQuestionPage.SelectYesAndContinueForNoEligibleApprenticesScenario();

        [Then(@"Qualification question shutter page is displayed for selecting No option in Qualification page")]
        public void ThenQualificationQuestionShutterPageIsDisplayedForSelectingNoOptionInQualificationPage() =>
            _qualificationQuestionShutterPage = _qualificationQuestionPage.SelectNoAndContinue();

        [Then(@"Approvals home page is displayed on clicking on Add apprentices link on Select apprentices shutter page")]
        public void ThenApprovalsHomePageIsDisplayedOnClickingOnAddApprenticesLinkOnSelectApprenticesShutterPage() => _selectApprenticesShutterPage.ClickOnAddApprenticesLink();

        [Then(@"Employer Home page is displayed on clicking on Return to Account Home button on Qualification shutter page")]
        public void ThenEmployerHomePageIsDisplayedOnClickingOnReturnToAccountHomeButtonOnQualificatioShutterPage() => _qualificationQuestionShutterPage.ClickOnReturnToAccountHomeLink();

        [Then(@"Employer agreement shutter page is displayed for selecting Yes option in the Qualification page")]
        public void ThenEmployerAgreementShutterPageIsDisplayedForSelectingYesOptionInTheQualificationPage() =>
            _employerAgreementShutterPage = _qualificationQuestionPage.SelectYesAndContinueForUnSignedAgreementScenario();

        [Then(@"Employer Home page is displayed on clicking on Return to Account home link on Employer agreement shutter page")]
        public void ThenEmployerHomePageIsDisplayedOnClickingOnReturnToAccountHomeLinkOnEmployerAgreementShutterPage() =>
            _employerAgreementShutterPage.ClickOnReturnToAccountHomeLink();

        [Then(@"Your Agreements page is displayed on clicking on View agreement button on Employer agreement shutter page")]
        public void ThenYourAgreementsPageIsDisplayedOnClickingOnViewAgreementButtonOnEmployerAgreementShutterPage() =>
            _employerAgreementShutterPage.ClickOnViewAgreementButton();

        [Given(@"the Provider approves the apprenticeship request")]
        [When(@"the Provider approves the apprenticeship request")]
        [Then(@"the Provider approves the apprenticeship request")]
        public void ProviderAddsUlnsAndApprovesTheCohorts()
        {
            _providerStepsHelper.Approve();
            _homePageStepsHelper.GotoEmployerHomePage();
        }

        [Then(@"View EI applications shutter page is diplayed to the Employer when navigating to View EI applications page with no applications")]
        public void ThenViewEIApplicationsShutterPageIsDiplayedToTheEmployerWhenNavigatingToViewEIApplicationsPageWithNoApplications()
        {
            _viewApplicationsShutterPage = new HomePageFinancesSection(_context).NavigateToEIHubPage().NavigateToEIViewApplicationsShutterPage();
        }

        [Then(@"EI Start page is displayed on clicking on Apply for the payment link on View EI applications shutter page")]
        public void ThenEIStartPageIsDisplayedOnClickingOnApplyForThePaymentLinkOnViewEIApplicationsShutterPage()
        {
            _viewApplicationsShutterPage.ClickOnApplyButton();
            new HomePage(_context, true);
        }

        private WeNeedYourOrgBankDetailsPage SubmitEiApplicationWithOutBankDetails()
        {
            email = _context.ScenarioInfo.Tags.Contains("eie2ejourney") ? _eILevyUser.Username : _objectContext.Get("registeredemailaddress");

            return _qualificationQuestionPage
                .SelectYesAndContinueForEligibleApprenticesScenario()
                .SubmitApprentices()
                .ConfirmApprentices()
                .SubmitDeclaration();
        }
    }
}
