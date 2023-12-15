using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.BulkUpload;

public class FileUploadReviewEmployerDetails
{
    public string EmployerName { get; set; }
    public string AgreementId { get; set; }
    public string CohortRef { get; set; }
    public List<FileUploadReviewCohortDetail> CohortDetails { get; set; }
}