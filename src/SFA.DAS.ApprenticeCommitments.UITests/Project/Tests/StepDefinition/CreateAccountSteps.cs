using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private CreateMyApprenticeshipAccountPage _createMyApprenticeshipAccountPage;
        private ApprenticeHomePage _apprenticeHomePage;
        private ApprenticeHomePageNegativeMatch _apprenticeHomePagNegativeMatch;
        private (string firstName, string lastName) _name;

        public CreateAccountSteps(ScenarioContext context) : base(context) => _context = context;

        [When(@"an apprenticeship is created via API request")]
        public void WhenAnApprenticeshipIsCreatedViaApiRequest() => createAccountStepsHelper.CreateApprenticeshipViaApiRequest();

        [Then(@"the apprentice is able to create an account with the invite generated")]
        public void ThenTheApprenticeIsAbleToCreateAnAccountWithTheInviteGenerated() => createAccountStepsHelper.CreateAccountViaApi();

        [Then(@"an error is shown for entering invalid identity data")]
        public void ThenAnErrorIsShownForEnteringInvalidIdentityData()
        {
            var (page, name) = _createMyApprenticeshipAccountPage.EnterInValidApprenticeDetails();
            _apprenticeHomePagNegativeMatch = page.AcceptTermsAndConditionForNegativeMatch();
            _name = name;
        }

        [Then(@"a positive match is shown after entering valid data")]
        public void ThenAPositiveMatchIsShownAfterEnteringValidData()
        {
            _apprenticeHomePage = new ApprenticeHomePageNegativeMatch(_context).GoToChangeYourPersonalDetailsPage().EnterValidApprenticeDetails(_name.firstName, _name.lastName).VerifySucessNotification();
            _apprenticeHomePage = _apprenticeHomePage.NavigateToOverviewPageFromLinkOnTheHomePage().NavigateToHomePageFromTopNavigationLink();
            Assert.IsFalse(_apprenticeHomePage.VerifyNotificationBannerIsNotDisplayed(), "Notification Banner is displayed");
        }

        [Then(@"an error is shown for entering empty data")]
        public void ThenAnErrorIsShownForEnteringEmptyData()
        {
            var invalidData = new List<(string, string, int, int, int)>
            {
                (string.Empty, string.Empty, 0,0,0)
            };

            foreach (var d in invalidData)
            {
                _createMyApprenticeshipAccountPage = _createMyApprenticeshipAccountPage.InvalidData(d.Item1, d.Item2, d.Item3, d.Item4, d.Item5);
                _createMyApprenticeshipAccountPage.VerifyErrorSummary();
            }
        }

        [Given(@"an apprentice has created the account and about to validate personal details")]
        public void GivenAnApprenticeHasCreatedTheAccountAndAboutToValidatePersonalDetails()
        {
            createAccountStepsHelper.CreateApprenticeshipViaApiRequest();
            _createMyApprenticeshipAccountPage = createAccountStepsHelper.CreateAccountAndGetToCreateMyApprenticeshipAccountPage();
        }
    }
}
