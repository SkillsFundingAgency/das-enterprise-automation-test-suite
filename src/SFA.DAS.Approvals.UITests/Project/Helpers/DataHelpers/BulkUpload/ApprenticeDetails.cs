using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload
{
    public class ApprenticeDetails
    {
        public ApprenticeDetails() => EPAOrgID = "EPA0001";

        public ApprenticeDetails(string courseCode) : this() => StdCode = courseCode;

        public ApprenticeDetails(int courseCode, DateTime dateOfBirth, DateTime startDate, DateTime endDate) : this($"{courseCode}")
        {
            DateOfBirth = dateOfBirth.ToString("yyyy-MM-dd");
            StartDate = startDate.ToString("yyyy-MM-dd");
            EndDate = endDate.ToString("yyyy-MM");
            RecognisePriorLearning = "false";
            DurationReducedBy = "";
            PriceReducedBy = "";
        }

        public string CohortRef { get; set; }
        public string ULN { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public string DateOfBirth { get; set; }
        public string StdCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TotalPrice { get; set; }
        public string EPAOrgID { get; set; }
        public string ProviderRef { get; set; }
        public string EmailAddress { get; set; }
        public string AgreementId { get; set; }
        public string RecognisePriorLearning { get; set; }
        public string DurationReducedBy { get; set; }
        public string PriceReducedBy { get; set; }

        public override string ToString()
        {
            return $"ApprenticeDetail - CohortRef: {CohortRef}, ULN: {ULN}, First Name: {GivenNames}, Last Name: {FamilyName}, Email address: {EmailAddress}";
        }
    }

    public class MapApprenticeDetails : ApprenticeDetails
    {
        public string Category { get; set; }

        public string ErrorMessage { get; set; }
    }
}
