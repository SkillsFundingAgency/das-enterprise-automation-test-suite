using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AEDProviderSteps
    {
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderConfig _config;
        private readonly ProviderLoginUser _login;


        public AEDProviderSteps(ScenarioContext context)
        {
            _config = context.GetProviderConfig<ProviderConfig>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _login = new ProviderLoginUser { Username = _config.UserId, Password = _config.Password, Ukprn = _config.Ukprn };
        }

        [Given(@"the provider navigates to Find employers that need a training provider")]
        public void GivenTheProviderNavigatesToFindEmployersThatNeedATrainingProvider()
        {
            _providerStepsHelper.GoToProviderHomePagePage(_login, true).FindEmployersThatNeedATrainingProvider();
        }

        [Given(@"the provider has entered their contact details '(.*)', '(.*)' and '(.*)'")]
        public void GivenTheProviderHasEnteredTheirContactDetails(string emailAddress, string telephoneNumber, string website)
        {
            GivenTheProviderNavigatesToFindEmployersThatNeedATrainingProvider();
            WhenTheProviderShowsTheWhichEmployersTheyAreInterestedIn();
            _providerStepsHelper.ConfirmProviderContactDetailsBeforeSubmitting(emailAddress, telephoneNumber, website);
        }

        [Given(@"the provider has entered their email contact details incorrectly '(.*)', '(.*)' and '(.*)'")]
        public void GivenTheProviderHasEnteredTheirEmailContactDetailsIncorrectlyAnd(string wrongEmailAddress, string wrongTelephoneNumber, string website)
        {
            GivenTheProviderNavigatesToFindEmployersThatNeedATrainingProvider();
            WhenTheProviderShowsTheWhichEmployersTheyAreInterestedIn();
            _providerStepsHelper.EnterIncorrectProviderContactDetailsBeforeResubmitting(wrongEmailAddress, wrongTelephoneNumber, website);
        }

        [Given(@"the provider has not entered contact details")]
        public void GivenTheProviderHasNotEnteredContactDetails()
        {
            GivenTheProviderNavigatesToFindEmployersThatNeedATrainingProvider();
            WhenTheProviderShowsTheWhichEmployersTheyAreInterestedIn();
            _providerStepsHelper.AttemptToProgressWithoutEnteringProviderContactDetails();
        }

        [When(@"the provider shows the which employers they are interested in")]
        public void WhenTheProviderShowsTheWhichEmployersTheyAreInterestedIn()
        {
            _providerStepsHelper.GoToWhichEmployersAreYouInterestedInPage().CheckAndContinueWithfirstEmployerCheckbox();
        }

        [When(@"the provider is able to enter their details '(.*)', '(.*)' and '(.*)'")]
        public void WhenTheProviderIsAbleToEnterTheirDetailsAnd(string emailAddress, string telephoneNumber, string website)
        {
            _providerStepsHelper.ConfirmAndShareProvidersDetailsWithEmployersContactDetails(emailAddress, telephoneNumber, website);
        }

        [When(@"the provider selects the option to edit")]
        public void WhenTheProviderSelectsTheOptionToEdit()
        {
            _providerStepsHelper.ChangeProviderContactDetails();
        }

        [When(@"the provider chooses to edit the contact details '(.*)', '(.*)' and '(.*)'")]
        public void WhenTheProviderChoosesToEditTheContactDetailsAnd(string newEmailAddress, string newTelephoneNumber, string newWebsite)
        {
            _providerStepsHelper.ConfirmProviderContactDetailsHaveBeenEdited(newEmailAddress, newTelephoneNumber, newWebsite);
        }

        [When(@"the provider is presented with the validation error message before entering the correct details '(.*)', '(.*)' and '(.*)'")]
        public void WhenTheProviderIsPresentedWithTheValidationErrorMessageBeforeEnteringTheCorrectDetailsAnd(string emailAddress, string telephoneNumber, string website)
        {
            _providerStepsHelper.ReEnterProviderContactDetailsBeforeResubmitting(emailAddress, telephoneNumber, website);
        }

        [When(@"the provider selects the option to edit the location")]
        public void WhenTheProviderSelectsTheOptionToEditTheLocation()
        {
            _providerStepsHelper.ChangeProviderLocationDetails();
        }

        [Then(@"the provider is able to submit the edited details")]
        public void ThenTheProviderIsAbleToSubmitTheEditedDetails()
        {
            _providerStepsHelper.ConfirmEditedProviderContactDetailsAndSubmit();
        }

        [Then(@"the provider is able to navigate to beginning of the journey using the back links")]
        public void ThenTheProviderIsAbleToNavigateToBeginningOfTheJourneyUsingTheBackLinks()
        {
            _providerStepsHelper.NavigateBacktoWhichEmployersAreYouInterestedInPageFromCheckYourAnswersPage();
        }

        [Then(@"the provider is able to submit their location details")]
        public void TheProviderIsAbleToSubmitTheirLocationDetails()
        {
            _providerStepsHelper.ConfirmEditedProviderLocationDetailsAndSubmit();
        }
    }
}
