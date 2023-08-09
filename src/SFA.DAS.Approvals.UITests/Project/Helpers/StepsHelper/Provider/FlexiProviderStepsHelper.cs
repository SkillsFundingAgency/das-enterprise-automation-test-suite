using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class FlexiProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        public FlexiProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
        }

        public ProviderApproveApprenticeDetailsPage ValidateFlexiJobContentAndSendToEmployerForApproval(ProviderAddApprenticeDetailsPage providerAddApprenticeDetailsPage)
        {
            providerAddApprenticeDetailsPage.ValidateFlexiJobContent();

            var providerApproveApprenticeDetailsPage = providerAddApprenticeDetailsPage.SubmitValidApprenticeDetails();

            return _providerCommonStepsHelper.SetApprenticeDetails(providerApproveApprenticeDetailsPage, 1);
        }

        public ProviderAddApprenticeDetailsPage AddApprenticeAndSelectFlexiJobAgencyDeliveryModel()
        {
            var providerAddApprenticeDetailsPage = _providerCommonStepsHelper.CurrentCohortDetails();

            return providerAddApprenticeDetailsPage.SelectAddAnApprentice()
                .SelectsAStandardAndNavigatesToSelectDeliveryModelPage()
                .ProviderSelectFlexiJobAgencyDeliveryModelAndContinue();
        }


        public ProviderApproveApprenticeDetailsPage ProviderEditsDeliveryModelAndApprovesAfterFJAARemoval()
        {
            return new ProviderApproveApprenticeDetailsPage(_context)
                .SelectEditApprentice()
                .SelectEditDeliveryModel()
                .ConfirmDeliveryModelChangeToRegular()
                .ValidateDeliveryModelDisplayed("Regular")
                .ClickSave();
        }

        public ProviderCohortApprovedPage ProviderChangeDeliveryModelToFlexiAndSendsBackToProvider_PreApproval()
        {
            return _providerCommonStepsHelper.ViewCurrentCohortDetails()
                .SelectEditApprentice()
                .EnterUlnAndSelectEditDeliveryModel()
                .ProviderSelectFlexiJobAgencyDeliveryModelAndSubmit()
                .ClickSave()
                .ValidateFlexiJobTagAndSubmitApprove();
        }

        public ProviderApprenticeDetailsPage ProviderChangeDeliveryModelToRegularAndSendsBackToProvider_PostApproval()
        {
            return GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickEditApprenticeLink()
                .ClickEditDeliveryModel()
                .ProviderEditsDeliveryModelToRegularAndSubmits()
                .ClickUpdateDetails()
                .AcceptChangesAndSubmit();
        }

        public ProviderApprenticeDetailsPage ValidateDeliveryModelDisplayedInDMSections(string deliveryModel)
        {
            return GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ValidateDeliveryModelDisplayed(deliveryModel);
        }

        public ProviderApprenticeDetailsPage ProviderChangeDeliveryModelToFlexiAndSendsBackToProvider_PostApproval()
        {
            return GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickEditApprenticeLink()
                .ClickEditDeliveryModel()
                .ProviderEditsDeliveryModelToFlexiAndSubmits()
                .ClickUpdateDetails()
                .AcceptChangesAndSubmit();
        }

        private ApprovalsProviderHomePage GoToProviderHomePage() => _providerCommonStepsHelper.GoToProviderHomePage();
    }
}