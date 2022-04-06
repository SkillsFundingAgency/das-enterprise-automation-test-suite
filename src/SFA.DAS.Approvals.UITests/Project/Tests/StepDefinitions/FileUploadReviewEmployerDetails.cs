using System.Collections.Generic;
#region Helper Classes

public class FileUploadReviewEmployerDetails
    {
        public string EmployerName { get; set; }
        public string AgreementId { get; set; }
        public string CohortRef { get; set; }
        public List<FileUploadReviewCohortDetail> CohortDetails { get; set; }
    }
    #endregion