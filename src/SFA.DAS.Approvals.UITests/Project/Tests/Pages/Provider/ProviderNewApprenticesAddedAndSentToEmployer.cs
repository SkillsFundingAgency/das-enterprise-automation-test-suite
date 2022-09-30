using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNewApprenticesAddedAndSentToEmployer : ApprovalsBasePage
    {
        private readonly IVerifyBulkUploadApprentices _verifyBulkUploadApprentices;

        protected override string PageTitle => "New apprentices added and sent to employer(s) for approval";

        public ProviderNewApprenticesAddedAndSentToEmployer(ScenarioContext _context, IVerifyBulkUploadApprentices verifyBulkUploadApprentices) : base(_context)
        {
            _verifyBulkUploadApprentices = verifyBulkUploadApprentices;
        }

        public ProviderNewApprenticesAddedAndSentToEmployer VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            _verifyBulkUploadApprentices.VerifyCorrectInformationIsDisplayed(apprenticeList);

            return this;
        }
    }
}
