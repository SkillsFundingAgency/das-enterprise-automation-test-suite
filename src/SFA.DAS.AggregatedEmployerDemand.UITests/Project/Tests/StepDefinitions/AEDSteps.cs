using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AEDSteps
    {
        private readonly ScenarioContext _context;
        private readonly AEDStepsHelper _aEDStepsHelper;
        private GetHelpWithFindingATrainingProviderPage _getHelpWithFindingATrainingProviderPage;
        private CheckYourAnswersPage _checkYourAnswersPage;
        private readonly MailinatorSteps _mailinatorSteps;

        public AEDSteps(ScenarioContext context)
        {
            _context = context;
            _aEDStepsHelper = new AEDStepsHelper(_context);
            _mailinatorSteps = new MailinatorSteps(_context);
        }

        [Given(@"the User searches a course then navigates to the provider list")]
        public void GivenTheUserSearchesACourseThenNavigatesToTheProviderList()
        {
            _aEDStepsHelper.NavigateToShareYourInterestWithTrainingProvidersPage();
        }


        [Given(@"the user selects get help with finding a training provider")]
        public void GivenTheUserSelectsGetHelpWithFindingATrainingProvider()
        {
            _getHelpWithFindingATrainingProviderPage = _aEDStepsHelper.GetHelpWithFindingATrainingProvider();
        }

        [Given(@"the user selects share interest with finding a training provider")]
        public void GivenTheUserSelectsShareInterestWithFindingATrainingProvider()
        {
            _getHelpWithFindingATrainingProviderPage = _aEDStepsHelper.GetHelpWithFindingATrainingProviderViaShortlistPage();
        }


        [Given(@"the user has navigated to shortlist page")]
        public void GivenTheUserHasNavigatedToShortlistPage()
        {
            _aEDStepsHelper.NavigateToShareYourInterestWithTrainingProvidersPageViaShortlistPage();
        }

        [Given(@"the employer has shared interest '(.*)', '(.*)' and '(.*)'")]
        public void GivenTheEmployerHasSharedInterest(string location, string organisationName, string organisationEmailAddress)
        {
            GivenTheUserSearchesACourseThenNavigatesToTheProviderList();
            GivenTheUserSelectsGetHelpWithFindingATrainingProvider();
            WhenTheUserEntersTheLocationAs(location);
            WhenTheUserSelectsNoApprentices();
            WhenTheUserEntersTheOrganisationName(organisationName);
            WhenTheUserEntersTheOrganisationEmailAddress(organisationEmailAddress);
            ThenTheUserIsAbleToSubmitTheFormToRegisterInterest();
            _mailinatorSteps.ThenConfirmTheUserIsAbleToVerifyTheEmail(organisationEmailAddress);
        }


        [When(@"the user enters the number of Apprentices as '(.*)'")]
        public void WhenTheUserEntersTheNumberOfApprenticesAs(string noOfApprentices)
        {
            _getHelpWithFindingATrainingProviderPage = _getHelpWithFindingATrainingProviderPage.EnterNumberOfApprentices(noOfApprentices);
        }

        [When(@"the user enters the location as '(.*)'")]
        public void WhenTheUserEntersTheLocationAs(string location)
        {
            _getHelpWithFindingATrainingProviderPage = _getHelpWithFindingATrainingProviderPage.EnterApprenticeshipLocation(location);
        }

        [When(@"the user enters the Organisation name '(.*)'")]
        public void WhenTheUserEntersTheOrganisationName(string organisationName)
        {
            _getHelpWithFindingATrainingProviderPage = _getHelpWithFindingATrainingProviderPage.EnterOrganisationName(organisationName);
        }

        [When(@"the user enters the Organisation Email Address '(.*)'")]
        public void WhenTheUserEntersTheOrganisationEmailAddress(string organisationEmailAddress)
        {
            _getHelpWithFindingATrainingProviderPage = _getHelpWithFindingATrainingProviderPage.EnterOrganisationEmailAddress(organisationEmailAddress);
        }

        [When(@"the user selects no Apprentices")]
        public void WhenTheUserSelectsNoApprentices()
        {
            _getHelpWithFindingATrainingProviderPage = _getHelpWithFindingATrainingProviderPage.SelectNoApprentices();
        }

        [Then(@"the user is able to submit the form to register interest")]
        public void ThenTheUserIsAbleToSubmitTheFormToRegisterInterest()
        {
            _checkYourAnswersPage = _getHelpWithFindingATrainingProviderPage.ContinueToCheckYourAnswersPage();

            _checkYourAnswersPage.ConfirmYourAnswers();
        }
    }
}
