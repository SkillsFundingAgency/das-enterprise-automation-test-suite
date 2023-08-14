using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiProviderSteps
    {
        private readonly FlexiProviderStepsHelper _flexiProviderStepsHelper;
        private ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage;

        public FlexiProviderSteps(ScenarioContext context)
        {
            _flexiProviderStepsHelper = new FlexiProviderStepsHelper(context);
        }

        [Then(@"provider can edit delivery model and approve")]
        public void ThenProviderCanEditDeliveryModelAndApprove() => _flexiProviderStepsHelper.ProviderEditsDeliveryModelAndApprovesAfterFJAARemoval();

        [Then(@"the provider confirms Delivery Model is displayed as ""([^""]*)"" on Apprentice Details and Edit Apprentice screens")]
        public void ThenTheProviderConfirmsDeliveryModelIsDisplayedAsOnApprenticeDetailsAndEditApprenticeScreens(string deliveryModel) => _flexiProviderStepsHelper.ValidateDeliveryModelDisplayedInDMSections(deliveryModel);

        [Then(@"the Provider changes the Delivery Model from Regular to Flexi and sends back to employer to review")]
        public void ThenTheProviderChangesTheDeliveryModelFromRegularToFlexiAndSendsBackToEmployerToReview() => _flexiProviderStepsHelper.ProviderChangeDeliveryModelToFlexiAndSendsBackToProvider_PreApproval();

        [When(@"the Provider edits the Delivery Model to Regular in Post Approvals and submits changes")]
        public void WhenTheProviderEditsTheDeliveryModelToRegularInPostApprovalsAndSubmitsChanges() => _flexiProviderStepsHelper.ProviderChangeDeliveryModelToRegularAndSendsBackToProvider_PostApproval();

        [When(@"the Provider edits the Delivery Model to Flexi in Post Approvals and submits changes")]
        public void WhenTheProviderEditsTheDeliveryModelToFlexiInPostApprovalsAndSubmitsChanges() => _flexiProviderStepsHelper.ProviderChangeDeliveryModelToFlexiAndSendsBackToProvider_PostApproval();

        [When(@"the provider selects Flexi-job agency radio button on Select Delivery Model screen")]
        public void WhenTheProviderSelectsFlexi_JobAgencyRadioButtonOnSelectDeliveryModelScreen() => _providerAddApprenticeDetailsPage = _flexiProviderStepsHelper.AddApprenticeAndSelectFlexiJobAgencyDeliveryModel();

        [Then(@"provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details")]
        public void ThenProviderValidateFlexi_JobAgencyContentOnAddApprenticeDetailsPageAndSubmitValidDetails() => _flexiProviderStepsHelper.ValidateFlexiJobContentAndSendToEmployerForApproval(_providerAddApprenticeDetailsPage).ValidateFlexiJobTagAndSubmitApprove();
    }
}