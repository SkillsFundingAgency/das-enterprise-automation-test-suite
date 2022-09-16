using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNewApprenticeDetailsSavedSuccessfully : ApprovalsBasePage
    {
        private readonly IVerifyBulkUploadApprentices _verifyBulkUploadApprentices;

        protected override string PageTitle => "New apprentice details saved successfully";

        public ProviderNewApprenticeDetailsSavedSuccessfully(ScenarioContext context, IVerifyBulkUploadApprentices verifyBulkUploadApprentices) : base(context)
        {
            _verifyBulkUploadApprentices = verifyBulkUploadApprentices;
        }

        public ProviderNewApprenticeDetailsSavedSuccessfully VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            _verifyBulkUploadApprentices.VerifyCorrectInformationIsDisplayed(apprenticeList);

            return this;
        }
    }
}
