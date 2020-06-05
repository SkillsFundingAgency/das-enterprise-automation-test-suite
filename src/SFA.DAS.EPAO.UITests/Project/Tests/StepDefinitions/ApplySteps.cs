using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class ApplySteps
    {
        private readonly ScenarioContext _context;
        private AP_ApplicationOverviewPage _applicationOverviewPage;
        private AS_CreateAnAccountPage _createAnAccountPage;
        private readonly AssessmentServiceStepsHelper _stepsHelper;
        private readonly EPAODataHelper _dataHelper;

        public ApplySteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new AssessmentServiceStepsHelper(_context);
            _dataHelper = context.Get<EPAODataHelper>();
        }

        [When(@"the Apply User completes preamble journey")]
        public void WhenTheApplyUserCompletesPreambleJourney()
        {
            _applicationOverviewPage = new AP_PR1_SearchForYourOrganisationPage(_context)
                .EnterOrgNameAndSearchInSearchForYourOrgPage()
                .ClickOrgLinkFromSearchResultsForPage()
                .SelectTrainingProviderRadioButtonAndContinueInSelectOrgTypePage()
                .ClickConfirmAndApplyButtonInConfirmOrgPage()
                .ClickAcceptAndContinueInDeclarationPage();
        }

        [When(@"the Apply User completes Organisation details section")]
        public void WhenTheApplyUserCompletesOrganisationDetailsSection()
        {
            _applicationOverviewPage = _applicationOverviewPage
                .ClickGoToOrganisationDetailsLinkInApplicationOverviewPage()
                .ClickTradingNameLinkInOrganisationDetailsBasePage()
                .GiveATradingNameAndContinueInTradingNamePage()
                .SelectYesAndContinueInUseYourTradingNameOnTheRegisterPage()
                .EnterContactDetailsAndContinueInContactDetailsPage()
                .EnterContactDetailsAndContinueInContractNoticeToPage()
                .EnterUkprnAndContinueInDoYouHaveAUkprnPage()
                .EnterDetailsAndContinueInOEMPage()
                .EnterDetailsAndContinueInOfqualRecognitionNumberPage()
                .SelectPubliLimitedCompanyOptionAndContinueInTradingStatusPage()
                .EnterNumberAndContinueInCompanyNumberPage()
                .EnterNumberAndContinueInDirectoDetailsPage()
                .SelectNoOptionAndContinueInDirectorsDataPage()
                .EnterCharityDetailsAndContinueInRegisteredCharityPage()
                .SelectNoOptionAndContinueInRegisterOfRemovedTrusteesPage()
                .ClickReturnToApplicationOverviewButton()
                .VerifyOrganisationDetailsSectionCompletedText();
        }

        [When(@"the Apply User completes the Declarations section")]
        public void WhenTheApplyUserCompletesTheDeclarationsSection()
        {
            _applicationOverviewPage = _applicationOverviewPage
                .ClickGoToDeclarationsLinkInApplicationOverviewPage()
                .ClickNameAndJobTitleLinkInDeclarationsBasePage()
                .EnterDetailsAndContinueInAuthoriserDetailsPagePage()
                .SelectNoOptionAndContinueInCriminalConvictionsPage()
                .SelectNoOptionAndContinueInFinancialConvictionsPage()
                .SelectNoOptionAndContinueInCounterTerrorismPage()
                .SelectNoOptionAndContinueInOtherCriminalConvictionsPage()
                .SelectNoOptionInTaxAndSocialSecurityIrregularitiesPage()
                .SelectNoOptionAndContinueInBankruptcyAndInsolvencyPage()
                .SelectNoOptionAndContinueInCessationOfTradingPage()
                .SelectNoOptionAndContinueInTheIncorrectTaxReturnsPage()
                .SelectNoOptionAndContinueInHmrcChallengesPage()
                .SelectNoOptionAndContinueInContractsWithdrawnFromYouPage()
                .SelectNoOptionAndContinueInContractsYouHaveWithdrawnFromPage()
                .SelectNoOptionAndContinueInOrganisationRemovalFromRegistersPage()
                .SelectNoOptionAndContinueInDirectionAndSanctionsPage()
                .SelectNoOptionAndContinueInRepaymentOfPublicMoneyPage()
                .SelectNoOptionAndContinueInPublicbodyFundsAndContractsPage()
                .SelectNoOptionAndContinueInLegalDisputePage()
                .SelectYesOptionAndContinueInFalseDeclarationsPage()
                .SelectYesOptionAndContinueInAccurateRepresentationPage()
                .SelectYesOptionAndContinueInAgreementOnTheRegisterPage()
                .ClickReturnToApplicationOverviewButton()
                .VerifyDeclarationsSectionCompletedText();
        }

        [When(@"the Apply User completes the FHA section")]
        public void WhenTheApplyUserCompletesTheFHASection()
        {
            _applicationOverviewPage = _applicationOverviewPage
                .ClickGoToFinancialHealthAssessmentLinkInApplicationOverviewPage()
                .ClickFHALinkInFHABasePage()
                .UploadFileAndContinueInFinancialHealthPage()
                .ClickReturnToApplicationOverviewButton()
                .VerifyFHASectionCompletedText();
        }

        [Then(@"the application is allowed to be submitted")]
        public void ThenTheApplicationIsAllowedToBeSubmitted() => _applicationOverviewPage.ClickSubmitInApplicationOverviewPage();

        [Then(@"the User Name is displayed in the Logged In Home page")]
        public void ThenTheUserNameIsDisplayedInTheLoggedInHomePage() => new AS_LoggedInHomePage(_context).VerifySignedInUserName(_context.GetUser<EPAOApplyUser>().FullName);

        [Then(@"the Apply User is able to Signout from the application")]
        public void ThenTheApplyUserIsAbleToSignoutFromTheApplication() => new AS_LoggedInHomePage(_context).ClickSignOutLink().ClickSignBackInLink();

        [When(@"the Apply User initiates Create Account journey")]
        public void WhenTheApplyUserInitiatesCreateAccountJourney() => _createAnAccountPage = _stepsHelper.LaunchAssessmentServiceApplication().ClickCreateAnAccountLink();

        [Then(@"the Apply User is able to Create an Account")]
        public void ThenTheApplyUserIsAbleToCreateAnAccount() => _createAnAccountPage.EnterAccountDetailsAndClickCreateAccount();

        [Then(@"no matches are shown for Organisation searches with Invalid search term")]
        public void ThenNoMatchesAreShownForOrganisationSearchesWithInvalidSearchTerm()
        {
            new AP_PR1_SearchForYourOrganisationPage(_context)
                .EnterInvalidOrgNameAndSearchInSearchForYourOrgPage(_dataHelper.InvalidOrgNameWithAlphabets)
                .VerifyInvalidSearchResultText()
                .EnterInvalidOrgNameAndSearchInSearchResultsForPage(_dataHelper.InvalidOrgNameWithNumbers)
                .EnterInvalidOrgNameAndSearchInSearchResultsForPage(_dataHelper.InvalidOrgNameWithAWord);
        }
    }
}
