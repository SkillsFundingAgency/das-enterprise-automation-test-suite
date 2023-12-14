using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class FlexiProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;
        private readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper;

        public FlexiProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
            _replaceApprenticeDatahelper = new ReplaceApprenticeDatahelper(context);
        }

        public ProviderApproveApprenticeDetailsPage PilotProviderAddApprentice(List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice)
        {
            static ProviderApproveApprenticeDetailsPage SubmitValidApprenticeDetails(SimplifiedPaymentsPilotPage page) => page.MakePaymentsPilotSelectionAndContinueToSelectStandardPage().ProviderSelectsAStandardForFlexiPilotLearner().SubmitValidApprenticeDetails();

            _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(0);

            var providerReviewYourCohortPage = SubmitValidApprenticeDetails(_providerCommonStepsHelper.ChooseALevyEmployer().ConfirmEmployerForFlexiTrainingProvider());

            int numberOfApprentices = listOfApprentice.Count;

            for (int i = 1; i < numberOfApprentices; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                providerReviewYourCohortPage = SubmitValidApprenticeDetails(providerReviewYourCohortPage.SelectAddAnApprenticeForFlexiPaymentsProvider());
            }

            return _providerCommonStepsHelper.SetApprenticeDetails(providerReviewYourCohortPage, numberOfApprentices);
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
                .ClickSave(true);
        }

        public ProviderCohortApprovedPage ProviderChangeDeliveryModelToFlexiAndSendsBackToProvider_PreApproval()
        {
            return _providerCommonStepsHelper.ViewCurrentCohortDetails()
                .SelectEditApprentice()
                .EnterUlnAndSelectEditDeliveryModel()
                .ProviderSelectFlexiJobAgencyDeliveryModelAndSubmit()
                .ClickSave(true)
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