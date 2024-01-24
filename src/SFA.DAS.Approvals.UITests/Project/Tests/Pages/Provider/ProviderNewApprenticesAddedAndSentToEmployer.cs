using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.BulkUpload;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNewApprenticesAddedAndSentToEmployer(ScenarioContext _context, IVerifyBulkUploadApprentices verifyBulkUploadApprentices) : ApprovalsBasePage(_context)
    {
        protected override string PageTitle => "New apprentices added and sent to employer(s) for approval";

        public ProviderNewApprenticesAddedAndSentToEmployer VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            verifyBulkUploadApprentices.VerifyCorrectInformationIsDisplayed(apprenticeList);

            return this;
        }
    }
}
