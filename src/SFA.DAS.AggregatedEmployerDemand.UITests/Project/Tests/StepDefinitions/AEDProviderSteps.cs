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

        [Given(@"the provider has entered their contact details '(.*)', '(.*)' and '(.*)'")]
        public void GivenTheProviderHasEnteredTheirContactDetails(string emailAddress, string telephoneNumber, string website)
        {
            GivenTheProviderNavigatesToFindEmployersThatNeedATrainingProvider();
            WhenTheProviderShowsTheWhichEmployersTheyAreInterestedIn();
            _providerStepsHelper.ConfirmProviderContactDetailsBeforeSubmitting(emailAddress, telephoneNumber, website);
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

        [Then(@"the provider is able to submit the edited details")]
        public void ThenTheProviderIsAbleToSubmitTheEditedDetails()
        {
            _providerStepsHelper.ConfirmEditedProviderContactDetailsAndSubmit();
        }

    }
}
