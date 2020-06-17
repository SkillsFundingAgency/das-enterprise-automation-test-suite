using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApplySteps : EPAOBaseSteps
    {
        private readonly ScenarioContext _context;

        public ApplySteps(ScenarioContext context) : base(context) => _context = context;

        [Given(@"the (Apply User) is logged into Assessment Service Application")]
        [When(@"the (Apply User) is logged into Assessment Service Application")]
        public void GivenTheUserIsLoggedIntoAssessmentServiceApplication(string _) => searchForYourOrganisationPage = ePAOHomePageHelper.LoginInAsApplyUser(ePAOApplyUser);

        [When(@"the Apply User completes preamble journey")]
        public void WhenTheApplyUserCompletesPreambleJourney() => applicationOverviewPage = applyStepsHelper.CompletePreambleJourney(searchForYourOrganisationPage, "BRUNEL UNIVERSITY LONDON");

        [When(@"the Apply User completes Organisation details section")]
        public void WhenTheApplyUserCompletesOrganisationDetailsSection() => applicationOverviewPage = applyStepsHelper.CompleteOrganisationDetailsSection(applicationOverviewPage);

        [When(@"the Apply User completes the Declarations section")]
        public void WhenTheApplyUserCompletesTheDeclarationsSection() => applicationOverviewPage = applyStepsHelper.CompleteDeclarationsSection(applicationOverviewPage);

        [When(@"the Apply User completes the FHA section")]
        public void WhenTheApplyUserCompletesTheFHASection() => applicationOverviewPage = applyStepsHelper.CompletesTheFHASection(applicationOverviewPage);

        [Then(@"the application is allowed to be submitted")]
        public void ThenTheApplicationIsAllowedToBeSubmitted() => applyStepsHelper.SubmitApplication(applicationOverviewPage);

        [Then(@"the User Name is displayed in the Logged In Home page")]
        public void ThenTheUserNameIsDisplayedInTheLoggedInHomePage() => new AS_LoggedInHomePage(_context).VerifySignedInUserName(ePAOApplyUser.FullName);

        [Then(@"the Apply User is able to Signout from the application")]
        public void ThenTheApplyUserIsAbleToSignoutFromTheApplication() => new AS_LoggedInHomePage(_context).ClickSignOutLink().ClickSignBackInLink();

        [When(@"the Apply User initiates Create Account journey")]
        public void WhenTheApplyUserInitiatesCreateAccountJourney() => createAnAccountPage = ePAOHomePageHelper.GoToEpaoAssessmentLandingPage().ClickCreateAnAccountLink();

        [Then(@"the Apply User is able to Create an Account")]
        public void ThenTheApplyUserIsAbleToCreateAnAccount() => createAnAccountPage.EnterAccountDetailsAndClickCreateAccount();

        [Then(@"no matches are shown for Organisation searches with Invalid search term")]
        public void ThenNoMatchesAreShownForOrganisationSearchesWithInvalidSearchTerm()
        {
            new AP_PR1_SearchForYourOrganisationPage(_context)
                .EnterInvalidOrgNameAndSearchInSearchForYourOrgPage(ePAOApplyDataHelper.InvalidOrgNameWithAlphabets)
                .VerifyInvalidSearchResultText()
                .EnterInvalidOrgNameAndSearchInSearchResultsForPage(ePAOApplyDataHelper.InvalidOrgNameWithNumbers)
                .EnterInvalidOrgNameAndSearchInSearchResultsForPage(ePAOApplyDataHelper.InvalidOrgNameWithAWord);
        }
    }
}
