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
        private bool _doNotdeleteInentiveapplication;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EILevyUser _eILevyUser;
        private EIStartPage _eIStartPage;
        private SelectApprenticesShutterPage _selectApprenticesShutterPage;
        private QualificationQuestionPage _qualificationQuestionPage;
        private QualificationQuestionShutterPage _qualificationQuestionShutterPage;
        private EmployerAgreementShutterPage _employerAgreementShutterPage;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly EISqlHelper _eISqlHelper;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly MultipleAccountUser _multipleAccountUser;

        public EISteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _multipleAccountUser = _context.GetUser<MultipleAccountUser>();
            _eISqlHelper = context.Get<EISqlHelper>();
            _eILevyUser = _context.GetUser<EILevyUser>();
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _homePageStepsHelper = new EmployerHomePageStepsHelper(_context);
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(_context);
        }

        [When(@"the Employer switches to an account without aprentices")]
        public void WhenTheEmployerSwitchesToAnAccountWithoutAprentices()
        {
            var secondOrganisationName = _multipleAccountUser.SecondOrganisationName;

            var yourAccountPage = new HomePage(_context, true).GoToYourAccountsPage();

            _objectContext.UpdateOrganisationName(secondOrganisationName);

            yourAccountPage.GoToHomePage(secondOrganisationName);
        }

        [Given(@"the Employer logins using existing multiple account user")]
        public void GivenTheEmployerLoginsUsingExistingMultipleAccountUser() => _multipleAccountsLoginHelper.Login(_multipleAccountUser, true);

        [Then(@"the Employer is not able to navigate to employer incentive application")]
        public void ThenTheEmployerIsNotAbleToNavigateToEmployerIncentiveApplication()
        {
            new HomePageFinancesSection(_context).AccessEIAndAndRedirectedToAccessDeniedPage().ReturnToAccountHomePage();
        }

        [Then(@"the Employer is not able to view EI applications")]
        public void ThenTheEmployerIsNotAbleToViewEIApplications()
        {
            new HomePageFinancesSection(_context).AccessViewEIAndAndRedirectedToAccessDeniedPage().ReturnToAccountHomePage();
        }

        [Then(@"the Employer can continue for eligible apprentices scenario")]
        public void TheEmployerCanContinueForEligibleApprenticesScenario() => _qualificationQuestionPage.SelectYesAndContinueForEligibleApprenticesScenario();


        [Then(@"the Employer is able to submit the EI Application")]
        public void ThenTheEmployerIsAbleToSubmitTheEIApplication()
        {
            _qualificationQuestionPage
                .SelectYesAndContinueForEligibleApprenticesScenario()
                .SubmitApprentices()
                .ConfirmApprentices()
                .SubmitDeclaration()
                .ChooseYesAndContinue()
                .ContinueToAddBankDetails()
                .ContinueToOrgDetailsPage()
                .ContinueToAddressDetailsPage()
                .SubmitAddressDetails(_eILevyUser.Username)
                .SubmitBankDetails()
                .SubmitSubmitterDetails(_eILevyUser.Username)
                .SubmitSummaryPage()
                .ReturnToEasPage()
                .ReturnToAccountHomePage();

            _doNotdeleteInentiveapplication = true;
        }

        [Then(@"the Employer is able to navigate to View Applications page")]
        public void ThenTheEmployerIsAbleToNavigateToViewApplicationsPage()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            new HomePageFinancesSection(_context).NavigateToViewApplicationsPage();
        }

        [When(@"the Employer navigates back to Qualification page for (Single|Multiple) entity account")]
        [When(@"the Employer Initiates EI Application journey for (Single|Multiple) entity account")]
        [When(@"the Employer Initiates EI Application journey for (Single|Multiple) entity account again")]
        [Then(@"the Employer is able to navigate to EI start page for (Single|Multiple) entity account")]
        public void TheEmployerInitiatesEIApplicationJourneyForSingleEntityAccount(Entities entities)
        {
            if (!_doNotdeleteInentiveapplication && _context.ScenarioInfo.Tags.Contains("eie2ejourney"))
            {
                _eISqlHelper.DeleteIncentiveApplication(_registrationSqlDataHelper.GetAccountId(_eILevyUser.Username));
            }

            _eIStartPage = new HomePageFinancesSection(_context).NavigateToEIStartPage();

            if (entities == Entities.Single)
                _qualificationQuestionPage = _eIStartPage.ClickStartNowButtonInEIStartPageForSingleEntityJourney();
            else if (entities == Entities.Multiple)
                _qualificationQuestionPage = _eIStartPage.ClickStartNowButtonInEIStartPageForMultipleEntityJourney().SelectFirstEntityInChooseOrgPageAndContinue();
        }

        [Given(@"the Employer logins using existing EI Levy Account")]
        public void GivenTheEmployerLoginsUsingExistingEILevyAccount() => _employerPortalLoginHelper.Login(_eILevyUser, true);

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
        public void ProviderAddsUlnsAndApprovesTheCohorts()
        {
            _providerStepsHelper.Approve();
            _homePageStepsHelper.GotoEmployerHomePage();
        }
    }
}
