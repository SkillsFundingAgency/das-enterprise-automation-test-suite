using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderBulkUploadStepsHelper(ScenarioContext context)
    {
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper = new(context);

        public ProviderCohortApprovedPage AddApprenticeViaBulkUpload(int numberOfApprentices)
        {
            return _providerCommonStepsHelper.CurrentCohortDetails()
                .SelectBulkUploadApprentices()
                .UploadFileAndConfirmSuccessful(numberOfApprentices)
                .SubmitApprove();
        }

        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2WithCohortReference(string cohortReference) => UsingFileUpload().CreateACsvFileWithCohortReference(cohortReference, 1).UploadFile();

        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2ForLegalEntity(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef, string email, string name)
        {
            return UsingFileUpload()
            .CreateApprenticeshipsForAlreadyCreatedCohorts(numberOfApprenticesPerCohort)
            .CreateApprenticeshipsForEmptyCohorts(numberOfApprenticesWithoutCohortRef, email, name)
            .WriteApprenticeshipRecordsToCsvFile()
            .UploadFile();
        }

        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2(int numberOfApprenticesPerCohort) => AddApprenticeViaBulkUploadV2(numberOfApprenticesPerCohort, 0);

        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef) =>
            UsingFileUpload().CreateACsvFile(numberOfApprenticesPerCohort, numberOfApprenticesWithoutCohortRef).UploadFile();

        public ProviderBulkUploadCsvFilePage UsingFileUpload() => GoToProviderHomePage().GotoSelectJourneyPage().SelectBulkUpload().ContinueToUploadCsvFilePage();

        private ApprovalsProviderHomePage GoToProviderHomePage() => _providerCommonStepsHelper.GoToProviderHomePage(true);
    }
}