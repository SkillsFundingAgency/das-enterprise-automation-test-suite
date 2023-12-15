using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.BulkUpload;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNewApprenticeDetailsSavedSuccessfully(ScenarioContext context, IVerifyBulkUploadApprentices verifyBulkUploadApprentices) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "New apprentice details saved successfully";

        public ProviderNewApprenticeDetailsSavedSuccessfully VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            verifyBulkUploadApprentices.VerifyCorrectInformationIsDisplayed(apprenticeList);

            return this;
        }
    }
}
