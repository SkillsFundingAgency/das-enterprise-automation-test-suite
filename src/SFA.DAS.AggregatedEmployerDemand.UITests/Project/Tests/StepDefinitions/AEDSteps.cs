using NUnit.Framework;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages;
using SFA.DAS.FAT_V2.UITests.Project.Tests;
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
        private WeSharedThisInterestWithTrainingProvidersPage _weSharedThisInterestWithTrainingProvidersPage;

        public AEDSteps(ScenarioContext context)
        {
            _context = context;
            _aEDStepsHelper = new AEDStepsHelper(_context);
        }

        [Given(@"the user selects get help with finding a training provider")]
        public void GivenTheUserSelectsGetHelpWithFindingATrainingProvider()
        {
            _getHelpWithFindingATrainingProviderPage = _aEDStepsHelper.GetHelpWithFindingATrainingProvider();
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
            _weSharedThisInterestWithTrainingProvidersPage = _checkYourAnswersPage.ConfirmYourAnswers();
        }
    }
}
